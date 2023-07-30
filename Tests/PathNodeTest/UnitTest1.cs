using Net.Leksi.Pocota.Common;
using System;
using System.Collections;
using System.Diagnostics;

namespace PathNodeTest;

public class PathNodeTests
{
    private const string s_alphabet = "abcdefghijklmnopqrstuvwxyz@*";
    private const int s_numRandomTests = 1000;
    private const int s_scionDepth = 3;
    private const int s_scionNumChildren = 3;
    private const int s_treeMinDepth = 3;
    private const int s_treeMaxDepth = 5;
    private const int s_pushStockBase = 3;
    private const int s_hasChildrenBase = 3;
    private const int s_numChildrenParameter = 3;
    private const int s_isMandatoryBase = 5;
    private const int s_minLevelForMandatory = 2;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;
    }

    /// <summary>
    /// Несколько циклов строим случайное дерево и в случайных местах прививаем
    /// к нему случайные поддеревья, помеченные как AccessStuff,
    /// проверяем, что всё прошло по плану
    /// </summary>
    [TestCase(-1, false)]
    //[TestCase(1166512258, true)]
    [Test]
    public void RandomTreeTest(int randomSeed, bool showPass)
    {
        if(randomSeed == -1)
        {
            randomSeed = (int)(long.Parse(
                new string(
                    (DateTime.UtcNow.Ticks % int.MaxValue).ToString().Reverse().ToArray()
                )
            ) % int.MaxValue);
        }
        Console.WriteLine($"randomSeed: {randomSeed}");
        for (int i = 0; i < s_numRandomTests; ++i)
        {
            if (showPass)
            {
                Console.WriteLine($"randomSeed: {randomSeed}, pass: {i}");
            }

            // Список узлов, назначенных обязательными непосредственно через присвоение
            // свойства IsMandatory
            List<PathNode> notPropagatedMandatories = new();

            // Список узлов с именами '*' или '@'
            List<PathNode> specialNameNodes = new();

            // Ожидаемое соответствие родительских узлов детским по Id
            // <ребёнок, ожидаемый родительский Id> 
            Dictionary<PathNode, int> parents = new();

            // Кэш использованных имен дестких узлов для родителя с Id
            // нужен для генерации уникальных имен
            Dictionary<int, HashSet<string>> usedNames = new();

            // Генератор для всех случайных данных
            Random rnd = new(randomSeed);

            // Количество узлов в дереве
            int count = 0;

            // Количество узлов в дереве, назначенных обязательными непосредственно через присвоение
            // свойства IsMandatory
            int countMandatory = 0;

            // Список узлов, на которые будут привиты деревья
            List<StockHolder> stocks = new();

            // Ожидаемый список путей
            List<string> paths = new();

            // Делегат вызываемый при выборе подвоя
            Action<PathNode> pushStock = node =>
            {
                stocks.Add(new StockHolder { Stock = node, Stocks = stocks, Rnd = rnd });
            };

            Action incCount = () => ++count;
            Action incCountMandatory = () => ++countMandatory;
            Action decCount = () => --count;
            Action decCountMandatory = () => --countMandatory;

            // Строим дерево, заполняем счётчики, выбираем подвои
            PathNode root = CreateNode(
                null, 0, rnd, notPropagatedMandatories, incCount, parents, incCountMandatory,
                // В первом случае не прививаем на внутренние узлы
                i == 0 ? null : pushStock,
                usedNames, specialNameNodes, 0, paths, string.Empty, i
            );
            if (i == 0)
            {
                // В одном из случаев прививаем на корень
                stocks.Add(new StockHolder { Stock = root, Stocks = stocks, Rnd = rnd });
            }

            // Запоминаем количество узлов
            int numNodes = count;
            int numMandatory = countMandatory;

            // Проверяем, что начальное дерево без прививок вышло таким, как планировалось
            Assert.That(countMandatory, Is.EqualTo(notPropagatedMandatories.Count));
            WalkAssert(root, notPropagatedMandatories, decCount, parents, decCountMandatory);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(countMandatory, Is.EqualTo(0));

            // Проверяем GetPaths
            Assert.That(root.Paths, Is.EquivalentTo(paths));

            // Проверяем GetNode
            foreach(string path in paths)
            {
                PathNode? node = root.GetNode(path);
                Assert.That(node, Is.Not.Null);
                Assert.That(node.Path, Is.EqualTo(path));
            }

            // Проверяем клонирование
            Assert.That(root.Clone(), Is.EqualTo(root));

            PathNode[] notSpecialNameNodes = parents.Keys.Where(c =>
                    !c.Parent!.Children!.Any(n => "*".Equals(n.Name))
                    && !c.Parent!.Children!.Any(n => "@".Equals(n.Name))
                ).ToArray();

            // Пробуем добавить узел, уже имеющий родителя, ждём исключение
            foreach (PathNode node in notSpecialNameNodes)
            {
                if(notSpecialNameNodes.Where(c => c != node).FirstOrDefault() is PathNode add)
                {
                    InvalidOperationException ex = Assert.Catch<InvalidOperationException>(
                        () => node.Parent!.Children!.Add(add)
                    );
                    Assert.That(ex.Message, Is.EqualTo($"Node '{add.Path}' already has parent!"));
                }
            }
            // Пробуем установить IsAccessStuff не в корень, ждём исключение
            foreach (PathNode node in parents.Keys.Where(c => !c.IsAccessStuff))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.IsAccessStuff = true
                );
                Assert.That(ex.Message, Is.EqualTo("IsAccessStuff can be set only to root node!"));
            }

            // Пробуем заменить узел, ждём исключение
            foreach (PathNode node in parents.Keys.Where(c => c.Children.Any()))
            {
                for(int j = 0; j < node.Children.Count; ++j)
                {
                    InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                        () => node.Parent!.Children[j] = new PathNode("ab")
                    );
                    Assert.That(ex.Message, Is.EqualTo("Child node cannot be replaced!"));
                }
            }
            // Пробуем сделать сестру для '*', ждём исключение
            foreach (PathNode node in specialNameNodes.Where(c => "*".Equals(c.Name)))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode("ab"))
                );
                Assert.That(ex.Message, Is.EqualTo("Node '*' can be the only child!"));
            }
            // Пробуем сделать сестру для '@', ждём исключение
            foreach (PathNode node in specialNameNodes.Where(c => "@".Equals(c.Name)))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode("ab"))
                );
                Assert.That(ex.Message, Is.EqualTo("Node '@' can be the only child!"));
            }
            // Пробуем '*'  сделать сестрой, ждём исключение
            foreach (PathNode node in notSpecialNameNodes)
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode("*"))
                );
                Assert.That(ex.Message, Is.EqualTo("Node '*' can be the only child!"));
            }
            // Пробуем '@'  сделать сестрой, ждём исключение
            foreach (PathNode node in notSpecialNameNodes)
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode("@"))
                );
                Assert.That(ex.Message, Is.EqualTo("Node '@' can be the only child!"));
            }
            // Пробуем к '*' добавить детей, ждём исключение
            foreach (PathNode node in specialNameNodes.Where(c => "*".Equals(c.Name)))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Children.Add(new PathNode("a"))
                );
                Assert.That(ex.Message, Is.EqualTo("Node '*' can not have children!"));
            }
            // Пробуем добавить дублирующую сестру, ждём исключение
            foreach (PathNode node in notSpecialNameNodes)
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode(node.Parent!.Children![0].Name))
                );
                Assert.That(ex.Message, Is.EqualTo("Cannot add duplicate node!"));
            }
            // Пробуем добавить корневой узел, ждём исключение
            foreach (PathNode node in notSpecialNameNodes)
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Parent!.Children!.Add(new PathNode(string.Empty))
                );
                Assert.That(ex.Message, Is.EqualTo("Root node cannot be a child!"));
            }
            // Пробуем удалить не '*', ждём исключение
            foreach (PathNode node in parents.Keys
                .Where(c => c.Children.Any() && !c.Children.Any(c => specialNameNodes.Contains(c)))
            )
            {
                PathNode[] children = node.Children!.ToArray();
                foreach (PathNode child in children)
                {
                    InvalidOperationException ex = Assert.Catch<InvalidOperationException>(
                        () => node.Children!.Remove(child)
                    );
                    Assert.That(ex.Message, Is.EqualTo("Only '*' node can be removed!"));
                }
            }

            // Для всех правильных подвоев генерируем привой и прививаем
            foreach (StockHolder stock in stocks)
            {
                stock.CreateScion();
                AssertPropagationAccessStuff(stock.Scion);
                stock.Stock.Graft(stock.Scion);
            }

            // Пробуем привить к обязательному листу, ждём исключение
            if (notPropagatedMandatories.Any())
            {
                PathNode scion = PathNode.FromPaths(new string[]
                {
                    "a.b",
                    "a.c"
                });
                foreach (PathNode node in notPropagatedMandatories)
                {
                    StockHolder sh = new StockHolder
                    {
                        Stock = node,
                        Scion = scion,
                        Stocks = stocks,
                        Rnd = rnd
                    };
                    InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                        () => sh.Stock.Graft(sh.Scion)
                    );
                    Assert.That(ex.Message, Is.EqualTo("Mandatory node can not have children!"));
                }
            }

            int numAdded = stocks.Select(s => s.AddedNodes.Count).Sum();
            int countAccessStuff = 0;

            // Проверяем, что прививка прошла успешно
            WalkAssertAfterGraft(root, ref count, ref countMandatory, ref countAccessStuff);
            Assert.Multiple(() =>
            {
                Assert.That(count, Is.EqualTo(numNodes + numAdded));
                Assert.That(countMandatory, Is.EqualTo(numMandatory));
                Assert.That(countAccessStuff, Is.EqualTo(numAdded));
            });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="count"></param>
    /// <param name="countMandatory"></param>
    /// <param name="countAccessStuff"></param>
    private void WalkAssertAfterGraft(PathNode tree, ref int count, ref int countMandatory,
        ref int countAccessStuff)
    {
        ++count;
        if (tree.IsMandatory && !(bool)tree.IsPropagatedMandatory!)
        {
            ++countMandatory;
            AssertPropagationMandatory(tree);
        }
        if (tree.IsAccessStuff)
        {
            ++countAccessStuff;
        }
        if (tree.Children is { })
        {
            foreach (PathNode child in tree.Children)
            {
                WalkAssertAfterGraft(child, ref count, ref countMandatory, ref countAccessStuff);
            }
        }
    }

    /// <summary>
    /// Вспомогательный класс для организации прививки
    /// </summary>
    class StockHolder
    {
        /// <summary>
        /// Подвой
        /// </summary>
        internal PathNode Stock { get; init; }
        /// <summary>
        /// Список всех точек привики
        /// </summary>
        internal List<StockHolder> Stocks { get; init; }
        /// <summary>
        /// Генератор случайностей
        /// </summary>
        internal Random Rnd { get; init; }
        /// <summary>
        /// Привой
        /// </summary>
        internal PathNode Scion { get; set; }
        /// <summary>
        /// Список ожидаемых узлов, которые будут добавлены к исходномиу дереву
        /// </summary>
        internal List<PathNode> AddedNodes { get; init; } = new();
        /// <summary>
        /// Генерация привоя
        /// </summary>
        internal void CreateScion()
        {
            // Кэш использованных имен дестких узлов для родителя с Id
            // нужен для генерации уникальных имен
            Dictionary<int, HashSet<string>> usedNames = new();

            Scion = CreateSubtree(null, Stock, 0, true, usedNames);
            Scion.IsAccessStuff = true;
        }

        /// <summary>
        /// Генерация поддерева привоя.
        /// Строим дерево, которое сначала повторяет поддерево в узле подвоя, 
        /// потом в некоторых узлах расходится с ним.
        /// Поддеревья привоя генерируем однообразно:
        /// <c>s_scionDepth</c> яруса по <c>s_scionNumChildren</c> ребёнка в узле
        /// </summary>
        /// <param name="parent">
        /// Родительский узел привоя
        /// </param>
        /// <param name="stock">
        /// Соответствующий родительский узел подвоя, когда родительский узел привоя повторяет его.
        /// </param>
        /// <param name="level">
        /// Уровень рекурсии
        /// </param>
        /// <param name="copy">
        /// Указание, будет ли узел копией узла исходного дерева (не учитывая детей)
        /// </param>
        /// <param name="usedNames">
        /// Вспомогательный кэш для генерации уникальных имён
        /// </param>
        /// <returns>
        /// Созданный узел
        /// </returns>
        private PathNode CreateSubtree(
            PathNode? parent, PathNode stock, int level, bool copy, Dictionary<int, HashSet<string>> usedNames
        )
        {
            PathNode result;

            if (!usedNames.ContainsKey(parent?.Id ?? 0))
            {
                usedNames.Add(parent?.Id ?? 0, new HashSet<string>());
            }
            if (copy)
            {
                if (level > 0)
                {
                    // Корень имени не имеет
                    result = new PathNode(stock.Name);
                    usedNames[parent?.Id ?? 0].Add(result.Name);
                }
                else
                {
                    result = new PathNode(string.Empty);
                }
                if (level < s_scionDepth)
                {
                    // Копируем случайное число детей узла исходного дерева, остальные создаём новые.
                    int cnt = s_scionNumChildren;
                    if (stock.Children is { })
                    {
                        int take = Rnd.Next(Math.Min(cnt, stock.Children.Count));
                        // Копируем
                        foreach (PathNode node in stock.Children)
                        {
                            if (
                                take > 0
                                // Избегаем пересечения с узлами других подвоев!
                                && !Stocks.Any(h => h.Stock.Id == node.Id)
                                // Избегаем обязательных листьев!
                                && (!node.IsMandatory || (bool)node.IsPropagatedMandatory!)
                                // Не копируем *!
                                && !"*".Equals(node.Name)
                            )
                            {
                                result.Children.Add(CreateSubtree(result, node, level + 1, true, usedNames));
                                --cnt;
                                --take;
                            }
                        }
                    }
                    if (
                        stock.Children is null
                        || (
                            // Нельзя содавать сестёр для '*' и '@'
                            !stock.Children.Any(c => "*".Equals(c.Name))
                            && !stock.Children.Any(c => "@".Equals(c.Name))
                        )
                    )
                    {
                        if (stock.Children is { })
                        {
                            if (!usedNames.ContainsKey(result.Id))
                            {
                                usedNames.Add(result.Id, new HashSet<string>());
                            }
                            foreach (PathNode child in stock.Children)
                            {
                                usedNames[result.Id].Add(child.Name);
                            }
                        }
                        for (int i = 0; i < cnt; ++i)
                        {
                            // Тут создаём оригиналы
                            result.Children.Add(CreateSubtree(result, stock, level + 1, false, usedNames));
                        }
                    }
                }
            }
            else
            {
                // Создаём оригинальный узел,
                // Генерируем имя узла, уникальное среди сестёр и, если родитель - копия,
                // то также среди детей копируемого родителем узла
                string name = string.Empty;
                if (level > 0)
                {
                    for (
                        name = s_alphabet.Substring(Rnd.Next(s_alphabet.Length - 2), 1);
                        !usedNames[parent?.Id ?? 0].Add(name);
                        name = s_alphabet.Substring(Rnd.Next(s_alphabet.Length - 2), 1)
                    ) { }
                }
                result = new PathNode(name);
                // Этот узел будет добавлен в исходное дерево
                AddedNodes.Add(result);
                if (level < s_scionDepth)
                {
                    // Дети оригинального узла - тоже оригинальные
                    for (int i = 0; i < 3; ++i)
                    {
                        result.Children.Add(CreateSubtree(result, result, level + 1, false, usedNames));
                    }
                }
            }

            return result;
        }
    }

    /// <summary>
    /// Рекурсивно обходим дерево и проверяем
    /// </summary>
    /// <param name="node"></param>
    /// <param name="notPropagatedMandatories"></param>
    /// <param name="count"></param>
    /// <param name="parents"></param>
    /// <param name="countMandatory"></param>
    private void WalkAssert(PathNode node, List<PathNode> notPropagatedMandatories,
        Action decCount, Dictionary<PathNode, int> parents, Action decCountMandatory)
    {
        Assert.That(node.IsPropagatedMandatory is { }, Is.EqualTo(node.IsMandatory == true));
        if (node.IsPropagatedMandatory is { })
        {
            if (!(bool)node.IsPropagatedMandatory)
            {
                decCountMandatory();
            }
            AssertPropagationMandatory(node);
            Assert.That(notPropagatedMandatories.Contains(node), Is.EqualTo(!node.IsPropagatedMandatory));
        }
        if (node.Parent is null)
        {
            Assert.That(node.Name, Is.EqualTo(string.Empty));
        }
        else
        {
            Assert.That(node.Name, Is.Not.EqualTo(string.Empty));
        }
        if (node.Parent is null || string.IsNullOrEmpty(node.Parent.Path))
        {
            Assert.That(node.Name, Is.EqualTo(node.Path));
        }
        else
        {
            Assert.That(node.Path, Is.EqualTo($"{node.Parent.Path}.{node.Name}"));
        }
        decCount();
        Assert.That(node.Children.IsReadOnly, Is.False);
        if (node.Children.Any())
        {
            Assert.That(node.Children.GroupBy(ch => ch.Name).Count(), Is.EqualTo(node.Children.Count), node.ToString());
            IEnumerator en = ((IEnumerable)node.Children).GetEnumerator();
            while (en.MoveNext())
            {
                Assert.Multiple(() =>
                {
                    Assert.That(node.Children.Contains(en.Current));
                    Assert.That(node.Children.IndexOf((PathNode)en.Current), Is.Not.EqualTo(-1));
                });
            }

            if (!node.Children.Any(c => "*".Equals(c.Name)))
            {
                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => node.Children.Clear()
                );
                Assert.That(ex.Message, Is.EqualTo("Only '*' node can be removed!"));
                for (int j = 0; j < node.Children.Count; ++j)
                {
                    ex = Assert.Throws<InvalidOperationException>(
                        () => node.Children.RemoveAt(j)
                    );
                    Assert.That(ex.Message, Is.EqualTo("Only '*' node can be removed!"));
                    ex = Assert.Throws<InvalidOperationException>(
                        () => node.Children.Remove(node.Children[j])
                    );
                    Assert.That(ex.Message, Is.EqualTo("Only '*' node can be removed!"));
                }
                ex = Assert.Throws<InvalidOperationException>(
                    () => node.Children.Add(new PathNode(string.Empty))
                ); ;
                Assert.That(ex.Message, Is.EqualTo("Root node cannot be a child!"));
                ArgumentNullException ex1 = Assert.Throws<ArgumentNullException>(
                    () => node.Children.Add(null!)
                ); ;
                Assert.That(ex1.Message, Is.EqualTo("Value cannot be null. (Parameter 'Child')"));
            }
            else
            {
                PathNode save = node.Children[0];
                Assert.Multiple(() =>
                {
                    Assert.DoesNotThrow(() => node.Children.Clear());
                    Assert.That(node.Children.Any(), Is.False);
                });
                Assert.DoesNotThrow(() => node.Children.Insert(0, save));
                Assert.Multiple(() =>
                {
                    Assert.DoesNotThrow(() => node.Children.RemoveAt(0));
                    Assert.That(node.Children.Any(), Is.False);
                });
                Assert.DoesNotThrow(() => node.Children.Insert(0, save));
                Assert.Multiple(() =>
                {
                    Assert.DoesNotThrow(() => node.Children.Remove(save));
                    Assert.That(node.Children.Any(), Is.False);
                });
                Assert.DoesNotThrow(() => node.Children.Insert(0, save));
            }

            Assert.Multiple(() =>
            {
                Assert.That(node.Children.Contains(node), Is.False);
                Assert.That(node.Children.IndexOf(node), Is.EqualTo(-1));
            });
            for (int j = 0; j < node.Children.Count; ++j)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(node.Children[j].RootNode, Is.EqualTo(node.RootNode));
                    Assert.That(node.Children.Contains(node.Children[j]), Is.True);
                    Assert.That(parents[node.Children[j]], Is.EqualTo(node.Id));
                    Assert.That(node.Children.IndexOf(node.Children[j]), Is.EqualTo(j));
                });
                WalkAssert(node.Children[j], notPropagatedMandatories, decCount, parents, decCountMandatory);
            }
        }
    }

    /// <summary>
    /// Проверяем, что свойство <c>IsAccessStuff</c> распространяется к листьям
    /// </summary>
    /// <param name="node"></param>
    private void AssertPropagationAccessStuff(PathNode node)
    {
        Assert.That(node.IsAccessStuff);
        if (node.Children is { })
        {
            foreach (PathNode child in node.Children)
            {
                AssertPropagationAccessStuff(child);
            }
        }
    }

    /// <summary>
    /// Проверяем, что свойство <c>IsMandatory</c> распространяется к корню
    /// </summary>
    /// <param name="node"></param>
    private void AssertPropagationMandatory(PathNode node)
    {
        Assert.That(node.IsMandatory);
        if (node.Parent is { })
        {
            AssertPropagationMandatory(node.Parent);
        }
    }

    /// <summary>
    /// Распечатка дерева, если нужно посмотреть
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="stocks">
    /// Список узлов подвоя
    /// </param>
    /// <param name="withStocks">
    /// Указывает, нужно ли показывать узлы подвоя.
    /// </param>
    private void PrintTree(PathNode tree, List<StockHolder> stocks, bool withStocks)
    {
        if (withStocks)
        {
            string[] path = tree.Path.Split('.');
            foreach (StockHolder stock in stocks.Where(s => s.Stock.Path.Length > 0 && tree.Path.StartsWith(s.Stock.Path)))
            {
                path[(stock.Stock.Path.Length + 1) / 2 - 1] = $"({stocks.IndexOf(stock)}:{path[(stock.Stock.Path.Length + 1) / 2 - 1]})";
            }
            Console.WriteLine($"{(stocks.Any() && string.IsNullOrEmpty(stocks[0].Stock.Path) ? $"(0)" : string.Empty)}{(path.Length <= 1 && string.IsNullOrEmpty(path[0]) ? "()" : string.Join('.', path))}");
        }
        else
        {
            Console.WriteLine(string.IsNullOrEmpty(tree.Path) ? "()" : tree.Path);
        }
        if (tree.Children is { })
        {
            foreach (PathNode child in tree.Children)
            {
                PrintTree(child, stocks, withStocks);
            }
        }
    }

    /// <summary>
    /// Создание узла исходного дерева
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="level"></param>
    /// <param name="rnd"></param>
    /// <param name="notPropagatedMandatories"></param>
    /// <param name="count"></param>
    /// <param name="parents"></param>
    /// <param name="countMandatory"></param>
    /// <param name="pushStock"></param>
    /// <param name="usedNames"></param>
    /// <returns></returns>
    private PathNode CreateNode(
        PathNode? parent, int level, Random rnd, List<PathNode> notPropagatedMandatories,
        Action incCount,
        Dictionary<PathNode, int> parents,
        Action incCountMandatory, Action<PathNode>? pushStock,
        Dictionary<int, HashSet<string>> usedNames,
        List<PathNode> specialNameNodes,
        int numSiblings,
        List<string> paths,
        string path, int pass
    )
    {
        if (!usedNames.ContainsKey(parent?.Id ?? 0))
        {
            usedNames.Add(parent?.Id ?? 0, new HashSet<string>());
        }

        bool willHaveChildren = level < s_treeMinDepth
            || (level < s_treeMaxDepth && rnd.Next() % s_hasChildrenBase != 0);

        bool willBeMandatory = !willHaveChildren && level >= s_minLevelForMandatory
            && rnd.Next() % s_isMandatoryBase == 0;

        // Количество детей, добавленных в список до его присвоения узлу
        int numChildrenBefore = willHaveChildren ? rnd.Next(s_numChildrenParameter) : 0;

        // Количество детей, добавленных в список после его присвоения узлу
        int numChildrenAfter = willHaveChildren ?
            (numChildrenBefore == 0 ? 1 : 0) + rnd.Next(s_numChildrenParameter) : 0;

        // Генерируем уникальное имя среди сестёр
        string name = string.Empty;
        string newPath = string.Empty;
        if (level > 0)
        {
            int len = numSiblings > 0 || willHaveChildren || level < s_treeMinDepth || willBeMandatory
                ? s_alphabet.Length - 2 : s_alphabet.Length;
            for (
                name = s_alphabet.Substring(rnd.Next(len), 1);
                !usedNames[parent?.Id ?? 0].Add(name);
                name = s_alphabet.Substring(rnd.Next(len), 1)
            ) { }
            newPath = $"{path}{(string.IsNullOrEmpty(path) ? string.Empty : '.')}{name}";
            if (willBeMandatory)
            {
                name += "!";
            }

        }
        PathNode node = new(name);

        //if(pass == 1)
        //{
        //    Console.WriteLine($"{node.Id}, {node.Name}, {level}, {willHaveChildren}, {willBeMandatory}");
        //}

        if (node.IsMandatory)
        {
            // Фиксируем, что данный узел был явно назначен обязательным
            notPropagatedMandatories.Add(node);
            incCountMandatory();
        }
        if ("@".Equals(node.Name) || "*".Equals(node.Name))
        {
            specialNameNodes.Add(node);
        }
        // С некоторой вероятностью назначаем этот узел узлом подвоя.
        if (
            // Это не должен быть корень, с корнем разобрались отдельно
            level > 0
            && pushStock is { }
            // Это не обязательный лист
            && (!node.IsMandatory || (bool)node.IsPropagatedMandatory!)
            // Это не '*'
            && !"*".Equals(node.Name)
            && rnd.Next() % s_pushStockBase == 0
        )
        {
            pushStock(node);
        }

        // Фиксируем родителя отдельно, для последующей проверки
        if (parent is { })
        {
            parents.Add(node, parent.Id);
        }

        incCount();

        if (willHaveChildren)
        {
            List<PathNode> children = new();

            for (
                int i = 0;
                i < numChildrenBefore
                    && !children.Any(c => "@".Equals(c.Name))
                    && !children.Any(c => "*".Equals(c.Name));
                ++i
            )
            {
                children.Add(
                    CreateNode(
                        node, level + 1, rnd, notPropagatedMandatories,
                        incCount, parents, incCountMandatory, pushStock, 
                        usedNames, specialNameNodes, children.Count, paths, newPath, pass
                    )
                );
            }
            children.ForEach(c => node.Children.Add(c));
            for (
                int i = 0;
                i < numChildrenAfter
                    && !node.Children.Any(c => "@".Equals(c.Name))
                    && !node.Children.Any(c => "*".Equals(c.Name));
                ++i
            )
            {
                node.Children.Add(
                    CreateNode(node, level + 1, rnd, notPropagatedMandatories,
                        incCount, parents, incCountMandatory, pushStock, usedNames, 
                        specialNameNodes, node.Children.Count, paths, newPath, pass
                    )
                );
            }
        }
        else
        {
            paths.Add( newPath );
        }
        return node;
    }

}
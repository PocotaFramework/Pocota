using Net.Leksi.Pocota.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PathNodeTest;

public class PathNodeTests
{
    private const string s_alphabet = "abcdefghijklmnopqrstuvwxyz";
    private const int s_numRandomTests = 100;
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
    /// ��������� ������ ������ ��������� ������ � � ��������� ������ ���������
    /// � ���� ��������� ����������, ���������� ��� AccessStuff,
    /// ���������, ��� �� ������ �� �����
    /// </summary>
    [Test]
    public void RandomTreeTest()
    {
        for (int i = 0; i < s_numRandomTests; ++i)
        {
            // ������ Id �����, ����������� ������������� ��������������� ����� ����������
            // �������� IsMandatory
            List<PathNode> notPropagatedMandatories = new();

            // ��������� ������������ ������������ ����� ������� �� Id
            // <������, ��������� ������������ Id> 
            Dictionary<PathNode, int> parents = new();

            // ��� �������������� ���� ������� ����� ��� �������� � Id
            // ����� ��� ��������� ���������� ����
            Dictionary<int, HashSet<string>> usedNames = new();

            // ��������� ��� ���� ��������� ������
            Random rnd = new();

            // ���������� ����� � ������
            int count = 0;

            // ���������� ����� � ������, ����������� ������������� ��������������� ����� ����������
            // �������� IsMandatory
            int countMandatory = 0;

            // ������ �����, �� ������� ����� ������� �������
            List<StockHolder> stocks = new();

            // ������� ���������� ��� ������ ������
            Action<PathNode> pushStock = node =>
            {
                stocks.Add(new StockHolder { Stock = node, Stocks = stocks, Rnd = rnd });
            };

            Action incCount = () => ++count;
            Action incCountMandatory = () => ++countMandatory;
            Action decCount = () => --count;
            Action decCountMandatory = () => --countMandatory;

            // ������ ������, ��������� ��������, �������� ������
            PathNode root = CreateNode(
                null, 0, rnd, notPropagatedMandatories, incCount, parents, incCountMandatory,
                // � ������ ������ �� ��������� �� ���������� ����
                i == 0 ? null : pushStock,
                usedNames
            );
            if (i == 0)
            {
                // � ����� �� ������� ��������� �� ������
                stocks.Add(new StockHolder { Stock = root, Stocks = stocks, Rnd = rnd });
            }

            // ���������� ���������� �����
            int numNodes = count;
            int numMandatory = countMandatory;

            // ���������, ��� ��������� ������ ��� �������� ����� �����, ��� �������������
            Assert.That(countMandatory, Is.EqualTo(notPropagatedMandatories.Count));
            WalkAssert(root, notPropagatedMandatories, decCount, parents, decCountMandatory);
            Assert.That(count, Is.EqualTo(0));
            Assert.That(countMandatory, Is.EqualTo(0));

            // ������� ���������� IsAccessStuff �� � ������, ��� ����������
            InvalidOperationException ioex = Assert.Catch<InvalidOperationException>(
                () => parents.Keys.ToArray()[parents.Count / 2].IsAccessStuff = true
            );
            Assert.That(ioex.Message, Is.EqualTo("IsAccessStuff can be set only to root node!"));

            // ��� ���� ���������� ������� ���������� ������ � ���������
            foreach (StockHolder stock in stocks)
            {
                stock.CreateScion();
                stock.Stock.Graft(stock.Scion);
            }

            // ������� ������� � ������������� �����, ��� ����������
            if(notPropagatedMandatories.Any())
            {
                StockHolder sh = new StockHolder 
                { 
                    Stock = notPropagatedMandatories[notPropagatedMandatories.Count / 2], 
                    Stocks = stocks, 
                    Rnd = rnd 
                };
                sh.CreateScion();
                InvalidOperationException ioex1 = Assert.Catch<InvalidOperationException>(
                    () => sh.Stock.Graft(sh.Scion)
                );
                Assert.That(ioex1.Message, Is.EqualTo("Mandatory node can not have children!"));
            }

            int numAdded = stocks.Select(s => s.AddedNodes.Count).Sum();
            int countAccessStuff = 0;

            // ���������, ��� �������� ������ �������
            WalkAssertAfterGraft(root, ref count, ref countMandatory, ref countAccessStuff);
            Assert.That(count, Is.EqualTo(numNodes + numAdded));
            Assert.That(countMandatory, Is.EqualTo(numMandatory));
            Assert.That(countAccessStuff, Is.EqualTo(numAdded));
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
    /// ��������������� ����� ��� ����������� ��������
    /// </summary>
    class StockHolder
    {
        /// <summary>
        /// ������
        /// </summary>
        internal PathNode Stock { get; init; }
        /// <summary>
        /// ������ ���� ����� �������
        /// </summary>
        internal List<StockHolder> Stocks { get; init; }
        /// <summary>
        /// ��������� ������������
        /// </summary>
        internal Random Rnd { get; init; }
        /// <summary>
        /// ������
        /// </summary>
        internal PathNode Scion { get; private set; }
        /// <summary>
        /// ������ ��������� �����, ������� ����� ��������� � ���������� ������
        /// </summary>
        internal List<PathNode> AddedNodes { get; init; } = new();
        /// <summary>
        /// ��������� ������
        /// </summary>
        internal void CreateScion()
        {
            // ��� �������������� ���� ������� ����� ��� �������� � Id
            // ����� ��� ��������� ���������� ����
            Dictionary<int, HashSet<string>> usedNames = new();

            Scion = CreateSubtree(null, Stock, 0, true, usedNames);
            Scion.IsAccessStuff = true;
        }

        /// <summary>
        /// ��������� ��������� ������.
        /// ������ ������, ������� ������� ��������� ��������� � ���� ������, 
        /// ����� � ��������� ����� ���������� � ���.
        /// ���������� ������ ���������� �����������:
        /// <c>s_scionDepth</c> ����� �� <c>s_scionNumChildren</c> ������ � ����
        /// </summary>
        /// <param name="parent">
        /// ������������ ���� ������
        /// </param>
        /// <param name="stock">
        /// ��������������� ������������ ���� ������, ����� ������������ ���� ������ ��������� ���.
        /// </param>
        /// <param name="level">
        /// ������� ��������
        /// </param>
        /// <param name="copy">
        /// ��������, ����� �� ���� ������ ���� ��������� ������ (�� �������� �����)
        /// </param>
        /// <param name="usedNames">
        /// ��������������� ��� ��� ��������� ���������� ���
        /// </param>
        /// <returns>
        /// ��������� ����
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
                    // ������ ����� �� �����
                    result = new PathNode(stock.Name);
                    usedNames[parent?.Id ?? 0].Add(result.Name);
                }
                else
                {
                    result = new PathNode(string.Empty);
                }
                if (level < s_scionDepth)
                {
                    // �������� ��������� ����� ����� ���� ��������� ������, ��������� ������ �����.
                    int cnt = s_scionNumChildren;
                    if (result.Children is null)
                    {
                        result.Children = new ObservableCollection<PathNode>();
                    }
                    if (stock.Children is { })
                    {
                        int take = Rnd.Next(Math.Min(cnt, stock.Children.Count));
                        // ��������
                        foreach (PathNode node in stock.Children)
                        {
                            if (
                                take > 0
                                // �������� ����������� � ������ ������ �������!
                                && !Stocks.Any(h => h.Stock.Id == node.Id)
                                // �������� ������������ �������!
                                && (!node.IsMandatory || (bool)node.IsPropagatedMandatory!)
                            )
                            {
                                result.Children.Add(CreateSubtree(result, node, level + 1, true, usedNames));
                                --cnt;
                                --take;
                            }
                        }
                    }
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
                        // ��� ������ ���������
                        result.Children.Add(CreateSubtree(result, stock, level + 1, false, usedNames));
                    }
                }
            }
            else
            {
                // ������ ������������ ����,
                // ���������� ��� ����, ���������� ����� ����� �, ���� �������� - �����,
                // �� ����� ����� ����� ����������� ��������� ����
                string name = string.Empty;
                if (level > 0)
                {
                    for (
                        name = s_alphabet.Substring(Rnd.Next(s_alphabet.Length), 1);
                        !usedNames[parent?.Id ?? 0].Add(name);
                        name = s_alphabet.Substring(Rnd.Next(s_alphabet.Length), 1)
                    ) { }
                }
                result = new PathNode(name);
                // ���� ���� ����� �������� � �������� ������
                AddedNodes.Add(result);
                if (level < s_scionDepth)
                {
                    // ���� ������������� ���� - ���� ������������
                    if (result.Children is null)
                    {
                        result.Children = new ObservableCollection<PathNode>();
                    }
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
    /// ���������� ������� ������ � ���������
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
        if (node.IsAccessStuff)
        {
            AssertPropagationAccessStuff(node);
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
        if (node.Children is { })
        {
            Assert.That(node.Children.GroupBy(ch => ch.Name).Count(), Is.EqualTo(node.Children.Count), node.ToString());
            foreach (PathNode child in node.Children)
            {
                Assert.That(parents[child], Is.EqualTo(node.Id));
                WalkAssert(child, notPropagatedMandatories, decCount, parents, decCountMandatory);
            }
        }
    }

    /// <summary>
    /// ���������, ��� �������� <c>IsAccessStuff</c> ���������������� � �������
    /// </summary>
    /// <param name="node"></param>
    private void AssertPropagationAccessStuff(PathNode node)
    {
        Assert.That(node.IsMandatory);
        if (node.Children is { })
        {
            foreach (PathNode child in node.Children)
            {
                AssertPropagationAccessStuff(child);
            }
        }
    }

    /// <summary>
    /// ���������, ��� �������� <c>IsMandatory</c> ���������������� � �����
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
    /// ���������� ������, ���� ����� ����������
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="stocks">
    /// ������ ����� ������
    /// </param>
    /// <param name="withStocks">
    /// ���������, ����� �� ���������� ���� ������.
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
    /// �������� ���� ��������� ������
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
        Action incCountMandatory, Action<PathNode>? pushStock, Dictionary<int, HashSet<string>> usedNames
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

        // ���������� �����, ����������� � ������ �� ��� ���������� ����
        int numChildrenBefore = willHaveChildren ? rnd.Next(s_numChildrenParameter) : 0;

        // ���������� �����, ����������� � ������ ����� ��� ���������� ����
        int numChildrenAfter = willHaveChildren ?
            (numChildrenBefore == 0 ? 1 : 0) + rnd.Next(s_numChildrenParameter) : 0;

        // ���������� ���������� ��� ����� �����
        string name = string.Empty;
        if (level > 0)
        {
            for (
                name = s_alphabet.Substring(rnd.Next(s_alphabet.Length), 1);
                !usedNames[parent?.Id ?? 0].Add(name);
                name = s_alphabet.Substring(rnd.Next(s_alphabet.Length), 1)
            ) { }
            if (willBeMandatory)
            {
                name += "!";
            }

        }
        PathNode node = new(name);

        if (node.IsMandatory)
        {
            // ���������, ��� ������ ���� ��� ���� �������� ������������
            notPropagatedMandatories.Add(node);
            incCountMandatory();
        }
        // � ��������� ������������ ��������� ���� ���� ����� ������.
        // ��� �� ������ ���� ������, � ������ ����������� ��������
        if (
            level > 0 
            && pushStock is { }
            && (!node.IsMandatory || (bool)node.IsPropagatedMandatory!)
            && rnd.Next() % s_pushStockBase == 0
        )
        {
            pushStock(node);
        }

        // ��������� �������� ��������, ��� ����������� ��������
        parents.Add(node, parent is { } ? parent.Id : 0);

        incCount();

        if (willHaveChildren)
        {
            ObservableCollection<PathNode> children = new();
            for (int i = 0; i < numChildrenBefore; ++i)
            {
                children.Add(CreateNode(node, level + 1, rnd, notPropagatedMandatories, 
                    incCount, parents, incCountMandatory, pushStock, usedNames));
            }
            node.Children = children;
            for (int i = 0; i < numChildrenAfter; ++i)
            {
                children.Add(CreateNode(node, level + 1, rnd, notPropagatedMandatories, 
                    incCount, parents, incCountMandatory, pushStock, usedNames));
            }
        }
        return node;
    }
}
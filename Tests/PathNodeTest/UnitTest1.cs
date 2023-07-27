using Microsoft.AspNetCore.Http;
using Net.Leksi.Pocota.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

namespace PathNodeTest
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;
        }

        [Test]
        public void Test1()
        {
            PathNode stock;
            PathNode stock1;

            PathNode root = new()
            {
                Children = new ObservableCollection<PathNode>()
                {
                    new PathNode
                    {
                        Name = "a",
                    },
                    new PathNode
                    {
                        Name = "b",
                    },
                    (stock1 = new PathNode
                    {
                        Name = "c",
                        Children = new ObservableCollection<PathNode>()
                        {
                            (stock = new PathNode
                            {
                                Name = "d",
                                IsMandatory = true,
                                Children = new ObservableCollection<PathNode>()
                                {
                                    new PathNode
                                    {
                                        Name = "e",
                                    },
                                },
                            }),
                        },
                    }),
                },
            };

            Console.WriteLine($"root: {root}");

            PathNode scion = new PathNode
            {
                IsMandatory = true,
                IsAccessStuff = true,
                Children = new ObservableCollection<PathNode>()
                {
                    new PathNode
                    {
                        Name = "e",
                        Children = new ObservableCollection<PathNode>()
                        {
                            new PathNode
                            {
                                Name = "f",
                            },
                        },
                    },
                },
            };
            Console.WriteLine($"scion: {scion}");

            PathNode scion1 = new PathNode
            {
                IsMandatory = true,
                IsAccessStuff = true,
                Children = new ObservableCollection<PathNode>()
                {
                    new PathNode
                    {
                        Name = "d",
                        Children = new ObservableCollection<PathNode>()
                        {
                            new PathNode
                            {
                                Name = "e",
                                Children = new ObservableCollection<PathNode>()
                                {
                                    new PathNode
                                    {
                                        Name = "f",
                                    },
                                },
                            },
                        },
                    },
                },
            };
            Console.WriteLine($"scion: {scion}");
            Console.WriteLine($"scion1: {scion1}");

            stock.Graft(scion);
            stock1.Graft(scion1);

            Console.WriteLine($"root: {root}");
        }

        [Test]
        public void Test2()
        {
            for(int i = 0; i < 100; ++i)
            {
                HashSet<int> notPropagatedMandatoryById = new();
                Dictionary<int, int> parents = new();
                Dictionary<int, HashSet<string>> names = new();
                Random rnd = new();
                int count = 0;
                int countMandatory = 0;
                List<StockHolder> stocks = new();

                Action<PathNode> pushStock = node =>
                {
                    stocks.Add(new StockHolder { Stock = node, Stocks = stocks, Rnd = rnd });
                };

                PathNode root = CreatePathNode(null, 0, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, i == 0 ? null : pushStock, names);
                if(i == 0)
                {
                    stocks.Add(new StockHolder { Stock = root, Stocks = stocks, Rnd = rnd });
                }

                int numNodes = count;
                int numMandatory = countMandatory;

                Assert.That(countMandatory, Is.EqualTo(notPropagatedMandatoryById.Count));

                WalkAssert(root, root, notPropagatedMandatoryById, ref count, parents, ref countMandatory);
                Assert.That(count, Is.EqualTo(0));
                Assert.That(countMandatory, Is.EqualTo(0));

                //root.PropertyChanged += Root_PropertyChanged;

                foreach(StockHolder stock in stocks)
                {
                    stock.CreateScion();
                    stock.Stock.Graft(stock.Scion);
                }
                int numAdded = stocks.Select(s => s.AddedNodes.Count).Sum();
                int countAccessStuff = 0;

                WalkAssertAfterGraft(root, ref count, ref countMandatory, ref countAccessStuff);

                Assert.That(count, Is.EqualTo(numNodes + numAdded));
                Assert.That(countMandatory, Is.EqualTo(numMandatory));
                Assert.That(countAccessStuff, Is.EqualTo(numAdded));
            }
        }

        private void WalkAssertAfterGraft(PathNode tree, ref int count, ref int countMandatory, ref int countAccessStuff)
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
            if(tree.Children is { })
            {
                foreach(PathNode child in tree.Children)
                {
                    WalkAssertAfterGraft(child, ref count, ref countMandatory, ref countAccessStuff);
                }
            }
        }

        private void Root_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }

        class StockHolder
        {
            internal PathNode Stock { get; init; }
            internal List<StockHolder> Stocks { get; init; }
            internal Random Rnd { get; init; }
            internal PathNode Scion { get; private set; }
            internal List<PathNode> AddedNodes { get; init; } = new();
            internal void CreateScion()
            {
                Dictionary<int, HashSet<string>> names = new();
                Scion = CreateLevel(null, Stock, 0, true, names);
                Scion.IsAccessStuff = true;
            }

            private PathNode CreateLevel(PathNode? parent, PathNode stock, int level, bool copy, Dictionary<int, HashSet<string>> names)
            {
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                PathNode result = new();

                if (!names.ContainsKey(parent?.Id ?? 0))
                {
                    names.Add(parent?.Id ?? 0, new HashSet<string>());
                }
                if (copy)
                {
                    if(level > 0)
                    {
                        result.Name = stock.Name;
                        names[parent?.Id ?? 0].Add(result.Name);
                    }
                    if (level < 3)
                    {
                        int cnt = 3;
                        if (result.Children is null)
                        {
                            result.Children = new ObservableCollection<PathNode>();
                        }
                        if(stock.Children is { })
                        {
                            int take = Rnd.Next(3);
                            foreach (PathNode node in stock.Children)
                            {
                                if(take > 0 && !Stocks.Any(h => h.Stock.Id == node.Id))
                                {
                                    result.Children.Add(CreateLevel(result, node, level + 1, true, names));
                                    --cnt;
                                    --take;
                                }
                            }
                        }
                        if(stock.Children is { })
                        {
                            if (!names.ContainsKey(result.Id))
                            {
                                names.Add(result.Id, new HashSet<string>());
                            }
                            foreach(PathNode child in stock.Children)
                            {
                                names[result.Id].Add(child.Name);
                            }
                        }
                        for (int i = 0; i < cnt; ++i)
                        {
                            result.Children.Add(CreateLevel(result, stock, level + 1, false, names));
                        }
                    }
                }
                else
                {
                    string name = string.Empty;
                    if (level > 0)
                    {
                        for (
                            name = alphabet.Substring(Rnd.Next(alphabet.Length), 1);
                            !names[parent?.Id ?? 0].Add(name);
                            name = alphabet.Substring(Rnd.Next(alphabet.Length), 1)
                        ) { }
                    }
                    result.Name = name;
                    AddedNodes.Add(result);
                    if(level < 3)
                    {
                        if (result.Children is null)
                        {
                            result.Children = new ObservableCollection<PathNode>();
                        }
                        for (int i = 0; i < 3; ++i)
                        {
                            result.Children.Add(CreateLevel(result, result, level + 1, false, names));
                        }
                    }
                }

                return result;
            }
        }

        private void WalkAssert(PathNode root, PathNode node, HashSet<int> notPropagatedMandatoryById, ref int count, Dictionary<int, int> parents, ref int countMandatory)
        {
            Assert.That(node.IsPropagatedMandatory is { }, Is.EqualTo(node.IsMandatory == true));
            if(node.IsPropagatedMandatory is { })
            {
                if (node.IsMandatory)
                {
                    if (!(bool)node.IsPropagatedMandatory)
                    {
                        --countMandatory;
                    }
                }
                AssertPropagationMandatory(node);
                Assert.That(notPropagatedMandatoryById.Contains(node.Id), Is.EqualTo(!node.IsPropagatedMandatory));
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
                Assert.That(node.Path, Is.EqualTo($"{node.Parent.Path}.{node.Name}"), root.ToString());
            }
            --count;
            if(node.Children is { })
            {
                Assert.That(node.Children.GroupBy(ch => ch.Name).Count(), Is.EqualTo(node.Children.Count), node.ToString());
                foreach(PathNode child in node.Children)
                {
                    Assert.That(parents[child.Id], Is.EqualTo(node.Id));
                    WalkAssert(root, child, notPropagatedMandatoryById, ref count, parents, ref countMandatory);
                }
            }
        }

        private void AssertPropagationMandatory(PathNode node)
        {
            Assert.That(node.IsMandatory);
            if (node.Parent is { })
            {
                AssertPropagationMandatory(node.Parent);
            }
        }

        private void PrintTree(PathNode tree, List<StockHolder> stocks, bool withStocks)
        {
            if(withStocks)
            {
                string[] path = tree.Path.Split('.');
                foreach(StockHolder stock in stocks.Where(s => s.Stock.Path.Length > 0 && tree.Path.StartsWith(s.Stock.Path)))
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

        private PathNode CreatePathNode(
            PathNode? parent, int level, Random rnd, HashSet<int> notPropagatedMandatoryById, ref int count, Dictionary<int, int> parents, 
            ref int countMandatory, Action<PathNode>? pushStock, Dictionary<int, HashSet<string>> names
        )
        {
            if (!names.ContainsKey(parent?.Id ?? 0))
            {
                names.Add(parent?.Id ?? 0, new HashSet<string>());
            }
            int pushStockBase = 3;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            bool hasChildren = level == 0 || (level < 5 && rnd.Next() % 3 != 0);
            bool isMandatory = rnd.Next() % 5 != 0;
            int numChildrenBefore = hasChildren ? rnd.Next(3) : 0;
            int numChildrenAfter = hasChildren ? (numChildrenBefore == 0 ? 1 : 0) + rnd.Next(3) : 0;
            int nameSettingCase = rnd.Next(hasChildren ? 4 : 2);
            string name = string.Empty;
            if(level > 0)
            {
                for (
                    name = alphabet.Substring(rnd.Next(alphabet.Length), 1);
                    !names[parent?.Id ?? 0].Add(name);
                    name = alphabet.Substring(rnd.Next(alphabet.Length), 1)
                ) { }
            }
            PathNode node = nameSettingCase == 0 ? new()
            {
                Name = name,
            } : new();
            if(level > 0 && pushStock is { } && rnd.Next() % pushStockBase == 0)
            {
                pushStock(node);
                //pushStock = null;
            }
            parents.Add(node.Id, parent is { } ? parent.Id : 0);
            ++count;
            if (isMandatory)
            {
                node.IsMandatory = true;
                notPropagatedMandatoryById.Add(node.Id);
                ++countMandatory;
            }
            if(nameSettingCase == 1)
            {
                node.Name = name;
            }
            if (hasChildren)
            {
                Action<PathNode>? pushStockNext = pushStock;// is { } && rnd.Next() % 3 == 0 ? pushStock : null;
                ObservableCollection <PathNode> children = new();
                for(int i = 0; i < numChildrenBefore; ++i)
                {
                    children.Add(CreatePathNode(node, level + 1, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, pushStockNext, names));
                }
                node.Children = children;
                if (nameSettingCase == 2)
                {
                    node.Name = name;
                }
                for (int i = 0; i < numChildrenAfter; ++i)
                {
                    children.Add(CreatePathNode(node, level + 1, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, pushStockNext, names));
                }
                if (nameSettingCase == 3)
                {
                    node.Name = name;
                }
            }
            return node;
        }
    }
}
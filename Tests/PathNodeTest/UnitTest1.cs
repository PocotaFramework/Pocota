using Net.Leksi.Pocota.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;

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
                    new PathNode
                    {
                        Name = "c",
                        Children = new ObservableCollection<PathNode>()
                        {
                            new PathNode
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
                            },
                        },
                    },
                },
            };

            Console.WriteLine(root);
        }

        [Test]
        public void Test2()
        {
            for(int i = 0; i < 10; ++i)
            {
                HashSet<int> notPropagatedMandatoryById = new();
                Dictionary<int, int> parents = new();
                Random rnd = new();
                int count = 0;
                int countMandatory = 0;

                int rootAccessStuffCase = rnd.Next(4);
                PathNode root = CreatePathNode(null, 0, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, rootAccessStuffCase);
                if (rootAccessStuffCase == 3)
                {
                    root.IsAccessStuff = true;
                }


                Assert.That(countMandatory, Is.EqualTo(notPropagatedMandatoryById.Count));

                WalkAssert(root, root, notPropagatedMandatoryById, ref count, parents, ref countMandatory, rootAccessStuffCase);
                Assert.That(count, Is.EqualTo(0));
                Assert.That(countMandatory, Is.EqualTo(0));
            }
        }

        private void WalkAssert(PathNode root, PathNode node, HashSet<int> notPropagatedMandatoryById, ref int count, Dictionary<int, int> parents, ref int countMandatory, int rootAccessStuffCase)
        {
            Assert.That(node.IsAccessStuff, Is.EqualTo(rootAccessStuffCase > 1));
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
                foreach(PathNode child in node.Children)
                {
                    Assert.That(parents[child.Id], Is.EqualTo(node.Id));
                    WalkAssert(root, child, notPropagatedMandatoryById, ref count, parents, ref countMandatory, rootAccessStuffCase);
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

        private PathNode CreatePathNode(PathNode? parent, int level, Random rnd, HashSet<int> notPropagatedMandatoryById, ref int count, Dictionary<int, int> parents, ref int countMandatory, int rootAccessStuffCase)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            bool hasChildren = level == 0 || (level < 10 && rnd.Next() % 3 != 0);
            StringBuilder sbName = new();
            int nameLength = level == 0 ? 0 : 3 + rnd.Next(5);
            for(int i = 0; i < nameLength; ++i)
            {
                sbName.Append(alphabet[rnd.Next(alphabet.Length)]);
            }
            bool isMandatory = rnd.Next() % 5 != 0;
            int numChildrenBefore = hasChildren ? rnd.Next(3) : 0;
            int numChildrenAfter = hasChildren ? (numChildrenBefore == 0 ? 1 : 0) + rnd.Next(3) : 0;
            int nameSettingCase = rnd.Next(hasChildren ? 4 : 2);
            PathNode node = nameSettingCase == 0 ? new()
            {
                Name = sbName.ToString(),
            } : new();
            if(level == 0 && rootAccessStuffCase == 2)
            {
                node.IsAccessStuff = true;
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
                node.Name = sbName.ToString();
            }
            if (hasChildren)
            {
                ObservableCollection<PathNode> children = new();
                for(int i = 0; i < numChildrenBefore; ++i)
                {
                    children.Add(CreatePathNode(node, level + 1, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, 0));
                }
                node.Children = children;
                if (nameSettingCase == 2)
                {
                    node.Name = sbName.ToString();
                }
                for (int i = 0; i < numChildrenAfter; ++i)
                {
                    children.Add(CreatePathNode(node, level + 1, rnd, notPropagatedMandatoryById, ref count, parents, ref countMandatory, 0));
                }
                if (nameSettingCase == 3)
                {
                    node.Name = sbName.ToString();
                }
            }
            return node;
        }
    }
}
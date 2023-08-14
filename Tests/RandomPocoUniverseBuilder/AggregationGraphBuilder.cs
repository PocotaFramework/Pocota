using System.Xml.Linq;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverseBuilder;

internal class AggregationGraphBuilder
{
    private const int s_numTreeChildren = 3;
    private const int s_maxLevel = 3;
    private const int s_maxChildren = 10;

    internal PocoUniverse Build(Random random)
    {
        PocoUniverse result = new();
        
        result.Root = BuildTree(null, random, 0);

        ExtendToGraph(result, random);

        return result;
    }

    private void ExtendToGraph(PocoUniverse universe, Random random)
    {
        Dictionary<Node, List<Node>> indirectDependents = new();

        foreach (Node node in universe.Nodes)
        {
            if (node.Parent is { })
            {
                indirectDependents.Add(node, new List<Node>() { node.Parent });
            }
        }

        List<Node> nodesToFindAliens = universe.Nodes.ToList();
        bool changed = true;
        while (changed)
        {
            changed = false;
            for (int i = nodesToFindAliens.Count - 1; i >= 0; --i)
            {
                List<Node> aliens = universe.Nodes.Where(n => !nodesToFindAliens[i].Children.Contains(n)).ToList();
                WalkDependents(nodesToFindAliens[i], aliens, indirectDependents);
                if (!aliens.Any())
                {
                    nodesToFindAliens.RemoveAt(i);
                }
                else
                {
                    int pos = random.Next(aliens.Count);
                    nodesToFindAliens[i].Children.Add(aliens[pos]);
                    if (!indirectDependents.ContainsKey(aliens[pos]))
                    {
                        indirectDependents.Add(aliens[pos], new List<Node>());
                    }
                    indirectDependents[aliens[pos]].Add(nodesToFindAliens[i]);
                    if (aliens.Count == 1 || nodesToFindAliens[i].Children.Count >= s_maxChildren)
                    {
                        nodesToFindAliens.RemoveAt(i);
                    }
                    changed = true;
                }
            }
        }
    }

    private static void WalkDependents(Node node, List<Node> aliens, Dictionary<Node, List<Node>> indirectDependents)
    {
        aliens.Remove(node);
        if (indirectDependents.TryGetValue(node, out List<Node>? indDeps))
        {
            indDeps.ForEach(e => WalkDependents(e, aliens, indirectDependents));
        }
    }

    private Node BuildTree(Node? parent, Random random, int level)
    {
        Node result = new Node
        {
            Parent = parent,
        };
        if (level < s_maxLevel)
        {
            for (int i = 0; i < s_numTreeChildren; ++i)
            {
                result.Children.Add(BuildTree(result, random, level + 1));
            }
        }
        return result;
    }
}

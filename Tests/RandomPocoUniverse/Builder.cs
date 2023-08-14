using System.Data;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Builder
{
    private const int s_numNodes = 20;
    private const int s_minReferences = 3;
    private const int s_maxReferences = 10;
    private const int s_baseCycleReferenced = 3;
    private const int s_basePkFk = 2;
    private const int s_baseManyToMany = 10;

    public static Universe Build(Random random)
    {
        Universe result = new();

        CreateNodes(result, random);

        CreateDataSet(result, random);

        CreateSql(result);

        return result;
    }

    private static void CreateSql(Universe universe)
    {
        StringBuilder sb = new();

        foreach (DataTable table in universe.DataSet.Tables)
        {
            sb.Append("create table ").Append(table.TableName).AppendLine("(");
            foreach (DataColumn col in table.Columns)
            {
                sb.Append("    ").Append(col.ColumnName).Append(" ").Append(DbDataType(col.DataType));
                if (!col.AllowDBNull)
                {
                    sb.Append(" not null");
                }
                sb.AppendLine(",");
            }
            sb.AppendLine(")").AppendLine("go");
        }
        foreach (DataTable table in universe.DataSet.Tables)
        {
            foreach (Constraint constraint in table.Constraints)
            {
                if (constraint is UniqueConstraint uc && uc.IsPrimaryKey)
                {
                    sb.Append("alter table ").Append(table.TableName).Append(" add constraint ").Append(table.TableName).Append("_").Append(constraint.ConstraintName).Append(" ");
                    sb.Append("primary key (").Append(string.Join(", ", uc.Columns.Select(c => c.ColumnName))).AppendLine(")");
                    sb.AppendLine("go");
                }
            }
        }
        foreach (DataTable table in universe.DataSet.Tables)
        {
            foreach (Constraint constraint in table.Constraints)
            {
                if (constraint is ForeignKeyConstraint fk)
                {
                    sb.Append("alter table ").Append(table.TableName).Append(" add constraint ").Append(constraint.ConstraintName).Append(" ");
                    sb.Append("foreign key (").Append(string.Join(", ", fk.Columns.Select(c => c.ColumnName))).AppendLine(")");
                    sb.Append("    references ").Append(fk.RelatedTable.TableName).Append(" (").Append(string.Join(", ", fk.RelatedColumns.Select(c => c.ColumnName))).AppendLine(")");
                    sb.AppendLine("go");
                }
            }
        }

        universe.Sql = sb.ToString();
    }

    private static string DbDataType(Type dataType)
    {
        if (dataType == typeof(int)) return "int";
        return dataType.ToString();
    }

    private static void CreateNodes(Universe universe, Random random)
    {
        for (int i = 0; i < s_numNodes; ++i)
        {
            universe.Nodes.Add(new Node { });
        }
        List<Node> manyToManyLinks = new();
        for (int i = 0; i < s_numNodes; ++i)
        {
            List<Node> list = universe.Nodes.Where(n => n.NodeType is not NodeType.ManyToManyLink).ToList();
            int numReferences = s_minReferences + random.Next(s_maxReferences - s_minReferences + 1);
            for (int j = 0; j < numReferences; ++j)
            {
                int pos = random.Next(list.Count);
                if (
                    universe.Nodes[i] != list[pos]
                    && !universe.Nodes[i].References.Any(n => list[pos].References.Contains(n))
                    && random.Next(s_baseManyToMany) == 0
                )
                {
                    Node link = new()
                    {
                        NodeType = NodeType.ManyToManyLink,
                    };
                    link.References.Add(universe.Nodes[i]);
                    universe.Nodes[i].Referencers.Add(link);
                    link.References.Add(list[pos]);
                    list[pos].Referencers.Add(link);
                    universe.Nodes.Add(link);
                }
                else
                {
                    universe.Nodes[i].References.Add(list[pos]);
                    list[pos].Referencers.Add(universe.Nodes[i]);
                }
                list.RemoveAt(pos);
            }
        }
        for (int i = 0; i < s_numNodes; ++i)
        {
            HashSet<Node> set = new();
            if (!IsLooped(universe.Nodes[i], universe.Nodes[i], string.Empty, set) && random.Next(s_baseCycleReferenced) == 0)
            {
                foreach (Node probe in universe.Nodes.Where(n => n.NodeType is not NodeType.ManyToManyLink && !set.Contains(n)))
                {
                    if (IsLooped(universe.Nodes[i], probe, $"/{universe.Nodes[i].Id}", null))
                    {
                        universe.Nodes[i].References.Add(probe);
                        probe.Referencers.Add(universe.Nodes[i]);
                        break;
                    }
                }
            }
        }
    }

    private static bool IsLooped(Node node, Node currentNode, string path, HashSet<Node>? set)
    {
        if (currentNode == node)
        {
            return true;
        }
        if (path.Contains($"/{currentNode.Id}"))
        {
            return false;
        }
        set?.Add(currentNode);
        return currentNode.References.Any(n => IsLooped(node, n, $"{path}/{currentNode.Id}", set));
    }

    private static void CreateDataSet(Universe universe, Random random)
    {
        // Для каждого узла создаём таблицу и задаём 1-2 первичных ключа
        foreach (Node node in universe.Nodes)
        {
            DataTable table = new DataTable($"Table{node.Id}");
            universe.DataSet.Tables.Add(table);
            if (node.NodeType is not NodeType.ManyToManyLink)
            {
                int pkCount = 1 + random.Next(2);
                List<DataColumn> pk = new();
                for (int i = 0; i < pkCount; ++i)
                {
                    DataColumn part = new()
                    {
                        DataType = typeof(int),
                        ColumnName = $"Id{i}",
                    };
                    pk.Add(part);
                    table.Columns.Add(part);
                }
                table.PrimaryKey = pk.ToArray();
            }
        }
        // Для каждой таблицы задаём ссылочные ключи
        foreach (Node node in universe.Nodes)
        {
            //Console.WriteLine($"{node.Id}: {node.NodeType}");
            DataTable table = universe.DataSet.Tables[$"Table{node.Id}"]!;
            foreach (Node reference in node.References)
            {
                //Console.WriteLine($"    {reference.Id}: {reference.NodeType}");
                DataTable relatedTable = universe.DataSet.Tables[$"Table{reference.Id}"]!;
                List<DataColumn> fk = new();
                foreach (DataColumn part in relatedTable.PrimaryKey)
                {
                    DataColumn fkPart = new()
                    {
                        DataType = part.DataType,
                        ColumnName = $"{relatedTable.TableName}{part.ColumnName}",
                    };
                    fk.Add(fkPart);
                    table.Columns.Add(fkPart);
                }
                table.Constraints.Add($"fk_{table.TableName}_{relatedTable.TableName}", relatedTable.PrimaryKey, fk.ToArray());
            }
        }
        // в некоторые таблицы добавляем ещё первичный ключ из числа ссылок
        foreach (Node node in universe.Nodes.Where(n => n.NodeType is not NodeType.ManyToManyLink))
        {
            DataTable table = universe.DataSet.Tables[$"Table{node.Id}"]!;
            List<DataColumn> allFkParts = new();
            foreach (Constraint constraint in table.Constraints)
            {
                if (constraint is ForeignKeyConstraint fk)
                {
                    allFkParts.AddRange(fk.Columns);
                }
            }

            if (allFkParts.Any() && random.Next(s_basePkFk) == 0)
            {
                DataColumn chosen = allFkParts[random.Next(allFkParts.Count)];
                foreach (Node referring in node.Referencers)
                {
                    DataTable referringTable = universe.DataSet.Tables[$"Table{referring.Id}"]!;
                    ForeignKeyConstraint fk = (referringTable.Constraints[$"fk_{referringTable.TableName}_{table.TableName}"] as ForeignKeyConstraint)!;
                    referringTable.Constraints.Remove(fk);
                }
                table.PrimaryKey = table.PrimaryKey.Concat(new DataColumn[] { chosen }).ToArray();
                foreach (Node referring in node.Referencers)
                {
                    DataTable referringTable = universe.DataSet.Tables[$"Table{referring.Id}"]!;
                    List<DataColumn> fk = new();
                    foreach (DataColumn part in table.PrimaryKey)
                    {
                        if (!(referringTable.Columns[$"{table.TableName}{part.ColumnName}"] is DataColumn fkPart))
                        {
                            fkPart = new()
                            {
                                DataType = part.DataType,
                                ColumnName = $"{table.TableName}{part.ColumnName}",
                            };
                            referringTable.Columns.Add(fkPart);
                        }
                        fk.Add(fkPart);
                    }
                    referringTable.Constraints.Add($"fk_{referringTable.TableName}_{table.TableName}", table.PrimaryKey, fk.ToArray());
                }
            }
        }
        foreach (Node node in universe.Nodes.Where(n => n.NodeType is NodeType.ManyToManyLink))
        {
            DataTable table = universe.DataSet.Tables[$"Table{node.Id}"]!;
            List<DataColumn> allFkParts = new();
            foreach (Constraint constraint in table.Constraints)
            {
                if (constraint is ForeignKeyConstraint fk)
                {
                    foreach(DataColumn col in fk.Columns)
                    {
                        if (!allFkParts.Contains(col))
                        {
                            allFkParts.Add(col);
                        }
                    }
                }
            }
            if (allFkParts.Any())
            {
                table.PrimaryKey = allFkParts.ToArray();
            }
        }
    }

}
using System.Data;
using System.Text;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Builder
{
    private const int s_numNodes = 20;
    private const int s_minReferences = 3;
    private const int s_maxReferences = 10;
    private const int s_baseCycleReferenced = 3;
    private const double s_fraqManyToMany = .2;
    private const int s_maxKeyParts = 2;
    private const int s_maxEntitiesAtEnvelop = 2;
    private const int s_baseCollection = 5;
    private const int s_baseReadonly = 7;
    private const int s_baseNullable = 3;
    private const int s_basePrimaryKeyPart = 11;
    private const int s_minOtherProperties = 3;
    private const int s_maxOtherProperties = 10;
    private const int s_maxFkPk = 3;

    public static Universe Build(Random random)
    {
        Universe result = new();

        CreateNodes(result.Entities, random, true);

        CreateKeys(result, random);

        //Console.WriteLine(string.Join('\n', result.Entities));

        CreateDataSet(result, random);

        CreateSql(result);

        CreateNodes(result.Envelopes, random, false);

        CompleteEnvelopes(result, random);

        return result;
    }

    private static void CreateKeys(Universe universe, Random random)
    {
        foreach (EntityNode node in universe.Entities)
        {
            CreatePrimaryKey(node, random);
        }
        foreach (EntityNode node in universe.Entities)
        {
            CreateForeignKeys(node, random);
        }
        foreach (EntityNode node in universe.Entities.Where(n => n.NodeType is not NodeType.ManyToManyLink))
        {
            CreateFkPk(node, random);
        }
    }

    private static void CreateFkPk(EntityNode node, Random random)
    {
        int numAddPk = (node.PrimaryKey.Any() ? 0 : 1) + random.Next(s_maxFkPk + (node.PrimaryKey.Any() ? 1 : 0));
        if(numAddPk > 0)
        {
            List<PropertyDescriptor> candidates = node.Properties.Where(p => p.Node is { } && p.Node != node && !p.IsCollection).SelectMany(p => p.References!).ToList();
            for(int i = 0; i < numAddPk && candidates.Any(); ++i)
            {
                int pos = random.Next(candidates.Count);
                candidates[pos].IsPrimaryKeyPart = true;
                node.PrimaryKey!.Add(candidates[pos]);
                candidates.RemoveAt(pos);
            }
            foreach(EntityNode referenser in node.Referencers)
            {
                foreach(PropertyDescriptor pd in referenser.Properties.Where(p => p.Node == node && !p.IsCollection))
                {
                    for(int i = pd.References!.Count; i < node.PrimaryKey.Count; ++i)
                    {
                        pd.References.Add(new PropertyDescriptor
                        {
                            Name = $"{pd.Name}{node.PrimaryKey[i].Name}",
                            Type = node.PrimaryKey[i].Type,
                            IsReadOnly = pd.IsReadOnly,
                            IsNullable = pd.IsNullable,
                        });
                    }
                }
            }
        }
    }

    private static void CreateForeignKeys(EntityNode node, Random random)
    {
        foreach (PropertyDescriptor pd in node.Properties.Where(p => p.Node is { } && !p.IsCollection))
        {
            if (pd.Node is EntityNode entityNode)
            {
                pd.References = new List<PropertyDescriptor>(entityNode.PrimaryKey!.Select(p => new PropertyDescriptor
                {
                    Name = $"{pd.Name}{p.Name}",
                    Type = p.Type,
                    IsReadOnly = pd.IsReadOnly,
                    IsNullable = pd.IsNullable,
                }));
                if (node.NodeType is NodeType.ManyToManyLink)
                {
                    node.PrimaryKey!.AddRange(pd.References);
                }
            }
        }
    }

    private static void CreatePrimaryKey(EntityNode node, Random random)
    {
        if(node.NodeType is NodeType.Entity)
        {
            int pkCount = random.Next(s_maxKeyParts + 1);
            foreach (PropertyDescriptor pd in node.Properties.Where(p => p.IsPrimaryKeyPart))
            {
                node.PrimaryKey.Add(pd);
            }
            for (int i = node.PrimaryKey.Count; i < pkCount; ++i)
            {
                node.PrimaryKey.Add(new PropertyDescriptor
                {
                    Name = $"Id{i}",
                    Type = typeof(int),
                    IsNullable = false,
                    IsCollection = false,
                    IsReadOnly = true,
                    IsPrimaryKeyPart = true,
                });
            }
        }
    }

    private static void CompleteEnvelopes(Universe universe, Random random)
    {
        foreach (Node node in universe.Envelopes)
        {
            int numEntities = 1 + random.Next(s_maxEntitiesAtEnvelop);
            for(int i =  0; i < numEntities; ++i)
            {
                Node entity = universe.Entities[random.Next(universe.Entities.Count)];
                if (!node.References.Contains(entity))
                {
                    node.References.Add(entity);
                }
            }
            node.NodeType = NodeType.Envelope;
        }
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
        if (dataType == typeof(string)) return "varchar(50)";
        return dataType.ToString();
    }

    private static void CreateNodes<T>(List<T> nodes, Random random, bool areEntities) where T : Node, new()
    {
        for (int i = 0; i < s_numNodes; ++i)
        {
            nodes.Add(new T());
        }
        List<Node> manyToManyLinks = new();
        for (int i = 0; i < s_numNodes; ++i)
        {
            List<T> list = nodes.Where(n => n.NodeType is not NodeType.ManyToManyLink).ToList();
            int numReferences = s_minReferences + random.Next(s_maxReferences - s_minReferences + 1);
            for (int j = 0; j < numReferences; ++j)
            {
                int pos = random.Next(list.Count);
                if (
                    areEntities
                    && nodes[i] != list[pos]
                    && !nodes[i].References.Any(n => list[pos].References.Contains(n))
                    && random.Next(1 + (int)Math.Ceiling(s_fraqManyToMany * s_numNodes * (s_maxReferences + s_minReferences) * .25)) == 0
                )
                {
                    T link = new()
                    {
                        NodeType = NodeType.ManyToManyLink,
                    };
                    link.References.Add(nodes[i]);
                    nodes[i].Referencers.Add(link);
                    link.References.Add(list[pos]);
                    list[pos].Referencers.Add(link);
                    nodes.Add(link);
                    if(random.Next(s_baseCollection) == 0)
                    {
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{list[pos].Properties.Count}",
                            Node = nodes[i],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = random.Next(s_baseNullable) == 0,
                        };
                        list[pos].Properties.Add(pd1);
                    }
                    if (random.Next(s_baseCollection) == 0)
                    {
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{nodes[i].Properties.Count}",
                            Node = list[pos],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = random.Next(s_baseNullable) == 0,
                        };
                        nodes[i].Properties.Add(pd1);
                    }
                    link.Properties.Add(new PropertyDescriptor
                    {
                        Name = $"P{link.Properties.Count}",
                        Node = nodes[i],
                        IsReadOnly = true,
                        IsNullable = false,
                        IsCollection = false,
                    });
                    link.Properties.Add(new PropertyDescriptor
                    {
                        Name = $"P{link.Properties.Count}",
                        Node = list[pos],
                        IsReadOnly = true,
                        IsNullable = false,
                        IsCollection = false,
                    });
                }
                else
                {
                    nodes[i].References.Add(list[pos]);
                    list[pos].Referencers.Add(nodes[i]);
                    PropertyDescriptor pd = new()
                    {
                        Name = $"P{nodes[i].Properties.Count}",
                        Node = list[pos],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsNullable = random.Next(s_baseNullable) == 0,
                    };
                    nodes[i].Properties.Add(pd);
                    if (random.Next(s_baseCollection) == 0)
                    {
                        if (!areEntities)
                        {
                            pd.IsCollection = true;
                        }
                        else
                        {
                            PropertyDescriptor pd1 = new()
                            {
                                Name = $"P{list[pos].Properties.Count}",
                                Node = nodes[i],
                                IsReadOnly = random.Next(s_baseReadonly) == 0,
                                IsCollection = true,
                                IsNullable = random.Next(s_baseNullable) == 0,
                            };
                            list[pos].Properties.Add(pd1);
                        }
                    }
                }
            }
            int numOtherProperties = s_minOtherProperties + random.Next(s_maxOtherProperties - s_minOtherProperties + 1);
            for(int j = 0; j < numOtherProperties; ++j)
            {
                bool isPrimaryKeyPart = areEntities && random.Next(s_basePrimaryKeyPart) == 0;
                PropertyDescriptor pd = new()
                {
                    Name = $"P{nodes[i].Properties.Count}",
                    Type = typeof(string),
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsCollection = false,
                    IsNullable = !isPrimaryKeyPart && random.Next(s_baseNullable) == 0,
                    IsPrimaryKeyPart = isPrimaryKeyPart,
                };
                nodes[i].Properties.Add(pd);
            }
        }
        for (int i = 0; i < s_numNodes; ++i)
        {
            HashSet<Node> set = new();
            if (!IsLooped(nodes[i], nodes[i], string.Empty, set) && random.Next(s_baseCycleReferenced) == 0)
            {
                foreach (Node probe in nodes.Where(n => n.NodeType is not NodeType.ManyToManyLink && !set.Contains(n)))
                {
                    if (IsLooped(nodes[i], probe, $"/{nodes[i].Id}", null))
                    {
                        nodes[i].References.Add(probe);
                        probe.Referencers.Add(nodes[i]);
                        PropertyDescriptor pd = new()
                        {
                            Name = $"P{nodes[i].Properties.Count}",
                            Node = probe,
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsNullable = random.Next(s_baseNullable) == 0,
                        };
                        nodes[i].Properties.Add(pd);
                        if (random.Next(s_baseCollection) == 0)
                        {
                            if (!areEntities)
                            {
                                pd.IsCollection = true;
                            }
                            else
                            {
                                PropertyDescriptor pd1 = new()
                                {
                                    Name = $"P{probe.Properties.Count}",
                                    Node = nodes[i],
                                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                                    IsCollection = true,
                                    IsNullable = random.Next(s_baseNullable) == 0,
                                };
                                probe.Properties.Add(pd1);
                            }
                        }
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
        foreach (EntityNode node in universe.Entities)
        {
            DataTable table = new DataTable($"Table{node.Id}");
            universe.DataSet.Tables.Add(table);
            List<DataColumn> pk = new();
            foreach(PropertyDescriptor pd in node.PrimaryKey!)
            {
                DataColumn col = new DataColumn
                {
                    ColumnName = pd.Name,
                    DataType = pd.Type,
                    AllowDBNull = false,
                };
                pk.Add(col);
                table.Columns.Add(col);
            }

            foreach(PropertyDescriptor pd in node.Properties.Where(p => !p.IsCollection && !node.PrimaryKey!.Contains(p)))
            {
                if(pd.Node is EntityNode entityNode)
                {
                    foreach (PropertyDescriptor reference in pd.References!.Where(p => !node.PrimaryKey.Contains(p)))
                    {
                        DataColumn col = new DataColumn
                        {
                            ColumnName = reference.Name,
                            DataType = reference.Type,
                            AllowDBNull = reference.IsNullable,
                        };
                        table.Columns.Add(col);
                        if (reference.IsPrimaryKeyPart)
                        {
                            pk.Add(col);
                        }
                    }
                }
                else
                {
                    DataColumn col = new DataColumn
                    {
                        ColumnName = pd.Name,
                        DataType = pd.Type,
                        AllowDBNull = pd.IsNullable,
                    };
                    table.Columns.Add(col);
                    if (pd.IsPrimaryKeyPart)
                    {
                        pk.Add(col);
                    }
                }
            }

            table.PrimaryKey = pk.ToArray();
        }
        foreach (EntityNode node in universe.Entities)
        {
            DataTable table = universe.DataSet.Tables[$"Table{node.Id}"]!;
            foreach (PropertyDescriptor pd in node.Properties.Where(p => p.Node is { } && !p.IsCollection))
            {
                DataTable relatedTable = universe.DataSet.Tables[$"Table{pd.Node!.Id}"]!;
                //Console.WriteLine($"{table}, [{string.Join(',', pd.References!)}], {relatedTable}, [{string.Join<DataColumn>(',', relatedTable.PrimaryKey)}]");
                table.Constraints.Add(
                    new ForeignKeyConstraint(
                        $"fk_{table.TableName}_{pd.Name}_{relatedTable.TableName}",
                        relatedTable.PrimaryKey,
                        pd.References!.Select(p => table.Columns[p.Name]!).ToArray()
                    )
                );
            }
        }
    }

}
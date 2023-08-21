﻿using Microsoft.Data.SqlClient;
using Net.Leksi.Pocota.Common;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Data;
using System.Reflection;
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
    private const int s_baseAccessProperty = 2;
    private const int s_maxAccessProperties = 10;
    private const int s_maxExtenders = 3;
    private const int s_maxExtenderAdditionalProperties = 3;

    private readonly static Type[] s_terminalTypes = new Type[]
    {
        typeof(int),
        typeof(string),
        typeof(bool),
        typeof(DateTime),
        typeof(Enum),
    };

    public static UniverseOptions UniverseOptions { get; private set; } = new();

    public static Universe Build(Random random)
    {
        Universe result = new();

        CreateNodes(result.Entities, random, true);

        CreateKeys(result, random);

        CompleteEntities(result, random);

        CreateExtenders(result, random);

        CreateDataSet(result, random);

        CreateSql(result);

        CreateDatabase(result);

        //Console.WriteLine(string.Join('\n', result.Entities));

        CreateNodes(result.Envelopes, random, false);

        CompleteEnvelopes(result, random);

        GenerateModelAndContract(result);

        GenerateClasses(result);

        return result;
    }

    private static void CreateExtenders(Universe universe, Random random)
    {
        foreach(EntityNode entity in universe.Entities)
        {
            int numExtenders = random.Next(s_maxExtenders + 1);
            for (int i = 0; i < numExtenders; ++i)
            {
                ExtenderNode extender = new() { NodeType = NodeType.Extender, Owner = entity };
                int numProperties = 1 + random.Next(s_maxExtenderAdditionalProperties);
                for(int j = 0; j < numProperties; ++j)
                {
                    extender.Properties.Add(new PropertyDescriptor
                    {
                        Name = $"P{entity.Properties.Count + extender.Properties.Count}",
                        Type = s_terminalTypes[random.Next(s_terminalTypes.Length)],
                        IsCollection = random.Next(s_baseCollection) == 0,
                        IsNullable = random.Next(s_baseNullable) == 0,
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                    });
                }
                universe.Extenders.Add(extender);
            }
        }
    }

    private static void CompleteEntities(Universe universe, Random random)
    {
        foreach(EntityNode entity in universe.Entities.Where(e => e.AccessProperties.Any()))
        {
            HashSet<EntityNode> used = new();
            _ = TestAndFixAccessLoop(entity, used);
        }
    }

    private static bool TestAndFixAccessLoop(EntityNode entity, HashSet<EntityNode> used)
    {
        if (!used.Add(entity))
        {
            return true;
        }
        foreach (PropertyDescriptor pd in entity.Properties.Where(p => p.IsAccess && p.Node is { }))
        {
            if(TestAndFixAccessLoop((pd.Node as EntityNode)!, used))
            {
                pd.IsAccess = false;
            }
        }
        used.Remove(entity);
        return false;
    }

    private static void GenerateClasses(Universe universe)
    {
        ClearProjectDir(UniverseOptions.GeneratedServerStuffProjectDir);
        ClearProjectDir(UniverseOptions.GeneratedClientStuffProjectDir);
        new Generator
        {
            ServerGeneratedDirectory = UniverseOptions.GeneratedServerStuffProjectDir,
            ClientGeneratedDirectory = UniverseOptions.GeneratedClientStuffProjectDir,
            Contract = universe.Contract,
            Verbose = false,
            ClientLanguage = UniverseOptions.ClientLanguage,
            OnResponse = UniverseOptions.OnGenerateClassesResponse,
        }.Generate();

        Project generatedServerStuff = Project.Create(new ProjectOptions
        {
            Name = "GeneratedServerStuff",
            TargetFramework = UniverseOptions.TargetFramework,
            ProjectDir = UniverseOptions.GeneratedServerStuffProjectDir,
        });

        generatedServerStuff.AddProject(UniverseOptions.PocotaCommonProjectFile);
        generatedServerStuff.AddProject(UniverseOptions.PocotaServerProjectFile);
        generatedServerStuff.AddProject(Path.Combine(UniverseOptions.GeneratedModelProjectDir, "Model.csproj"));

        generatedServerStuff.Compile();
    }

    private static void CreateDatabase(Universe universe)
    {
        using SqlConnection conn = new SqlConnection(UniverseOptions.ConnectionString);

        string[] commands = $@"drop database if exists {UniverseOptions.DatabaseName}
go
create database {UniverseOptions.DatabaseName}
go
use {UniverseOptions.DatabaseName}
go
{universe.Sql}
use master
go
".Split("go", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        SqlCommand cmd = new SqlCommand(string.Empty, conn);
        conn.Open();
        foreach (string sql in commands)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    private static void GenerateModelAndContract(Universe universe)
    {
        ClearProjectDir(UniverseOptions.GeneratedModelProjectDir);
        ClearProjectDir(UniverseOptions.GeneratedContractProjectDir);
        Project contract = new InterfacesGenerator().GenerateAndCompileModelAndContract(universe, UniverseOptions);
        universe.Contract = Assembly.LoadFile(contract.LibraryFile!)!
            .GetType($"{UniverseOptions.Namespace}.{UniverseOptions.ContractName}")!;

        UniverseOptions.ModelAndContractTelemetry?.Invoke(universe, contract);

    }

    private static void ClearProjectDir(string projectDir)
    {
        if(Directory.Exists(projectDir))
        {
            foreach (string file in Directory.EnumerateFiles(projectDir))
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            foreach (string dir in Directory.EnumerateDirectories(projectDir))
            {
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                }
            }
        }
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
        foreach (EntityNode node in universe.Entities)
        {
            CompletePrimaryKey(node);
        }
    }

    private static void CompletePrimaryKey(EntityNode node)
    {
        int nextId = 0;
        foreach(PropertyDescriptor pd in node.PrimaryKey)
        {
            if (pd.Name.StartsWith("Id"))
            {
                pd.PrimaryKeyPartAlias = pd.Name;
            }
            else
            {
                while(node.PrimaryKey.Any(p => p.Name.Equals($"Id{nextId}")))
                {
                    ++nextId;
                }
                pd.PrimaryKeyPartAlias = $"Id{nextId}";
                ++nextId;
            }
        }
    }

    private static void CreateFkPk(EntityNode node, Random random)
    {
        int numAddPk = random.Next(s_maxFkPk + 1);
        if(numAddPk > 0)
        {
            List<PropertyDescriptor> candidates = node.Properties
                .Where(p => p.Node is { } && p.Node != node && !p.IsNullable && !p.IsCollection)
                .SelectMany(p => p.References!).ToList();
            int initialPkCount = node.PrimaryKey.Count;
            for (int i = 0; i < numAddPk && candidates.Any(); ++i)
            {
                int pos = random.Next(candidates.Count);
                node.PrimaryKey!.Add(candidates[pos]);
                candidates.RemoveAt(pos);
            }
            foreach (EntityNode referenser in node.Referencers)
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
            int pkCount = 1 + random.Next(s_maxKeyParts);
            for (int i = node.PrimaryKey.Count; i < pkCount; ++i)
            {
                node.PrimaryKey.Add(new PropertyDescriptor
                {
                    Name = $"Id{i}",
                    Type = typeof(int),
                    IsNullable = false,
                    IsCollection = false,
                    IsReadOnly = true,
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
                node.References.Add(entity);
                node.Properties.Add(new PropertyDescriptor
                {
                    Name = $"P{node.Properties.Count}",
                    Node = entity,
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsNullable = random.Next(s_baseNullable) == 0,
                    IsCollection = random.Next(s_baseCollection) == 0,
                });
            }
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
        if (dataType == typeof(bool)) return "bit";
        if (dataType == typeof(DateTime)) return "datetime";
        if (dataType == typeof(Enum)) return "char(10)";
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
            int numAccessProperties = random.Next(s_baseAccessProperty) == 0 ? 1 + random.Next(s_maxAccessProperties) : 0;
            int numOtherProperties = s_minOtherProperties + random.Next(s_maxOtherProperties - s_minOtherProperties + 1);
            int baseAccessProperty = numAccessProperties > 0 ? (int)Math.Ceiling(1.0 * numOtherProperties / numAccessProperties) : 0;
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
                        bool isNullable = random.Next(s_baseNullable) == 0;
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{list[pos].Properties.Count}",
                            Node = nodes[i],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = isNullable,
                            IsAccess = !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
                        };
                        list[pos].Properties.Add(pd1);
                        if (pd1.IsAccess)
                        {
                            Console.WriteLine($"{list[pos].InterfaceName}.{pd1.Name} is access");
                        }
                    }
                    if (random.Next(s_baseCollection) == 0)
                    {
                        bool isNullable = random.Next(s_baseNullable) == 0;
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{nodes[i].Properties.Count}",
                            Node = list[pos],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = isNullable,
                            IsAccess = !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
                        };
                        nodes[i].Properties.Add(pd1);
                        if (pd1.IsAccess)
                        {
                            Console.WriteLine($"{nodes[i].InterfaceName}.{pd1.Name} is access");
                        }
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
                    bool isNullable = random.Next(s_baseNullable) == 0;
                    PropertyDescriptor pd = new()
                    {
                        Name = $"P{nodes[i].Properties.Count}",
                        Node = list[pos],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsNullable = isNullable,
                        IsAccess = areEntities && !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
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
            for (int j = 0; j < numOtherProperties; ++j)
            {
                Type type = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                bool isPrimaryKeyPart = 
                    areEntities 
                    && (type == typeof(int) || type == typeof(string))
                    && (
                        random.Next(s_basePrimaryKeyPart) == 0 
                        || (
                            j == numOtherProperties - 1 && !nodes[i].Properties.Any()
                        )
                    );
                bool isCollection = !isPrimaryKeyPart && random.Next(s_baseCollection) == 0;
                bool isNullable = !isPrimaryKeyPart && random.Next(s_baseNullable) == 0;
                PropertyDescriptor pd = new()
                {
                    Name = $"P{nodes[i].Properties.Count}",
                    Type = type,
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsCollection = isCollection,
                    IsNullable = isNullable,
                    IsAccess = areEntities && !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
                };
                nodes[i].Properties.Add(pd);
                if (isPrimaryKeyPart)
                {
                    (nodes[i] as EntityNode)?.PrimaryKey.Add(pd);
                }
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
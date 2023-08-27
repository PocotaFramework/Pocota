using Microsoft.Data.SqlClient;
using Net.Leksi.Pocota.Common;
using Net.Leksi.RuntimeAssemblyCompiler;
using Net.Leksi.Test.RandomPocoUniverse;
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
    private const int s_maxMethods = 3;
    private const int s_maxMethodArgs = 3;
    private const int s_baseMethodSingle = 3;
    private const int s_maxPathLength = 4;
    private const int s_baseAsteriskPath = 3;
    private const int s_baseOtherArgs = 3;

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
        Universe universe = new();

        CreateNodes(universe.Entities, random, true);
        CreateKeys(universe, random);
        CompleteEntities(universe, random);
        CreateExtenders(universe, random);
        CreateNodes(universe.Envelopes, random, false);
        CompleteEnvelopes(universe, random);
        CreateContractMethods(universe, random);

        UniverseOptions.NodesTelemetry?.Invoke(universe);

        if (UniverseOptions.DoGenerateModelAndContract)
        {
            GenerateModelAndContract(universe);
        }

        if (UniverseOptions.DoGenerateClasses)
        {
            GenerateClasses(universe);
        }

        if (UniverseOptions.DoCreateDatabase)
        {
            CreateDataSet(universe);
            CreateSql(universe);
            CreateDatabase(universe);
            UniverseOptions.CreateDatabaseTelemetry?.Invoke(universe);
        }

        if (UniverseOptions.DoCompilePocoUniverseServer)
        {
            CompilePocoUniverseServer(universe);
        }

        return universe;
    }

    private static void CreateContractMethods(Universe universe, Random random)
    {
        foreach(Node node in universe.Entities.Concat(universe.Extenders))
        {
            node.Methods.Add(new MethodHolder
            {
                Name = $"Get{node.InterfaceName}"
            });
            string getArg = (node is EntityNode ? node : ((ExtenderNode)node).Owner).InterfaceName;
            node.Methods.First().Parameters.Add(new MethodParameterModel
            {
                Name = "arg",
                Type = getArg,
            });
            CreatePropertyPaths(node.Methods.First().Properties, node, random, string.Empty, 0);
            int numMethods = random.Next(s_maxMethods + 1);
            for(int i = 0; i < numMethods; ++i)
            {
                bool isCollection = random.Next(s_baseMethodSingle) == 0;
                MethodHolder mh = new MethodHolder
                {
                    Name = $"{node.InterfaceName}Method{i}",
                    IsCollection = isCollection,
                };
                int numArgs = random.Next(s_maxMethodArgs + 1);
                for(int j = 0; j < numArgs; ++j)
                {
                    string type;
                    
                    if( random.Next(s_baseOtherArgs) == 0)
                    {
                        Type t = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                        type = t == typeof(Enum) ? "TestEnum" : Util.MakeTypeName(t);
                    }
                    else
                    {
                        type = universe.Envelopes[random.Next(universe.Envelopes.Count)].InterfaceName;
                    }
                    mh.Parameters.Add(new MethodParameterModel
                    {
                        Name = $"arg{j}",
                        Type = type,
                    });
                }
                node.Methods.Add(mh);
                CreatePropertyPaths(mh.Properties, node, random, string.Empty, 0);
            }
        }
    }

    private static void CreatePropertyPaths(List<string> properties, Node node, Random random, string path, int level)
    {
        if (random.Next(s_baseAsteriskPath) == 0)
        {
            path += $"{(level > 0 ? "." : string.Empty)}*";
            properties.Add(path);
            return;
        }
        foreach (PropertyDescriptor prop in node.Properties)
        {
            if(prop.Node is { } && level < s_maxPathLength)
            {
                CreatePropertyPaths(properties, prop.Node, random, $"{path}{(level > 0 ? "." : string.Empty)}{prop.Name}", level + 1);
            }
            else
            {
                properties.Add($"{path}{(level > 0 ? "." : string.Empty)}{prop.Name}");
            }
        }
    }

    private static void CompilePocoUniverseServer(Universe universe)
    {
        Project server = Project.Create(new ProjectOptions
        {
            Namespace = UniverseOptions.Namespace,
            Name = "PocoUniverseServerRuntime",
            ProjectDir = UniverseOptions.PocoUniverseServerProjectDir,
            Sdk = "Microsoft.NET.Sdk.Web",
            TargetFramework = "net6.0-windows7.0",
        });
        server.AddPackage("Net.Leksi.E6dWebApp", "1.1.10");
        server.AddProject(UniverseOptions.PocoUniverseCommonProjectFile);
        server.AddProject(UniverseOptions.PocotaCommonProjectFile);
        server.AddProject(UniverseOptions.PocotaServerProjectFile);
        server.AddProject(universe.ServerStuffProject!.ProjectPath);

        server.OnProjectFileGenerated = p => Console.WriteLine(p.ProjectPath);

        server.Compile();

        universe.PocoServer = (IPocoServer)Activator.CreateInstance(
            Assembly.LoadFile(server.LibraryFile!).GetType($"{UniverseOptions.Namespace}.Server")!
        )!;
    }

    private static void CreateExtenders(Universe universe, Random random)
    {
        foreach (EntityNode entity in universe.Entities)
        {
            int numExtenders = random.Next(s_maxExtenders + 1);
            for (int i = 0; i < numExtenders; ++i)
            {
                ExtenderNode extender = new() { NodeType = NodeType.Extender, Owner = entity };
                int numProperties = 1 + random.Next(s_maxExtenderAdditionalProperties);
                for (int j = 0; j < numProperties; ++j)
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
        foreach (EntityNode entity in universe.Entities)
        {
            if (entity.AccessProperties.Any())
            {
                HashSet<EntityNode> used = new();
                _ = TestAndFixAccessLoop(entity, used);
            }
        }
        bool changed = true;
        while (changed)
        {
            changed = false;
            foreach (EntityNode entity in universe.Entities)
            {
                foreach (EntityNode node in entity.Properties.Where(p => p.IsAccess && p.Node is { }).Select(p => p.Node!))
                {
                    if (!node.Properties.Any(p => p.IsAccess))
                    {
                        bool done = false;
                        foreach (PropertyDescriptor pd in node.Properties.Where(p => !p.IsNullable))
                        {
                            pd.IsAccess = true;
                            done = true;
                            break;
                        }
                        if (!done)
                        {
                            PropertyDescriptor pd = new()
                            {
                                Name = $"P{node.Properties.Count}",
                                Type = s_terminalTypes[random.Next(s_terminalTypes.Length)],
                                IsReadOnly = random.Next(s_baseReadonly) == 0,
                                IsCollection = random.Next(s_baseCollection) == 0,
                                IsNullable = false,
                                IsAccess = true,
                            };
                            node.Properties.Add(pd);
                        }
                        changed = true;
                    }
                }
            }
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
            if (TestAndFixAccessLoop((pd.Node as EntityNode)!, used))
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
            Verbose = UniverseOptions.GenerateClassesVerbose,
            ClientLanguage = UniverseOptions.ClientLanguage,
            OnResponse = UniverseOptions.OnGenerateClassesResponse,
        }.Generate();

        Project generatedServerStuff = Project.Create(new ProjectOptions
        {
            Name = "GeneratedServerStuff",
            TargetFramework = UniverseOptions.TargetFramework,
            ProjectDir = UniverseOptions.GeneratedServerStuffProjectDir,
            GeneratePackage = true,
        });

        generatedServerStuff.NoWarn = UniverseOptions.GenerateClassesNoWarn;
        generatedServerStuff.ThrowAtBuildWarnings = true;

        generatedServerStuff.AddProject(UniverseOptions.PocotaCommonProjectFile);
        generatedServerStuff.AddProject(UniverseOptions.PocotaServerProjectFile);
        generatedServerStuff.AddProject(Path.Combine(UniverseOptions.GeneratedModelProjectDir, "Model.csproj"));

        generatedServerStuff.Compile();

        universe.ServerStuffProject = generatedServerStuff;

        UniverseOptions.GenerateClassesTelemetry?.Invoke(universe);
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
        if (Directory.Exists(projectDir))
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
        foreach (PropertyDescriptor pd in node.PrimaryKey)
        {
            if (pd.Name.StartsWith("Id"))
            {
                pd.PrimaryKeyPartAlias = pd.Name;
            }
            else
            {
                while (node.PrimaryKey.Any(p => p.Name.Equals($"Id{nextId}")))
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
        if (numAddPk > 0)
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
                foreach (PropertyDescriptor pd in referenser.Properties.Where(p => p.Node == node && !p.IsCollection))
                {
                    for (int i = pd.References!.Count; i < node.PrimaryKey.Count; ++i)
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
                if(pd.References is null)
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
                else
                {
                    foreach(PropertyDescriptor pd1 in entityNode.PrimaryKey!)
                    {
                        if(pd.References.Where(p => p.Name.Equals($"{pd.Name}{pd1.Name}")).FirstOrDefault() is not PropertyDescriptor pd2)
                        {
                            pd2 = new PropertyDescriptor
                            {
                                Name = $"{pd.Name}{pd1.Name}",
                                Type = pd1.Type,
                                IsReadOnly = pd.IsReadOnly,
                                IsNullable = pd.IsNullable,
                            };
                            pd.References.Add(pd2);
                        }
                        if (node.NodeType is NodeType.ManyToManyLink && !node.PrimaryKey!.Contains(pd2))
                        {
                            node.PrimaryKey!.Add(pd2);
                        }
                    }
                }
            }
        }
    }

    private static void CreatePrimaryKey(EntityNode node, Random random)
    {
        if (node.NodeType is NodeType.Entity)
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
            for (int i = 0; i < numEntities; ++i)
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
                    if (random.Next(s_baseCollection) == 0)
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
                    IsReadOnly = !isPrimaryKeyPart && random.Next(s_baseReadonly) == 0,
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

    private static void CreateDataSet(Universe universe)
    {
        foreach (EntityNode node in universe.Entities)
        {
            DataTable table = new DataTable($"Table{node.Id}");
            universe.DataSet.Tables.Add(table);
            List<DataColumn> pk = new();
            foreach (PropertyDescriptor pd in node.PrimaryKey!)
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

            foreach (PropertyDescriptor pd in node.Properties.Where(p => !p.IsCollection && !node.PrimaryKey!.Contains(p)))
            {
                if (pd.Node is EntityNode entityNode)
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
            if (!table.PrimaryKey.Any())
            {
                Console.WriteLine($"no pk: {table.TableName}");
            }
        }
        foreach (EntityNode node in universe.Entities)
        {
            DataTable table = universe.DataSet.Tables[$"Table{node.Id}"]!;
            foreach (PropertyDescriptor pd in node.Properties.Where(p => p.Node is { } && !p.IsCollection))
            {
                DataTable relatedTable = universe.DataSet.Tables[$"Table{pd.Node!.Id}"]!;
                //Console.WriteLine($"{table}, [{string.Join(',', pd.References!)}], {relatedTable}, [{string.Join<DataColumn>(',', relatedTable.PrimaryKey)}]");
                try
                {
                    table.Constraints.Add(
                        new ForeignKeyConstraint(
                            $"fk_{table.TableName}_{pd.Name}_{relatedTable.TableName}",
                            relatedTable.PrimaryKey,
                            pd.References!.Select(p => table.Columns[p.Name]!).ToArray()
                        )
                    );
                }
                catch(Exception ex)
                {
                    throw new InvalidOperationException($"at {node}", ex);
                }
            }
        }
    }

}
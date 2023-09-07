﻿using Microsoft.Data.SqlClient;
using Net.Leksi.Pocota.Common;
using Net.Leksi.RuntimeAssemblyCompiler;
using Net.Leksi.Test.RandomPocoUniverse;
using System.Data;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Builder
{
    private const int s_numNodes = 20;
    private const int s_numEnvelopes = 7;
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
    private const int s_maxInheritance = 3;
    private const int s_maxMethods = 3;
    private const int s_maxMethodArgs = 3;
    private const int s_baseMethodSingle = 3;
    private const int s_maxPathLength = 4;
    private const int s_baseAsteriskPath = 3;
    private const int s_baseOtherArgs = 3;
    private const string s_e6dWebApp = "Net.Leksi.E6dWebApp";
    private const int s_maxNamespaces = 5;
    private const int s_maxNumInherited = 2;
    private const int s_maxInheritedtAdditionalProperties = 3;
    private const int s_baseIsCalculated = 5;

    private readonly static Type[] s_terminalTypes = new Type[]
    {
        typeof(int),
        typeof(string),
        typeof(bool),
        typeof(DateTime),
        typeof(TestEnum),
    };

    public static UniverseOptions UniverseOptions { get; private set; } = new();

    public static Universe Build(Random random)
    {
        UniverseOptions.E6dWebAppVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<BuilderPropertiesAttribute>()!.Properties["E6dWebAppVersion"];

        Universe universe = new();

        CreateNodes(universe, random);

        CreateKeys(universe, random);

        CompleteEntities(universe, random);
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
    {/*
        foreach(Node node in universe.Entities.Concat(universe.Extenders))
        {
            node.Methods.Add(new MethodHolder
            {
                Name = $"Get{node.Name}"
            });
            string getArg = (node is EntityNode ? node : ((ExtenderNode)node).Base).InterfaceName;
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
                    Name = $"{node.Name}Method{i}",
                    IsCollection = isCollection,
                };
                int numArgs = random.Next(s_maxMethodArgs + 1);
                for(int j = 0; j < numArgs; ++j)
                {
                    string type;
                    
                    if( random.Next(s_baseOtherArgs) == 0)
                    {
                        Type t = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                        type = Util.MakeTypeName(t);
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
    */}

    private static void CreatePropertyPaths(List<string> properties, Node node, Random random, string path, int level)
    {/*
        if (random.Next(s_baseAsteriskPath) == 0)
        {
            path += $"{(level > 0 ? "." : string.Empty)}*";
            properties.Add(path);
            return;
        }
        IEnumerable<PropertyDescriptor> props = node.NodeType is NodeType.Extender ? ((ExtenderNode)node).Base.Properties.Concat(node.Properties) : node.Properties;
        foreach (PropertyDescriptor prop in props)
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
    */}

    private static void CompilePocoUniverseServer(Universe universe)
    {
        Project server = Project.Create(new ProjectOptions
        {
            Namespace = UniverseOptions.Namespace,
            Name = "PocoUniverseServerRuntime",
            ProjectDir = UniverseOptions.PocoUniverseServerProjectDir,
            Sdk = "Microsoft.NET.Sdk.Web",
            TargetFramework = "net6.0-windows7.0",
            Configuration = UniverseOptions.Configuration,
        });
        server.AddPackage(s_e6dWebApp, UniverseOptions.E6dWebAppVersion);
        server.AddProject(UniverseOptions.PocoUniverseCommonProjectFile);
        server.AddProject(UniverseOptions.PocotaCommonProjectFile);
        server.AddProject(UniverseOptions.PocotaServerProjectFile);
        server.AddProject(universe.ServerStuffProject!.ProjectPath);

        string inheritsDir = Path.Combine(server.ProjectDir, "Generated");
        if (!Directory.Exists(inheritsDir))
        {
            Directory.CreateDirectory(inheritsDir);
        }
        else
        {
            ClearProjectDir(inheritsDir);
        }

        server.Compile();

        universe.PocoServer = (IPocoServer)Activator.CreateInstance(
            Assembly.LoadFile(server.LibraryFile!).GetType($"{UniverseOptions.Namespace}.Server")!
        )!;
    }

    private static InheritHolder InheritNode(Node node)
    {
        InheritHolder holder = new()
        {
            ClassName = node.Name.Substring(1),
        };
        return holder;
    }

    private static void CompleteEntities(Universe universe, Random random)
    {
        foreach (EntityNode entity in universe.Nodes.Where(n => n is EntityNode))
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
            foreach (EntityNode entity in universe.Nodes.Where(n => n is EntityNode))
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
                                Name = $"P{node.MaxPropertyNum}",
                                Type = s_terminalTypes[random.Next(s_terminalTypes.Length)],
                                IsReadOnly = random.Next(s_baseReadonly) == 0,
                                IsCollection = random.Next(s_baseCollection) == 0,
                                IsNullable = false,
                                IsAccess = true,
                                Source = 1,
                            };
                            node.Properties.Add(pd);
                            ++node.MaxPropertyNum;
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
        generatedServerStuff.AddProject(UniverseOptions.PocoUniverseCommonProjectFile);
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
        Project contract = new SourcesGenerator().GenerateAndCompileModelAndContract(universe, UniverseOptions);
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
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
        {
            CreatePrimaryKey(node, random);
        }
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
        {
            CreateForeignKeys(node, random);
        }

        foreach (EntityNode node in universe.Nodes.Where(
                n => n is EntityNode && n.Base is null && n.NodeType is not NodeType.ManyToManyLink
            )
        )
        {
            CreateFkPk(node, random);
        }
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
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
                .Where(p => p.Node is EntityNode && p.Node != node && !p.IsNullable && !p.IsCollection)
                .SelectMany(p => p.References!).ToList();
            int initialPkCount = node.PrimaryKey.Count;
            for (int i = 0; i < numAddPk && candidates.Any(); ++i)
            {
                int pos = random.Next(candidates.Count);
                node.PrimaryKey!.Add(candidates[pos]);
                candidates.RemoveAt(pos);
            }
            foreach (EntityNode referenser in node.Referencers.Where(n => n is EntityNode))
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
                            Source = 12,
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
                        Source = 2,
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
                                Source = 13,
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
        if (node.NodeType is NodeType.Entity && node.Base is null)
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
                    Source = 14,
                });
            }
        }
    }

    private static void CompleteEnvelopes(Universe universe, Random random)
    {
        List<EntityNode> entities = universe.Nodes.Where(n => n is EntityNode).Select(n => (EntityNode)n).ToList();
        foreach (Node node in universe.Nodes.Where(n => n is not EntityNode))
        {
            int numEntities = 1 + random.Next(s_maxEntitiesAtEnvelop);
            for (int i = 0; i < numEntities; ++i)
            {
                Node entity = entities[random.Next(entities.Count)];
                node.References.Add(entity);
                node.Properties.Add(new PropertyDescriptor
                {
                    Name = $"P{node.MaxPropertyNum}",
                    Node = entity,
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsNullable = random.Next(s_baseNullable) == 0,
                    IsCollection = random.Next(s_baseCollection) == 0,
                    Source = 15,
                });
                ++node.MaxPropertyNum;
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

    private static void CreateNodes(Universe universe, Random random)
    {
        int thresh = s_numNodes - (1 + s_maxNumInherited) * s_maxNumInherited / 2;
        Console.WriteLine($"thresh: {thresh}");
        int addThresh = s_maxNumInherited;
        int numInherits = 0;
        int numNodes = s_numNodes;
        for (int i = 0; i < numNodes; ++i)
        {
            bool isEnvelope = random.Next(s_numNodes) < s_numEnvelopes;
            int ns = random.Next(s_maxNamespaces)!;
            Node node = isEnvelope ? new Node() : new EntityNode();

            if(i == thresh)
            {
                ++numInherits;
                thresh += addThresh;
                --addThresh;
                Console.WriteLine($"thresh: {thresh}");
            }
            node.NumInherits = numInherits;
            
            if(numInherits > 0)
            {
                List<Node> bases;
                do
                {
                    bases = universe.Nodes.Where(
                        n => n.NodeType == node.NodeType && n.NumInherits == node.NumInherits - 1
                    ).ToList();
                }
                while (!bases.Any());
                Node baseNode = bases[random.Next(bases.Count)];
                while(baseNode.NumInherits < numInherits - 1)
                {
                    Node node1 = node.NodeType == NodeType.Envelope ? new Node() : new EntityNode();
                    node1.Base = baseNode;
                    if (node1 is EntityNode entity1)
                    {
                        entity1.PrimaryKey = ((EntityNode)baseNode).PrimaryKey;
                    }
                    node1.NumInherits = baseNode.NumInherits + 1;
                    baseNode = node1;
                }
                node.Base = baseNode;
                if (node is EntityNode entity)
                {
                    entity.PrimaryKey = ((EntityNode)baseNode).PrimaryKey;
                }
            }
            else if(node is EntityNode entity)
            {
                entity.PrimaryKey = new List<PropertyDescriptor>();
            }
            node.Namespace = ns switch { 0 => null, _ => $"{UniverseOptions.Namespace}.ns{ns}" };
            universe.Nodes.Add(node);
        }
        universe.Nodes.Sort(
            (n1, n2) => n1.NumInherits != n2.NumInherits 
                ? n1.NumInherits.CompareTo(n2.NumInherits) 
                : n1.Id.CompareTo(n2.Id)
        );
        numNodes = universe.Nodes.Count;
        List<Node> manyToManyLinks = new();
        for (int i = 0; i < numNodes; ++i)
        {
            if (universe.Nodes[i].Base is { })
            {
                universe.Nodes[i].MaxPropertyNum = universe.Nodes[i].Base!.MaxPropertyNum;
            }
            List<Node> list = universe.Nodes.Take(numNodes).ToList();
            int numReferences = s_minReferences + random.Next(s_maxReferences - s_minReferences + 1);
            int numAccessProperties = random.Next(s_baseAccessProperty) == 0 ? 1 + random.Next(s_maxAccessProperties) : 0;
            int numOtherProperties = s_minOtherProperties + random.Next(s_maxOtherProperties - s_minOtherProperties + 1);
            int baseAccessProperty = numAccessProperties > 0 ? (int)Math.Ceiling(1.0 * numOtherProperties / numAccessProperties) : 0;
            for (int j = 0; j < numReferences; ++j)
            {
                int pos = random.Next(list.Count);
                if (
                    universe.Nodes[i].NodeType is NodeType.Entity
                    && list[pos].NodeType is NodeType.Entity
                    && universe.Nodes[i] != list[pos]
                    && !universe.Nodes[i].References.Any(n => list[pos].References.Contains(n))
                    && random.Next(1 + (int)Math.Ceiling(s_fraqManyToMany * s_numNodes * (s_maxReferences + s_minReferences) * .25)) == 0
                )
                {
                    int ns = random.Next(s_maxNamespaces)!;
                    EntityNode link = new()
                    {
                        NodeType = NodeType.ManyToManyLink,
                        Namespace = ns switch { 0 => null, _ => $"{UniverseOptions.Namespace}.ns{ns}" },
                        PrimaryKey = new List<PropertyDescriptor>(),
                    };
                    link.References.Add(universe.Nodes[i]);
                    universe.Nodes[i].Referencers.Add(link);
                    link.References.Add(list[pos]);
                    list[pos].Referencers.Add(link);
                    universe.Nodes.Add(link);
                    if (random.Next(s_baseCollection) == 0)
                    {
                        bool isNullable = random.Next(s_baseNullable) == 0;
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{list[pos].MaxPropertyNum}",
                            Node = universe.Nodes[i],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = isNullable,
                            IsAccess = !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
                            Source = 3,
                        };
                        list[pos].Properties.Add(pd1);
                        ++list[pos].MaxPropertyNum;
                    }
                    if (random.Next(s_baseCollection) == 0)
                    {
                        bool isNullable = random.Next(s_baseNullable) == 0;
                        PropertyDescriptor pd1 = new()
                        {
                            Name = $"P{universe.Nodes[i].MaxPropertyNum}",
                            Node = list[pos],
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsCollection = true,
                            IsNullable = isNullable,
                            IsAccess = !isNullable && baseAccessProperty > 0 && random.Next(baseAccessProperty) == 0,
                            Source = 4,
                        };
                        universe.Nodes[i].Properties.Add(pd1);
                        ++universe.Nodes[i].MaxPropertyNum;
                    }
                    link.Properties.Add(new PropertyDescriptor
                    {
                        Name = $"P{link.MaxPropertyNum}",
                        Node = universe.Nodes[i],
                        IsReadOnly = true,
                        IsNullable = false,
                        IsCollection = false,
                        Source = 5,
                    });
                    ++link.MaxPropertyNum;
                    link.Properties.Add(new PropertyDescriptor
                    {
                        Name = $"P{link.MaxPropertyNum}",
                        Node = list[pos],
                        IsReadOnly = true,
                        IsNullable = false,
                        IsCollection = false,
                        Source = 6,
                    });
                    ++link.MaxPropertyNum;
                }
                else
                {
                    universe.Nodes[i].References.Add(list[pos]);
                    list[pos].Referencers.Add(universe.Nodes[i]);
                    bool isNullable = random.Next(s_baseNullable) == 0;
                    PropertyDescriptor pd = new()
                    {
                        Name = $"P{universe.Nodes[i].MaxPropertyNum}",
                        Node = list[pos],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsNullable = isNullable,
                        IsAccess = universe.Nodes[i] is EntityNode 
                            && list[pos] is EntityNode
                            && !isNullable && baseAccessProperty > 0 
                            && random.Next(baseAccessProperty) == 0,
                        IsCalculated = universe.Nodes[i] is EntityNode
                            && list[pos] is not EntityNode,
                        Source = 7,
                    };

                    ++universe.Nodes[i].MaxPropertyNum;

                    universe.Nodes[i].Properties.Add(pd);
                    if (random.Next(s_baseCollection) == 0)
                    {
                        if (universe.Nodes[i] is not EntityNode)
                        {
                            pd.IsCollection = true;
                        }
                        else
                        {
                            PropertyDescriptor pd1 = new()
                            {
                                Name = $"P{list[pos].MaxPropertyNum}",
                                Node = universe.Nodes[i],
                                IsReadOnly = random.Next(s_baseReadonly) == 0,
                                IsCollection = true,
                                IsNullable = random.Next(s_baseNullable) == 0,
                                Source = 8,
                            };
                            list[pos].Properties.Add(pd1);
                            ++list[pos].MaxPropertyNum;
                        }
                    }
                }
            }
            for (int j = 0; j < numOtherProperties; ++j)
            {
                Type type = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                bool isPrimaryKeyPart =
                    universe.Nodes[i] is EntityNode
                    && universe.Nodes[i].Base is null
                    && (type == typeof(int) || type == typeof(string))
                    && (
                        random.Next(s_basePrimaryKeyPart) == 0
                        || (
                            j == numOtherProperties - 1 && !universe.Nodes[i].Properties.Any()
                        )
                    );
                bool isCollection = !isPrimaryKeyPart && random.Next(s_baseCollection) == 0;
                bool isNullable = !isPrimaryKeyPart && random.Next(s_baseNullable) == 0;
                bool isCalculated = random.Next(s_baseIsCalculated) == 0;
                PropertyDescriptor pd = new()
                {
                    Name = $"P{universe.Nodes[i].MaxPropertyNum}",
                    Type = type,
                    IsReadOnly = !isPrimaryKeyPart && random.Next(s_baseReadonly) == 0,
                    IsCollection = isCollection,
                    IsNullable = isNullable,
                    IsAccess = universe.Nodes[i] is EntityNode
                        && !isCalculated
                        && !isNullable && baseAccessProperty > 0 
                        && random.Next(baseAccessProperty) == 0,
                    IsCalculated = isCalculated,
                    Source = 9,
                };
                universe.Nodes[i].Properties.Add(pd);
                
                ++universe.Nodes[i].MaxPropertyNum;
                
                if (isPrimaryKeyPart)
                {
                    (universe.Nodes[i] as EntityNode)?.PrimaryKey.Add(pd);
                }
            }
        }
        for (int i = 0; i < numNodes; ++i)
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
                        PropertyDescriptor pd = new()
                        {
                            Name = $"P{universe.Nodes[i].MaxPropertyNum}",
                            Node = probe,
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsNullable = random.Next(s_baseNullable) == 0,
                            Source = 10,
                        };
                        universe.Nodes[i].Properties.Add(pd);

                        ++universe.Nodes[i].MaxPropertyNum;

                        if (random.Next(s_baseCollection) == 0)
                        {
                            if (universe.Nodes[i] is not EntityNode)
                            {
                                pd.IsCollection = true;
                            }
                            else
                            {
                                PropertyDescriptor pd1 = new()
                                {
                                    Name = $"P{probe.MaxPropertyNum}",
                                    Node = universe.Nodes[i],
                                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                                    IsCollection = true,
                                    IsNullable = random.Next(s_baseNullable) == 0,
                                    Source = 11,
                                };
                                probe.Properties.Add(pd1);
                                ++probe.MaxPropertyNum;
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
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
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
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
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
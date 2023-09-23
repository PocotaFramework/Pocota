using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Net.Leksi.Pocota.Common;
using Net.Leksi.RuntimeAssemblyCompiler;
using Net.Leksi.Test.RandomPocoUniverse;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

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
    private const int s_minOtherProperties = 3;
    private const int s_maxOtherProperties = 10;
    private const int s_maxAccessProperties = 4;
    private const int s_maxMethods = 3;
    private const int s_maxMethodArgs = 3;
    private const int s_baseMethodSingle = 3;
    private const int s_maxPathLength = 4;
    private const int s_baseAsteriskPath = 3;
    private const int s_baseOtherArgs = 3;
    private const string s_e6dWebApp = "Net.Leksi.E6dWebApp";
    private const int s_maxNamespaces = 5;
    private const int s_maxNumInherited = 2;
    private const int s_baseIsCalculated = 5;
    private const int s_minProperties = 5;
    private const int s_maxProperties = 20;
    private const int s_baseMandatoryReturnProperty = 3;

    private static readonly Regex s_trimPart = new Regex("^[^![]+");

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

        CreateAccessSelectors(universe, random);
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
        Node[] envelopes = universe.Nodes.Where(n => n is not EntityNode).ToArray();
        foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
        {
            node.Methods.Add(new MethodHolder
            {
                Name = $"Get{node.Name}"
            });
            node.Methods.First().Parameters.Add(new MethodParameterModel
            {
                Name = "arg",
                Type = node.Name,
            });
            CreatePropertyPaths(node.Methods.First().Properties, node, random, string.Empty, 0);
            int numMethods = random.Next(s_maxMethods + 1);
            for (int i = 0; i < numMethods; ++i)
            {
                bool isCollection = random.Next(s_baseMethodSingle) == 0;
                MethodHolder mh = new MethodHolder
                {
                    Name = $"{node.Name}Method{i}",
                    IsCollection = isCollection,
                };
                int numArgs = random.Next(s_maxMethodArgs + 1);
                for (int j = 0; j < numArgs; ++j)
                {
                    string type;

                    if (random.Next(s_baseOtherArgs) == 0)
                    {
                        Type t = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                        type = Util.MakeTypeName(t);
                    }
                    else
                    {
                        type = envelopes[random.Next(envelopes.Length)].Name;
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
        List<PropertyDescriptor> allProps = new();
        Node? cur = node;
        while (cur is { })
        {
            allProps.AddRange(cur.Properties);
            cur = cur.Base;
        }
        foreach (PropertyDescriptor prop in allProps)
        {
            string next = $"{path}{(level > 0 ? "." : string.Empty)}{prop.Name}{(prop.IsNullable ? "!" : string.Empty)}{(prop.Node is { } && prop.IsCollection ? "[0]" : string.Empty)}";
            if (prop.Node is { } && level < s_maxPathLength)
            {
                CreatePropertyPaths(properties, prop.Node, random, next, level + 1);
            }
            else
            {
                properties.Add(next);
            }
        }
        if(level == 0)
        {
            int count = s_minProperties + random.Next(s_maxProperties - s_minProperties + 1);
            Dictionary<int, List<string>> pathsByNumParts = new();
            for (int j = 0; j <= s_maxPathLength; ++j)
            {
                pathsByNumParts.Add(j, properties.Where(s => s.Split('.').Length == j).ToList());
            }
            for (int j = 0; j < count; ++j)
            {
                int numParts = 1 + random.Next(s_maxPathLength);
                pathsByNumParts.TryGetValue(numParts, out List<string>? values);
                if (values!.Any())
                {
                    int pos = random.Next(values!.Count);
                    string next = values[pos];
                    values.RemoveAt(pos);
                    //bool isKey = false;
                    //Node current = node;
                    //foreach(string part in next.Split('.'))
                    //{
                    //    string part1 = s_trimPart.Match(part) is Match match && match.Success ? match.Groups[0].Value : part;
                    //    Console.WriteLine($"{current.Name}, {part}, {part1}");
                    //    PropertyDescriptor pd = current.Properties.Where(p => part1.Equals(p.Name)).FirstOrDefault()!;
                    //    if(pd is null)
                    //    {
                    //        for(Node now = current.Base; pd is null && now != now.Base; now = now.Base)
                    //        {
                    //            pd = now.Properties.Where(p => part1.Equals(p.Name)).FirstOrDefault()!;
                    //        }
                    //    }
                    //    if(current is EntityNode entity && entity.PrimaryKey.Contains(pd!))
                    //    {
                    //        isKey = true;
                    //        break;
                    //    }
                    //    current = pd!.Node!;
                    //}
                    //if(!isKey && random.Next(s_baseMandatoryReturnProperty) == 0)
                    //{
                    //    next += '$';
                    //}

                    properties.Insert(0, next);
                }
            }
            properties.RemoveRange(count, properties.Count - count);
            properties.Sort();
        }
    }

    private static void CompilePocoUniverseServer(Universe universe)
    {
        using (Project server = Project.Create(new ProjectOptions
        {
            Namespace = UniverseOptions.Namespace,
            Name = "PocoUniverseServerRuntime",
            ProjectDir = UniverseOptions.PocoUniverseServerProjectDir,
            Sdk = "Microsoft.NET.Sdk.Web",
            TargetFramework = "net6.0-windows7.0",
            Configuration = UniverseOptions.Configuration,
        }))
        {
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
    }

    private static InheritHolder InheritNode(Node node)
    {
        InheritHolder holder = new()
        {
            ClassName = node.Name.Substring(1),
        };
        return holder;
    }

    private static void CreateAccessSelectors(Universe universe, Random random)
    {
        foreach (EntityNode entity in universe.Nodes.Where(n => n is EntityNode))
        {
            List<string> candidates = FillAccessSelectorsLevel(entity, random, string.Empty, 0);
            int count = Math.Min(2 + random.Next(s_maxAccessProperties - 1), candidates.Count);
            for (int i = 0; i < count; ++i)
            {
                int pos = random.Next(0, candidates.Count);
                entity.AccessProperties.Add(candidates[pos]);
                candidates.RemoveAt(pos);
            }
            entity.AccessProperties.Sort();
        }
    }

    private static List<string> FillAccessSelectorsLevel(
        EntityNode entity,
        Random random,
        string path, 
        int level
    )
    {
        List<string> result = new();
        List<PropertyDescriptor> candidates = entity.Properties.Where(
            p => !p.IsCalculated 
            && !p.IsNullable 
            && (level < s_maxPathLength ? (p.Node is null || p.Node is EntityNode) : (p.Node is null))
        ).ToList();
        int levelCount = Math.Min(2 + random.Next(s_maxAccessProperties - 1), candidates.Count);
        for (int i = 0; i < levelCount; ++i)
        {
            int pos = random.Next(0, candidates.Count);
            string delim = string.IsNullOrEmpty(path) ? string.Empty : ".";
            string indexer = candidates[pos].IsCollection && candidates[pos].Node is EntityNode ? "[0]" : string.Empty;
            string next = $"{path}{delim}{candidates[pos].Name}{indexer}";
            if (candidates[pos].Node is EntityNode en)
            {
                result.AddRange(FillAccessSelectorsLevel(en, random, next, level + 1));
            }
            else
            {
                result.Add(next);
            }
            candidates.RemoveAt(pos);
        }
        return result;
    }

    private static void GenerateClasses(Universe universe)
    {
        if (UniverseOptions.ContractStubsProjectDir is { }) 
        {
            if (!Directory.Exists(UniverseOptions.ContractStubsProjectDir))
            {
                Directory.CreateDirectory(UniverseOptions.ContractStubsProjectDir);
            }
            else
            {
                ClearProjectDir(UniverseOptions.ContractStubsProjectDir);
            }
        }
        ClearProjectDir(UniverseOptions.GeneratedServerStuffProjectDir);
        ClearProjectDir(UniverseOptions.GeneratedClientStuffProjectDir);
        using (Generator generator = new()
        {
            ServerGeneratedDirectory = UniverseOptions.GeneratedServerStuffProjectDir,
            ClientGeneratedDirectory = UniverseOptions.GeneratedClientStuffProjectDir,
            Verbose = UniverseOptions.GenerateClassesVerbose,
            ClientLanguage = UniverseOptions.ClientLanguage,
            OnResponse = UniverseOptions.OnGenerateClassesResponse,
            ContractStubsProjectDir = UniverseOptions.ContractStubsProjectDir,
        })
        {
            generator.Generate(universe.Contract);
        }

        using (Project generatedServerStuff = Project.Create(new ProjectOptions
        {
            Name = "GeneratedServerStuff",
            TargetFramework = UniverseOptions.TargetFramework,
            ProjectDir = UniverseOptions.GeneratedServerStuffProjectDir,
            GeneratePackage = true,
        }))
        {
            generatedServerStuff.NoWarn = UniverseOptions.GenerateClassesNoWarn;
            generatedServerStuff.ThrowAtBuildWarnings = true;

            generatedServerStuff.AddProject(UniverseOptions.PocotaCommonProjectFile);
            generatedServerStuff.AddProject(UniverseOptions.PocotaServerProjectFile);
            generatedServerStuff.AddProject(UniverseOptions.PocoUniverseCommonProjectFile);
            generatedServerStuff.AddProject(Path.Combine(UniverseOptions.GeneratedModelProjectDir, "Model.csproj"));

            generatedServerStuff.Compile();

            universe.ServerStuffProject = generatedServerStuff;
        }


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
            //Console.WriteLine(sql);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }

    private static void GenerateModelAndContract(Universe universe)
    {
        ClearProjectDir(UniverseOptions.GeneratedModelProjectDir);
        ClearProjectDir(UniverseOptions.GeneratedContractProjectDir);
        using (Project contract = new SourcesGenerator().GenerateAndCompileModelAndContract(universe, UniverseOptions))
        {
            universe.Contract = Assembly.LoadFile(contract.LibraryFile!)!
                .GetType($"{UniverseOptions.Namespace}.{UniverseOptions.ContractName}")!;

            UniverseOptions.ModelAndContractTelemetry?.Invoke(universe, contract);
        }

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
        bool changed = true;
        int i = 0;
        while (changed && i < 10)
        {
            ++i;
            changed = false;
            foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode en && !en.PrimaryKey.Any()))
            {
                CreatePrimaryKey(node, random);
                //Console.WriteLine($"CreateKeys: {node}");
            }
            foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
            {
                if (ResolveCyclicPrimaryKey(node, random))
                {
                    changed = true;
                }
            }
            if (changed)
            {
                foreach (EntityNode node in universe.Nodes.Where(n => n is EntityNode))
                {
                    node.PrimaryKey.RemoveAll(p => node.CannotBePrimaryKey.Contains(p));
                }
            }
        }
    }

    private static bool ResolveCyclicPrimaryKey(EntityNode node, Random random)
    {
        Dictionary<EntityNode, int> colors = new();
        bool result = false;

        Action<EntityNode> dfs = null!;
        dfs = n =>
        {
            // немного переделанный алгоритм поиска цикла
            // непосёщенная ранее вершина не имеет цвета, обработанная вершина имеет цвет 1
            // обрабатываемая вершина имеет цвет равный 2 + позиция исходящего ребра
            // если мы возвращаемся в эту вершину из-за цикла, мы удаляем ребро, ведущее к циклу именно эту вершину.
            colors.Add(n, 1);
            for (int i = 0; i < n.PrimaryKey.Count; ++i)
            {
                colors[n] = i + 2;
                if (n.PrimaryKey[i].Node is EntityNode en && !n.CannotBePrimaryKey.Contains(n.PrimaryKey[i]))
                {
                    if (!colors.ContainsKey(en))
                    {
                        dfs.Invoke(en);
                    }
                    else if (colors[en] >= 2)
                    {
                        en.CannotBePrimaryKey.Add(en.PrimaryKey[colors[en] - 2]);
                        result = true;
                    }
                }
            }
            colors[n] = 1;
        };
        dfs.Invoke(node);
        return result;
    }

    private static void CreatePrimaryKey(EntityNode node, Random random)
    {
        if (!node.PrimaryKey.Any())
        {
            int pkCount = 1 + random.Next(s_maxKeyParts);
            IEnumerator<PropertyDescriptor> enumerator = node.Properties
                .Where(
                    p => (p.Node is EntityNode || p.Node is null)
                        && p.Node != node
                        && !p.IsCollection
                        && !p.IsCalculated
                        && !p.IsNullable
                        && !node.CannotBePrimaryKey.Contains(p)
                )
                .GetEnumerator();
            for (int i = node.PrimaryKey.Count; i < pkCount && enumerator.MoveNext(); ++i)
            {
                if (!node.PrimaryKey.Contains(enumerator.Current))
                {
                    node.PrimaryKey.Add(enumerator.Current);
                }
            }
            if (node.PrimaryKey.Count < pkCount)
            {
                enumerator = node.Properties
                    .Where(
                        p => (p.Node is EntityNode || p.Node is null)
                            && p.Node != node
                            && !p.IsCollection
                            && !p.IsCalculated
                    )
                    .GetEnumerator();
                for (int i = node.PrimaryKey.Count; i < pkCount && enumerator.MoveNext(); ++i)
                {
                    if (enumerator.Current.IsNullable)
                    {
                        enumerator.Current.IsNullable = false;
                    }
                    if (!node.PrimaryKey.Contains(enumerator.Current))
                    {
                        node.PrimaryKey.Add(enumerator.Current);
                    }
                }
            }
            if (node.PrimaryKey.Count < pkCount)
            {
                enumerator = node.Properties
                    .Where(
                        p => (p.Node is EntityNode || p.Node is null)
                            && p.Node != node
                            && !p.IsCalculated
                    )
                    .GetEnumerator();
                for (int i = node.PrimaryKey.Count; i < pkCount && enumerator.MoveNext(); ++i)
                {
                    if (enumerator.Current.IsNullable)
                    {
                        enumerator.Current.IsNullable = false;
                    }
                    if (enumerator.Current.IsCollection)
                    {
                        enumerator.Current.IsCollection = false;
                    }
                    if (!node.PrimaryKey.Contains(enumerator.Current))
                    {
                        node.PrimaryKey.Add(enumerator.Current);
                    }
                }
            }
            if (!node.PrimaryKey.Any())
            {
                throw new Exception();
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
                    Node = entity,
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsNullable = random.Next(s_baseNullable) == 0,
                    IsCollection = random.Next(s_baseCollection) == 0,
                    Source = 15,
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
        if (dataType.IsEnum) return "char(10)";
        return dataType.ToString();
    }

    private static void CreateNodes(Universe universe, Random random)
    {
        int thresh = s_numNodes - (1 + s_maxNumInherited) * s_maxNumInherited / 2;
        int addThresh = s_maxNumInherited;
        int numInherits = 0;
        int numNodes = s_numNodes;
        bool envelopesOnly = false;
        for (int i = 0; i < numNodes; ++i)
        {
            bool isEnvelope = envelopesOnly || random.Next(s_numNodes) < s_numEnvelopes;
            int ns = random.Next(s_maxNamespaces)!;
            Node node = isEnvelope ? new Node() : new EntityNode();

            if (i == thresh)
            {
                ++numInherits;
                thresh += addThresh;
                --addThresh;
            }
            node.NumInherits = numInherits;

            if (numInherits > 0)
            {
                List<Node> bases = universe.Nodes.Where(
                    n => n.GetType() == node.GetType() && n.NumInherits == node.NumInherits - 1
                ).ToList();
                if (bases.Any())
                {
                    Node baseNode = bases[random.Next(bases.Count)];
                    while (baseNode.NumInherits < numInherits - 1)
                    {
                        Node node1 = node is EntityNode ? new EntityNode() : new Node();
                        node1.Base = baseNode;
                        node1.NumInherits = baseNode.NumInherits + 1;
                        baseNode = node1;
                    }
                    node.Base = baseNode;
                }
            }
            node.Namespace = ns switch { 0 => null, _ => $"{UniverseOptions.Namespace}.ns{ns}" };
            universe.Nodes.Add(node);
            if (!envelopesOnly && i == numNodes - 1 && !universe.Nodes.Any(n => n is not EntityNode))
            {
                envelopesOnly = true;
                numNodes += s_numEnvelopes;
            }
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
            List<Node> list = universe.Nodes.Take(numNodes).ToList();
            int numReferences = s_minReferences + random.Next(s_maxReferences - s_minReferences + 1);
            int numOtherProperties = s_minOtherProperties + random.Next(s_maxOtherProperties - s_minOtherProperties + 1);
            for (int j = 0; j < numReferences; ++j)
            {
                int pos = random.Next(list.Count);
                if (
                    universe.Nodes[i] is EntityNode
                    && list[pos] is EntityNode
                    && universe.Nodes[i] != list[pos]
                    && !universe.Nodes[i].References.Any(n => list[pos].References.Contains(n))
                    && random.Next(1 + (int)Math.Ceiling(s_fraqManyToMany * s_numNodes * (s_maxReferences + s_minReferences) * .25)) == 0
                )
                {
                    int ns = random.Next(s_maxNamespaces)!;
                    PropertyDescriptor pd1 = new()
                    {
                        Node = universe.Nodes[i],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsCollection = true,
                        Source = 3,
                    };
                    list[pos].Properties.Add(pd1);
                    PropertyDescriptor pd2 = new()
                    {
                        Node = list[pos],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsCollection = true,
                        Source = 4,
                        Link = pd1,
                    };
                    pd1.Link = pd2;
                    universe.Nodes[i].Properties.Add(pd2);
                }
                else
                {
                    universe.Nodes[i].References.Add(list[pos]);
                    list[pos].Referencers.Add(universe.Nodes[i]);
                    bool isNullable = random.Next(s_baseNullable) == 0;
                    PropertyDescriptor pd = new()
                    {
                        Node = list[pos],
                        IsReadOnly = random.Next(s_baseReadonly) == 0,
                        IsNullable = isNullable,
                        Source = 7,
                    };

                    universe.Nodes[i].Properties.Add(pd);
                    if (random.Next(s_baseCollection) == 0)
                    {

                        pd.IsCollection = true;
                        if (universe.Nodes[i] is EntityNode)
                        {
                            PropertyDescriptor pd1 = new()
                            {
                                Node = universe.Nodes[i],
                                IsReadOnly = random.Next(s_baseReadonly) == 0,
                                IsNullable = random.Next(s_baseNullable) == 0,
                                Source = 8,
                            };
                            list[pos].Properties.Add(pd1);
                            pd.Link = pd1;
                        }
                    }
                }
            }
            for (int j = 0; j < numOtherProperties; ++j)
            {
                Type type = s_terminalTypes[random.Next(s_terminalTypes.Length)];
                bool isCollection = random.Next(s_baseCollection) == 0;
                bool isNullable = random.Next(s_baseNullable) == 0;
                bool isCalculated = random.Next(s_baseIsCalculated) == 0;
                PropertyDescriptor pd = new()
                {
                    Type = type,
                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                    IsCollection = isCollection,
                    IsNullable = isNullable,
                    IsCalculated = isCalculated,
                    Source = 9,
                };
                universe.Nodes[i].Properties.Add(pd);

            }
        }
        for (int i = 0; i < numNodes; ++i)
        {
            HashSet<Node> set = new();
            if (!IsLooped(universe.Nodes[i], universe.Nodes[i], string.Empty, set) && random.Next(s_baseCycleReferenced) == 0)
            {
                foreach (Node probe in universe.Nodes.Where(n => !set.Contains(n)))
                {
                    if (IsLooped(universe.Nodes[i], probe, $"/{universe.Nodes[i].Id}", null))
                    {
                        universe.Nodes[i].References.Add(probe);
                        probe.Referencers.Add(universe.Nodes[i]);
                        PropertyDescriptor pd = new()
                        {
                            Node = probe,
                            IsReadOnly = random.Next(s_baseReadonly) == 0,
                            IsNullable = random.Next(s_baseNullable) == 0,
                            Source = 10,
                        };
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
                                    Node = universe.Nodes[i],
                                    IsReadOnly = random.Next(s_baseReadonly) == 0,
                                    IsCollection = true,
                                    IsNullable = random.Next(s_baseNullable) == 0,
                                    Source = 11,
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

}
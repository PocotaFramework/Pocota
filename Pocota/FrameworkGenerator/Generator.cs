using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.FrameworkGenerator.Models;
using Net.Leksi.Pocota.FrameworkGenerator.Pages.Server;
using Net.Leksi.Pocota.Pages.Auxiliary;
using Net.Leksi.Pocota.Server;
using Net.Leksi.RuntimeAssemblyCompiler;
using System.Data;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace Net.Leksi.Pocota.FrameworkGenerator;

public class Generator : Runner
{
    private const string s_self = "<self>";
    private const string s_internal = "Internal";
    private const string s_dependencyInjection = "Microsoft.Extensions.DependencyInjection";
    private Contract _contract = null!;
    private readonly Dictionary<string, PocoHolder> _pocos = [];
    private readonly Dictionary<string, MethodHolder> _methods = [];
    private readonly HashSet<string> _additionalReferences = new();
    private readonly Dictionary<Type, List<PropertyUse>> _allPropertyUses = [];

    private string? _serverStuffProject = null;
    private bool _doCreateProject = false;
    private bool _replaceFilesIfExist = false;
    private string? _serverTargetFramework = null;
    private string? _contractProcessingDir = null;

    private MethodHolder? _currentMethod = null;
    private PocoHolder? _currentPoco = null;
    private object? _currentObject = null;
    private PropertyUse? _lastPropertyUse = null;
    private ContractEventKind _currentContractEventKind = ContractEventKind.None;
    private readonly Dictionary<object, PropertyUse> _propertyUses = [];
    private readonly List<PropertyUse> _currentPath = [];
    private readonly NullabilityInfoContext _nullabilityInfoContext = new();
    public static Generator Create(FrameworkGeneratorOptions options)
    {
        Generator generator = new()
        {
            _contract = options.Contract,
            _serverStuffProject = options.ServerStuffProject,
            _replaceFilesIfExist = options.ReplaceFilesIfExist,
            _doCreateProject = options.DoCreateProject,
            _serverTargetFramework = options.ServerTargetFramework,
            _contractProcessingDir = options.ContractProcessorDir,
        };
        generator._additionalReferences.Add(typeof(IPoco).Assembly.Location);
        generator._additionalReferences.Add(typeof(IEntity).Assembly.Location);
        generator._additionalReferences.Add(typeof(ContractEventHandler).Assembly.Location);
        if (options.AdditionalReferences is { })
        {
            foreach (string ar in options.AdditionalReferences)
            {
                generator._additionalReferences.Add(ar);
            }
        }

        generator.ProcessContract();

        return generator;
    }
    public Project? GenerateServerStuff()
    {
        string dtoBase = Path.Combine(_serverStuffProject!, "DtoBase");
        string dto = Path.Combine(_serverStuffProject!, "Dto");
        string primaryKeys = Path.Combine(_serverStuffProject!, "PrimaryKeys");
        string controllers = Path.Combine(_serverStuffProject!, "Controllers");
        string core = Path.Combine(_serverStuffProject!, "Core");
        string builder = Path.Combine(_serverStuffProject!, "Builder");
        string projectDir = Path.GetFullPath(_serverStuffProject!);

        if (!_replaceFilesIfExist)
        {
            if (
                Directory.Exists(controllers)
                || Directory.Exists(primaryKeys)
                || Directory.Exists(dtoBase)
                || Directory.Exists(dto)
                || Directory.Exists(core)
                || Directory.Exists(builder)
                || (_doCreateProject && Directory.Exists(projectDir))
            )
            {
                throw new InvalidOperationException($"Some files already exist! Delete them or set true {nameof(FrameworkGeneratorOptions.ReplaceFilesIfExist)} option.");
            }
        }

        if (Directory.Exists(dtoBase))
        {
            Directory.Delete(dtoBase, true);
        }
        if (Directory.Exists(dto))
        {
            Directory.Delete(dto, true);
        }
        if (Directory.Exists(primaryKeys))
        {
            Directory.Delete(primaryKeys, true);
        }
        if (Directory.Exists(controllers))
        {
            Directory.Delete(controllers, true);
        }
        if (Directory.Exists(core))
        {
            Directory.Delete(core, true);
        }
        if (Directory.Exists(builder))
        {
            Directory.Delete(builder, true);
        }
        if (_doCreateProject && Directory.Exists(projectDir))
        {
            Directory.Delete(projectDir, true);
        }
        if (!Directory.Exists(projectDir))
        {
            Directory.CreateDirectory(projectDir!);
        }
        Directory.CreateDirectory(dtoBase);
        Directory.CreateDirectory(dto);
        Directory.CreateDirectory(primaryKeys);
        Directory.CreateDirectory(controllers);
        Directory.CreateDirectory(core);
        Directory.CreateDirectory(builder);

        Project? serverStuffProject = null;

        if (_doCreateProject)
        {
            serverStuffProject = Project.Create(new ProjectOptions
            {
                Name = Path.GetFileName(_serverStuffProject),
                ProjectDir = _serverStuffProject,
                TargetFramework = _serverTargetFramework,
                Sdk = "Microsoft.NET.Sdk.Web",
            });
            serverStuffProject.AddPackage(s_dependencyInjection, "*");
            foreach (string ar in _additionalReferences)
            {
                serverStuffProject.AddReference(ar);
            }
        }

        Start();

        IConnector connector = GetConnector();
        GenerateServerDtoBase(connector, dtoBase);
        GenerateServerDto(connector, dto);
        GenerateServerPrimaryKeys(connector, primaryKeys);
        GenerateController(connector, controllers);
        GenerateCore(connector, core);
        GenerateBuilder(connector, builder);

        DataSet dataSet = GenerateDataSet();

        FileStream fs = File.OpenWrite(Path.Combine(projectDir, "DataSetSchema.xml"));

        dataSet.WriteXmlSchema(fs);

        fs.Close();

        GenerateDatabaseMetadata(dataSet, connector, projectDir);

        Stop();

        if (_doCreateProject)
        {
            serverStuffProject!.OnProjectFileGenerated = proj =>
            {
                XmlDocument doc = new();
                doc.Load(proj.ProjectPath);
                doc.CreateNavigator()!
                    .SelectSingleNode("/Project/PropertyGroup[1]")!
                    .AppendChild("<NoDefaultLaunchSettingsFile>true</NoDefaultLaunchSettingsFile>");
                doc.Save(proj.ProjectPath);
            };
            serverStuffProject!.Compile();
        }

        return serverStuffProject;
    }
    private Generator() { }
    #region Rendering
    internal void RenderContractClass(ContractModel model)
    {
        model.Contract = _contract;
    }

    internal void RenderModelClass(ModelModel model)
    {
        model.Contract = _contract;
        PocoHolder holder = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = holder.Type.Namespace;
        model.ClassName = $"{holder.Type.Name}_1";
        model.BaseClasses.Add(holder.Type.Name);
        Util.AddNamespaces(model.Usings, holder.Type);
        Util.AddNamespaces(model.Usings, typeof(NotImplementedException));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, typeof(Contract));
        model.Usings.Add(s_dependencyInjection);
        Stack<PocoHolder> stack = new();
        do
        {
            stack.Push(holder);
            if (_pocos.TryGetValue(holder.Type.BaseType!.FullName!, out PocoHolder? ph))
            {
                holder = ph;
            }
            else
            {
                holder = null!;
            }
        }
        while (holder is { });
        while(stack.Count > 0)
        {
            holder = stack.Pop();
            foreach (PropertyModel pm in holder.Properties)
            {
                if (pm.IsCollection)
                {
                    Util.AddNamespaces(model.Usings, typeof(List<>));
                }
                Util.AddNamespaces(model.Usings, pm.ItemType);
                model.Properties.Add(pm);
            }
        }
    }

    internal void RenderServerDto(DtoModel model)
    {
        model.Contract = _contract;
        PocoHolder holder = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = $"{(string.IsNullOrEmpty(holder.Type.Namespace) ? string.Empty : $"{holder.Type.Namespace}.")}{s_internal}";
        model.ClassName = $"{holder.Type.Name}Dto";
        model.BaseClasses.Add(holder.Type.Name);
        if (holder.Kind is PocoKind.Entity)
        {
            Util.AddNamespaces(model.Usings, typeof(IEntity));
            Util.AddNamespaces(model.Usings, typeof(IPrimaryKey));
            Util.AddNamespaces(model.Usings, typeof(IEntityProperty));
            Util.AddNamespaces(model.Usings, typeof(Access));
            model.BaseClasses.Add(Util.MakeTypeName(typeof(IEntity)));
        }
        else
        {
            model.BaseClasses.Add(Util.MakeTypeName(typeof(IPoco)));
        }
        Util.AddNamespaces(model.Usings, typeof(IPoco));
        Util.AddNamespaces(model.Usings, holder.Type);
        Util.AddNamespaces(model.Usings, typeof(IProperty));
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        Util.AddNamespaces(model.Usings, typeof(IProcessingInfo));
        model.Usings.Add(s_dependencyInjection);
        model.PocoKind = holder.Kind;
        PropertyModel self = GetSelfPropertyModel(holder);
        model.Properties.Insert(0, self);
        Stack<PocoHolder> stack = new();
        do
        {
            stack.Push(holder);
            if (_pocos.TryGetValue(holder.Type.BaseType!.FullName!, out PocoHolder? ph))
            {
                holder = ph;
            }
            else
            {
                holder = null!;
            }
        }
        while (holder is { });
        while (stack.Count > 0)
        {
            holder = stack.Pop();

            foreach (PropertyModel pm in holder.Properties)
            {
                if (pm.IsCollection)
                {
                    Util.AddNamespaces(model.Usings, typeof(List<>));
                }
                Util.AddNamespaces(model.Usings, pm.ItemType);
                model.Properties.Add(pm);
            }
        }
        if (holder.Kind is PocoKind.Entity)
        {
            model.PropertyUse = BuildPropertyUse(holder.PropertyUse!, 0, self, model.Usings);
        }
    }
    internal IEnumerable<PropertyModel> GetAllProperties(PocoHolder holder)
    {
        PocoHolder cur = holder;
        Stack<PocoHolder> stack = new();
        do
        {
            stack.Push(cur);
            if (_pocos.TryGetValue(cur.Type.BaseType!.FullName!, out PocoHolder? ph))
            {
                cur = ph;
            }
            else
            {
                cur = null!;
            }
        }
        while (cur is { });
        while(stack.Count > 0)
        {
            cur = stack.Pop();
            foreach(PropertyModel pm in cur.Properties) 
            {
                yield return pm;
            }
        }
    }

    private static PropertyModel GetSelfPropertyModel(PocoHolder handler)
    {
        return new()
        {
            Name = "Self",
            IsCollection = false,
            IsNullable = false,
            IsPrimaryKey = false,
            IsReadOnly = true,
            ItemType = handler.Type,
            ItemTypeName = Util.MakeTypeName(handler.Type),
            PocoKind = handler.Kind,
            Type = handler.Type,
            TypeName = Util.MakeTypeName(handler.Type),
            IsSelf = true,
        };
    }

    private PropertyUseModel? BuildPropertyUse(PropertyUse propertyUse, int level, PropertyModel? self, HashSet<string> usings)
    {
        PropertyUseModel? result = new()
        {
            Level = level,
            PropertyName = self is { } ? $"{self.ItemTypeName}Dto.s_{self.Name}Property" : $"{propertyUse.Parent!.Type!.Name.Replace("_1", "Dto")}.s_{propertyUse.Name}Property"
        };
        result.Flags = propertyUse.Flags;
        if (self is null)
        {
            usings.Add($"{(string.IsNullOrEmpty(propertyUse.Parent!.Type!.Namespace) ? string.Empty : $"{propertyUse.Parent!.Type!.Namespace}.")}{s_internal}");
        }
        else
        {
            usings.Add($"{(string.IsNullOrEmpty(self.ItemType.Namespace) ? string.Empty : $"{self.ItemType.Namespace}.")}{s_internal}");
        }
        if ((propertyUse.Children?.Count ?? 0) > 0)
        {
            foreach (PropertyUse child in propertyUse.Children!)
            {
                PropertyUseModel? next = BuildPropertyUse(child, level + 1, null, usings);
                if(next is { })
                {
                    if(result.Children is null)
                    {
                        result.Children = [];
                    }
                    result.Children.Add(next);
                }
            }
        }
        return result;
    }

    internal void RenderServerDtoBase(DtoBaseModel model)
    {
        model.Contract = _contract;
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = handler.Type.Namespace;
        model.ClassName = handler.Type.Name;
        if(_pocos.TryGetValue(handler.Type.BaseType.FullName!,  out PocoHolder? ph))
        {
            Util.AddNamespaces(model.Usings, ph.Type);
            model.BaseClasses.Add(Util.MakeTypeName(ph.Type));
        }
        foreach (PropertyModel pm in handler.Properties)
        {
            if (pm.IsCollection)
            {
                Util.AddNamespaces(model.Usings, typeof(List<>));
            }
            Util.AddNamespaces(model.Usings, pm.ItemType);
            model.Properties.Add(pm);
        }
    }
    internal void RenderServerPrimaryKey(PrimaryKeyModel model)
    {
        model.Contract = _contract;
        PocoHolder handler = (PocoHolder)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        model.Namespace = handler.Type.Namespace;
        model.ClassName = $"{handler.Type.Name}PrimaryKey";
        model.ArgumentClass = handler.Type.Name;
        model.BaseClasses.Add(Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType([handler.Type])));
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        Util.AddNamespaces(model.Usings, typeof(IPrimaryKey<>));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        model.Usings.Add(s_dependencyInjection);
        model.Usings.Add($"{(string.IsNullOrEmpty(handler.Type.Namespace) ? string.Empty : $"{handler.Type.Namespace}.")}{s_internal}");
        foreach (PropertyModel pm in GetAllProperties(handler).Where(p => p.IsPrimaryKey).OrderBy(p => p.Name))
        {
            Util.AddNamespaces(model.Usings, pm.ItemType);
            model.Properties.Add(pm);
        }
    }
    internal void RenderCore(ServerExtensionsModel model)
    {
        model.Contract = _contract;
        model.ClassName = $"{_contract.GetType().Name}Extensions";
        model.AddMethodName = $"Add{_contract.GetType().Name}";
        model.Namespace = _contract.GetType().Namespace;
        model.Usings.Add(s_dependencyInjection);
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        Util.AddNamespaces(model.Usings, typeof(IProcessingInfo));
        Util.AddNamespaces(model.Usings, typeof(ProcessingInfo));
        Util.AddNamespaces(model.Usings, typeof(ServerPocoContext));
        foreach (PocoHolder ph in _pocos.Values)
        {
            Util.AddNamespaces(model.Usings, ph.Type);
            model.Usings.Add($"{(string.IsNullOrEmpty(ph.Type.Namespace) ? string.Empty : $"{ph.Type.Namespace}.")}{s_internal}");

            ServiceModel sm = new()
            {
                ServiceTypeName = Util.MakeTypeName(ph.Type),
                Lifetime = ServiceLifetime.Scoped,
            };
            sm.ImplTypeName = $"{sm.ServiceTypeName}Dto";
            model.Services.Add(sm);
            if(ph.Kind is PocoKind.Entity)
            {
                sm = new()
                {
                    ServiceTypeName = Util.MakeTypeName(typeof(IPrimaryKey<>).MakeGenericType([ph.Type])),
                    Lifetime = ServiceLifetime.Scoped,
                };
                sm.ImplTypeName = $"{Util.MakeTypeName(ph.Type)}PrimaryKey";
                model.Services.Add(sm);
            }
        }
    }
    internal void RenderController(ControllerModel model)
    {
        model.Contract = _contract;
        model.ClassName = $"{_contract.GetType().Name}Controller";
        model.Namespace = _contract.GetType().Namespace;
        Util.AddNamespaces(model.Usings, typeof(Controller));
        Util.AddNamespaces(model.Usings, typeof(RouteAttribute));
        Util.AddNamespaces(model.Usings, typeof(JsonSerializer));
        Util.AddNamespaces(model.Usings, typeof(JsonSerializerOptions));
        Util.AddNamespaces(model.Usings, typeof(IPocoContext));
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        model.BaseClasses.Add(Util.MakeTypeName(typeof(Controller)));
        model.BuilderClassName = $"{_contract.GetType().Name}Builder";
        foreach (MethodHolder mh in _methods.Values)
        {
            MethodModel mm = new()
            {
                Name = mh.Name,
                Route = $"{(!string.IsNullOrEmpty(_contract.RoutePrefix) ? $"/{_contract.RoutePrefix}" : string.Empty)}/{mh.Name}",
                ReturnItemTypeName = Util.MakeTypeName(mh.ReturnItemType),
                IsCollectionReturn = mh.IsCollectionReturn,
            };
            foreach(ParameterHolder ph in mh.Parameters)
            {
                ParameterModel pm = new()
                {
                    Name = ph.Name,
                    TypeName = Util.MakeTypeName(ph.Type),
                    IsNullable = ph.IsNullable,
                    Type = ph.Type,
                };
                Util.AddNamespaces(model.Usings, ph.Type);
                mm.Parameters.Add(pm);
                mm.Route += $"/{{{ph.Name}}}";
            }
            foreach (ParameterModel pm in mm.Parameters)
            {
                pm.Variable = $"{pm.Name}Var";
            }
            mm.Route = Regex.Replace(mm.Route, "/{2,}", "/");
            if(mh.Authorize is { })
            {
                List<string> parts = [];
                if (!string.IsNullOrEmpty(mh.Authorize.Policy))
                {
                    parts.Add($"Policy = \"{mh.Authorize.Policy}\"");
                }
                if (!string.IsNullOrEmpty(mh.Authorize.Roles))
                {
                    parts.Add($"Roles = \"{mh.Authorize.Roles}\"");
                }
                if (!string.IsNullOrEmpty(mh.Authorize.AuthenticationSchemes))
                {
                    parts.Add($"AuthenticationSchemes = \"{mh.Authorize.AuthenticationSchemes}\"");
                }
                if(parts.Count > 0)
                {
                    Util.AddNamespaces(model.Usings, typeof(AuthorizeAttribute));
                    mm.Authorize = string.Join(", ", parts);
                }
            }
            mm.PropertyUse = BuildPropertyUse(
                mh.PropertyUse, 
                0, 
                GetSelfPropertyModel(
                    _pocos[$"{(
                        !string.IsNullOrEmpty(mh.ReturnItemType.Namespace) 
                        ? $"{mh.ReturnItemType.Namespace}." 
                        : string.Empty)}{mm.ReturnItemTypeName}"]
                    ), 
                model.Usings
                );
            model.Methods.Add(mm);
        }
    }
    internal void RenderDatabase(DatabaseModel model)
    {
        DataSet dataSet = (DataSet)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        HashSet<Type> types = [];
        foreach(DataTable table in dataSet.Tables)
        {
            foreach (DataColumn col in table.Columns)
            {
                types.Add(col.DataType);
            }
        }
        if(types.Count > 0)
        {
            model.DataTypeMap = [];
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    model.DataTypeMap.Add(
                        type, 
                        new DataTypeModel { 
                            Name = "char", 
                            Size = Enum.GetNames(type).Select(v => v.Length).Max(),
                            Check = Enum.GetNames(type).ToList(),
                        }
                    );
                }
                else if (type == typeof(string))
                {
                    model.DataTypeMap.Add(type, new DataTypeModel { Name = "varchar" });
                }
                else if (type == typeof(int))
                {
                    model.DataTypeMap.Add(type, new DataTypeModel { Name = "integer" });
                }
                else if (type == typeof(DateOnly))
                {
                    model.DataTypeMap.Add(type, new DataTypeModel { Name = "date" });
                }
                else if (type == typeof(TimeOnly))
                {
                    model.DataTypeMap.Add(type, new DataTypeModel { Name = "time" });
                }
                else if (type == typeof(DateTime))
                {
                    model.DataTypeMap.Add(type, new DataTypeModel { Name = "timestamp" });
                }
            }
        }
        model.DataSet = dataSet;
    }
    internal void RenderBuilder(BuilderModel model)
    {
        model.Contract = _contract;
        model.ClassName = $"{_contract.GetType().Name}Builder";
        model.Namespace = _contract.GetType().Namespace;
        Util.AddNamespaces(model.Usings, typeof(IServiceProvider));
        Util.AddNamespaces(model.Usings, typeof(IEnumerable<>));
        foreach (MethodHolder mh in _methods.Values)
        {
            MethodModel mm = new()
            {
                Name = mh.Name,
                ReturnItemTypeName = Util.MakeTypeName(mh.ReturnItemType),
                IsCollectionReturn = mh.IsCollectionReturn,
            };
            Util.AddNamespaces(model.Usings, mh.ReturnItemType);
            foreach (ParameterHolder ph in mh.Parameters)
            {
                ParameterModel pm = new()
                {
                    Name = ph.Name,
                    TypeName = Util.MakeTypeName(ph.Type),
                    IsNullable = ph.IsNullable,
                    Type = ph.Type,
                };
                Util.AddNamespaces(model.Usings, ph.Type);
                mm.Parameters.Add(pm);
            }
            model.Methods.Add(mm);
        }
    }
    #endregion Rendering
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }
    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
    }
    private DataSet GenerateDataSet()
    {
        DataSet result = new(_contract.GetType().Name!);

        List<string> path = [];
        foreach (PocoHolder ph in _pocos.Values.Where(p => p.Kind is PocoKind.Entity))
        {
            string name = ph.Type.Name;
            for (int i = 1; result.Tables.Contains(name); ++i)
            {
                name = $"{ph.Type.Name}_{i}";
            }
            ph.TableName = name;
            DataTable table = new(name);
            result.Tables.Add(table);
            List<DataColumn> pk = [];
            List<DataColumn> fk = [];
            if (_pocos.TryGetValue(ph.Type.BaseType!.FullName!, out PocoHolder? baseHolder))
            {
                path.Clear();
                path.Add("base");
                DFM_GetForeignKeys(baseHolder, table, path, pk, fk);
                if (fk.Count > 0)
                {
                    ph.ForeignKey = fk.ToArray();
                }
            }
            foreach (PropertyModel pm in ph.Properties)
            {
                if(!pm.IsCollection)
                {
                    if(pm.PocoKind is PocoKind.None)
                    {
                        DataColumn col = new(pm.Name, pm.ItemType);
                        if (pm.IsNullable)
                        {
                            col.AllowDBNull = true;
                        }
                        if (pm.IsPrimaryKey)
                        {
                            pk.Add(col);
                        }
                        table.Columns.Add(col);
                    }
                    else if(_pocos.TryGetValue(pm.Type.FullName!, out PocoHolder? holder))
                    {
                        fk.Clear();
                        path.Clear();
                        path.Add(pm.Name);
                        DFM_GetForeignKeys(holder, table, path, pm.IsPrimaryKey ? pk : null, fk);
                        if (fk.Count > 0)
                        {
                            pm.ForeignKey = fk.ToArray();
                        }
                    }
                }
            }
            if (pk.Count > 0)
            {
                table.PrimaryKey = pk.ToArray();
            }
        }
        foreach (PocoHolder ph in _pocos.Values.Where(p => p.Kind is PocoKind.Entity))
        {
            if(ph.ForeignKey is { })
            {
                DataTable parent = result.Tables[_pocos[ph.Type.BaseType!.FullName!].TableName]!;
                DataTable child = result.Tables[ph.TableName]!;
                ForeignKeyConstraint fkcn = new(parent.PrimaryKey, ph.ForeignKey);
                fkcn.ConstraintName = $"FK_{child.TableName}_{child.Constraints.Count + 1}";
                child.Constraints.Add(fkcn);
            }
            foreach (PropertyModel pm in ph.Properties)
            {
                if (pm.IsCollection)
                {
                    if (!pm.IsComposition)
                    {
                        string name = $"{ph.Type.Name}_{pm.Name}";
                        for (int i = 1; result.Tables.Contains(name); ++i)
                        {
                            name = $"{ph.Type.Name}_{pm.Name}_{i}";
                        }
                        DataTable table = new(name);
                        result.Tables.Add(table);
                        List<DataColumn> pk = [];
                        DataTable parent = result.Tables[ph.TableName]!;
                        foreach (DataColumn col in parent.PrimaryKey)
                        {
                            DataColumn col1 = new DataColumn(col.ColumnName, col.DataType);
                            table.Columns.Add(col1);
                            pk.Add(col1);
                        }
                        ForeignKeyConstraint fkcn = new(parent.PrimaryKey, pk.ToArray());
                        fkcn.ConstraintName = $"FK_{table.TableName}_{table.Constraints.Count + 1}";
                        table.Constraints.Add(fkcn);

                        if (_pocos.TryGetValue(pm.ItemType.FullName!, out PocoHolder? holder))
                        {
                            DataTable child = result.Tables[holder.TableName]!;
                            int pos = pk.Count;
                            foreach (DataColumn col in child.PrimaryKey)
                            {
                                string col_name = col.ColumnName;
                                for (int i = 1; table.Columns.Contains(col_name); ++i)
                                {
                                    col_name = $"{col.ColumnName}_{i}";
                                }
                                DataColumn col1 = new DataColumn(col_name, col.DataType);
                                table.Columns.Add(col1);
                                pk.Add(col1);
                            }
                            fkcn = new(child.PrimaryKey, pk.Skip(pos).ToArray());
                            fkcn.ConstraintName = $"FK_{table.TableName}_{table.Constraints.Count + 1}";
                            table.Constraints.Add(fkcn);
                        }
                        else
                        {
                            DataColumn col = new(pm.Name, pm.ItemType);
                            if (pm.IsNullable)
                            {
                                col.AllowDBNull = true;
                            }
                            table.Columns.Add(col);
                            string col_name = "id";
                            for (int i = 1; table.Columns.Contains(col_name); ++i)
                            {
                                col_name = $"id_{i}";
                            }
                            col = new(col_name, typeof(ulong));
                            col.AutoIncrement = true;
                            pk.Add(col);
                            table.Columns.Add(col);
                        }
                        if (pk.Count > 0)
                        {
                            table.PrimaryKey = pk.ToArray();
                        }
                    }
                    else if (_pocos.TryGetValue(pm.ItemType.FullName!, out PocoHolder? holder))
                    {
                        DataTable child = result.Tables[holder.TableName]!;
                        DataTable parent = result.Tables[ph.TableName]!;
                        List<DataColumn> fk = [];
                        foreach (DataColumn col in parent.PrimaryKey)
                        {
                            string col_name = $"{parent.TableName}_{col.ColumnName}";
                            for (int i = 1; child.Columns.Contains(col_name); ++i)
                            {
                                col_name = $"{parent.TableName}_{col.ColumnName}_{i}";
                            }
                            DataColumn col1 = new DataColumn(col_name, col.DataType);
                            child.Columns.Add(col1);
                            fk.Add(col1);
                        }
                        ForeignKeyConstraint fkcn = new(parent.PrimaryKey, fk.ToArray());
                        fkcn.ConstraintName = $"FK_{child.TableName}_{child.Constraints.Count + 1}";
                        child.Constraints.Add(fkcn);
                    }
                }
                else 
                {
                    if (pm.ForeignKey is { })
                    {
                        DataTable parent = result.Tables[_pocos[pm.Type.FullName!].TableName]!;
                        DataTable child = result.Tables[ph.TableName]!;
                        ForeignKeyConstraint fkcn = new(parent.PrimaryKey, pm.ForeignKey);
                        fkcn.ConstraintName = $"FK_{child.TableName}_{child.Constraints.Count + 1}";
                        child.Constraints.Add(fkcn);
                    }
                }
            }
        }
        //XmlDocument xml = new();
        //xml.LoadXml(result.GetXmlSchema());
        //XPathNodeIterator ni = xml.CreateNavigator()!.Select("//*[@msdata:DataType]/@msdata:DataType", _resolver);
        //HashSet<Type> notMapped = [];
        //while (ni.MoveNext())
        //{
        //    string[] parts = ni.Current!.Value.Split(",", 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    notMapped.Add(Assembly.Load(new AssemblyName(parts[1])).GetType(parts[0], true)!);
        //}

        //foreach(Type t in notMapped)
        //{
        //    Console.WriteLine($"not mapped: {t}");
        //}


        return result;
    }

    private void DFM_GetForeignKeys(PocoHolder holder, DataTable table, List<string> path, List<DataColumn>? pk, List<DataColumn>? fk)
    {
        if (_pocos.TryGetValue(holder.Type.BaseType!.FullName!, out PocoHolder? baseHolder))
        {
            path.Add("base");
            DFM_GetForeignKeys(baseHolder, table, path, pk, fk);
            path.RemoveAt(path.Count - 1);
        }
        foreach (PropertyUse pu in holder.PropertyUse!.Children!.Where(v => v.Flags.HasFlag(PropertyUseFlags.PrimaryKey)).OrderBy(v => v.Name))
        {
            if (holder.Properties.Where(p => p.Name.Equals(pu.Name)).FirstOrDefault() is PropertyModel pm)
            {
                path.Add(pu.Name);
                if (_pocos.TryGetValue(pm.ItemType!.FullName!, out PocoHolder? ph))
                {
                    DFM_GetForeignKeys(ph, table, path, pk, fk);
                }
                else 
                {
                    DataColumn col = new(string.Join('_', path), pm.ItemType);
                    if (pm.IsNullable)
                    {
                        col.AllowDBNull = true;
                    }
                    pk?.Add(col);
                    fk?.Add(col);
                    table.Columns.Add(col);
                }
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    private void DFM_CopyPropertyUses(PropertyUse src, PropertyUse dst)
    {
        if (src.Children is { })
        {
            dst.Children ??= [];
            foreach (PropertyUse pu in src.Children)
            {
                PropertyUse? found = null;
                for (int i = 0; i < dst.Children.Count; ++i)
                {
                    if (dst.Children[i].Name.Equals(pu.Name))
                    {
                        found = dst.Children[i];
                        break;
                    }
                }
                if (found is null)
                {
                    found = new PropertyUse { Name = pu.Name, Type = pu.Type, Parent = dst };
                    dst.Children.Add(found);
                }
                if (found is { })
                {
                    found.Flags |= pu.Flags;
                    DFM_CopyPropertyUses(pu, found);
                }
            }
        }
    }
    private void OutputEvent(ContractEventArgs args)
    {
        if (args.EventKind is ContractEventKind.Property)
        {
            if (args.Poco == _currentObject)
            {
                _currentPath.Clear();
            }
            if (_propertyUses.Count == 0)
            {
                _currentMethod!.PropertyUse.Type = args.Poco!.GetType();
                _currentMethod.PropertyUse.Name = s_self;
                _propertyUses.Add(args.Poco!, _currentMethod.PropertyUse);
                if (!_allPropertyUses.TryGetValue(_currentMethod.PropertyUse.Type, out List<PropertyUse>? value))
                {
                    _allPropertyUses.Add(_currentMethod.PropertyUse.Type, [_currentMethod.PropertyUse]);
                }
                else
                {
                    value.Add(_currentMethod.PropertyUse);
                }
            }
            bool found = false;
            if (_propertyUses[args.Poco!].Children is { })
            {
                foreach (PropertyUse pu in _propertyUses[args.Poco!].Children!)
                {
                    if (pu.Name.Equals(args.Property))
                    {
                        _lastPropertyUse = pu;
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                _propertyUses[args.Poco!].Children ??= [];
                PropertyUse next = new()
                {
                    Name = args.Property!,
                    Parent = _propertyUses[args.Poco!]
                };
                _propertyUses[args.Poco!].Children!.Add(next);
                if (args.Value is { })
                {
                    next.Type = args.Value.GetType();
                    _propertyUses.Add(args.Value, next);
                    if (!_allPropertyUses.TryGetValue(next.Type, out List<PropertyUse>? value))
                    {
                        _allPropertyUses.Add(next.Type, [next]);
                    }
                    else
                    {
                        value.Add(next);
                    }
                }
                _lastPropertyUse = next;
            }
            _currentPath.Add(_lastPropertyUse!);
            _lastPropertyUse!.Flags |= PropertyUseFlags.Expected;
        }
        else if (args.EventKind is ContractEventKind.Mandatory)
        {
            PropertyUse? cur = _lastPropertyUse;
            while (cur is { })
            {
                cur.Flags |= PropertyUseFlags.Mandatory;
                cur = cur.Parent;
            }
        }
    }
    private void GenerateBuilder(IConnector connector, string targetDir)
    {
        TextReader contractSource = connector.Get("/Server/Builder");
        File.WriteAllText(Path.Combine(targetDir, $"{_contract.GetType().Name}Builder.cs"), contractSource.ReadToEnd());
    }
    private void GenerateCore(IConnector connector, string targetDir)
    {
        TextReader contractSource = connector.Get("/Server/ServerExtensions");
        File.WriteAllText(Path.Combine(targetDir, $"{_contract.GetType().Name}Extensions.cs"), contractSource.ReadToEnd());
    }
    private void GenerateController(IConnector connector, string targetDir)
    {
        TextReader contractSource = connector.Get("/Server/Controller");
        File.WriteAllText(Path.Combine(targetDir, $"{_contract.GetType().Name}Controller.cs"), contractSource.ReadToEnd());
    }
    private void GenerateServerDtoBase(IConnector connector, string targetDir)
    {
        foreach (PocoHolder ph in _pocos.Values)
        {
            TextReader contractSource = connector.Get("/Server/DtoBase", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}.cs"), contractSource.ReadToEnd());
        }
    }
    private void GenerateServerDto(IConnector connector, string targetDir)
    {
        foreach (PocoHolder ph in _pocos.Values)
        {
            TextReader contractSource = connector.Get("/Server/Dto", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}Dto.cs"), contractSource.ReadToEnd());
        }
    }
    private void GenerateServerPrimaryKeys(IConnector connector, string targetDir)
    {
        foreach (PocoHolder ph in _pocos.Values.Where(ph => ph.Kind is PocoKind.Entity))
        {
            TextReader contractSource = connector.Get("/Server/PrimaryKey", ph);
            File.WriteAllText(Path.Combine(targetDir, $"{ph.Type.Name}PrimaryKey.cs"), contractSource.ReadToEnd());
        }
    }
    private void GenerateDatabaseMetadata(DataSet dataSet, IConnector connector, string targetDir, string dialect = "mssql")
    {
        TextReader contractSource = connector.Get($"/Auxiliary/Database.{dialect}", dataSet);
        File.WriteAllText(Path.Combine(targetDir, $"CreateDatabase.sql"), contractSource.ReadToEnd());
    }
    private void ProcessContract()
    {
        Start();

        IConnector connector = GetConnector();


        if(_contractProcessingDir is { } && Directory.Exists(_contractProcessingDir))
        {
            Directory.Delete(_contractProcessingDir, true);
        }
        if(_contractProcessingDir is { })
        {
            Directory.CreateDirectory(_contractProcessingDir);
        }

        using (Project contractProcessor = Project.Create(new ProjectOptions
        {
            Name = "ContractProcessor",
            ProjectDir = _contractProcessingDir,
            TargetFramework = _serverTargetFramework,
        }))
        {
            contractProcessor.AddPackage("Microsoft.Extensions.DependencyInjection", "8.0.0");
            foreach (string ar in _additionalReferences)
            {
                contractProcessor.AddReference(ar);
            }
            contractProcessor.AddReference(_contract.GetType().Assembly.Location);
            TextReader contractSource = connector.Get("/Auxiliary/Contract");
            File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"Contract.cs"), contractSource.ReadToEnd());
            void eventHandler1(ContractEventArgs args)
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    if (_pocos.ContainsKey(args.PocoType.FullName!))
                    {
                        throw new InvalidOperationException("TODO: InvalidOperationException");
                    }
                    PocoHolder ph = new() { Type = args.PocoType, Kind = args.PocoKind };
                    _pocos.Add(args.PocoType.FullName!, ph);
                }
            }
            _contract.ContractProcessing += eventHandler1;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler1;

            foreach (PocoHolder ph in _pocos.Values)
            {
                PocoHolder cur = ph;
                do
                {
                    if (_pocos.TryGetValue(cur.Type.BaseType!.FullName!, out PocoHolder? ph1))
                    {
                        ph1.Inheritors.Add(cur.Type.FullName!);
                        foreach(string s in cur.Inheritors)
                        {
                            ph1.Inheritors.Add(s);
                        }
                        cur = ph1;
                    }
                    else
                    {
                        cur = null!;
                    }
                }
                while (cur is { });
            }

            foreach (PocoHolder ph in _pocos.Values)
            {
                BuildProperties(ph);
            }

            void eventHandler2(ContractEventArgs args)
            {
                if (args.EventKind is ContractEventKind.Poco)
                {
                    TextReader contractSource = connector.Get("/Auxiliary/Model", _pocos[args.PocoType.FullName!]);
                    File.WriteAllText(Path.Combine(contractProcessor.ProjectDir, $"{args.PocoType.Name}.cs"), contractSource.ReadToEnd());
                }
            }
            _contract.ContractProcessing += eventHandler2;
            _contract.ConfigurePocos();
            _contract.ContractProcessing -= eventHandler2;

            contractProcessor.Compile();

            Assembly ass = contractProcessor.CompiledAssembly!;

            IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                string typeName = $"{(string.IsNullOrEmpty(_contract.GetType().Namespace) ? string.Empty : $"{_contract.GetType().Namespace}.")}Contract_1";
                services.AddScoped(
                    typeof(Contract),
                    ass.GetType(typeName, true)!
                );
                foreach (string serviceTypeName in _pocos.Keys)
                {
                    Type implementationType = ass.GetType($"{_pocos[serviceTypeName].Type.FullName}_1", true)!;
                    services.AddTransient(implementationType.BaseType!, implementationType);
                    if (_pocos[serviceTypeName].Kind is PocoKind.Entity)
                    {
                        _pocos[serviceTypeName].PropertyUse = new()
                        {
                            Type = implementationType,
                            Name = s_self,
                        };
                    }
                }
            }).Build();
            Contract contract = host.Services.GetRequiredService<Contract>();

            contract.ContractProcessing += Contract_ContractProcessing;

            foreach (MethodInfo mi in contract.GetType().GetMethods())
            {
                //Console.WriteLine($"{mi}, {mi.GetBaseDefinition().DeclaringType}");
                if (
                    mi.GetBaseDefinition().DeclaringType != typeof(ContractBase)
                    && mi.GetBaseDefinition().DeclaringType != typeof(object)
                    && !mi.IsSpecialName
                )
                {
                    _currentMethod = new MethodHolder
                    { 
                        Name = mi.Name,
                        ReturnType = mi.ReturnType,
                    };
                    _currentMethod.ReturnItemType = mi.ReturnType;
                    if(mi.ReturnType == typeof(void))
                    {
                        throw new InvalidOperationException($"void return is forbidden: {mi}");
                    }
                    if (mi.ReturnType.IsGenericType)
                    {
                        if(mi.ReturnType.GetGenericTypeDefinition() != typeof(List<>))
                        {
                            throw new InvalidOperationException($"Only non generic or List<> return type allowed:{mi}!");
                        }
                        _currentMethod.IsCollectionReturn = mi.ReturnType.GetGenericTypeDefinition() == typeof(List<>);
                        _currentMethod.ReturnItemType = mi.ReturnType.GetGenericArguments()[0];
                    }
                    foreach (ParameterInfo par in mi.GetParameters())
                    {
                        ParameterHolder ph = new()
                        {
                            Name = par.Name!,
                            Type= par.ParameterType,
                            IsNullable = _nullabilityInfoContext.Create(par).ReadState is NullabilityState.Nullable,
                        };
                        _currentMethod.Parameters.Add(ph);

                    }
                    _currentMethod.Authorize = mi.GetCustomAttribute<AuthorizeAttribute>();
                    _methods.Add(_currentMethod.Name, _currentMethod);
                    _lastPropertyUse = _currentMethod!.PropertyUse;
                    _currentMethod!.PropertyUse.Flags |= PropertyUseFlags.Expected;
                    try
                    {
                        mi.Invoke(contract, new object[mi.GetParameters().Length]);
                    }
                    catch (TargetInvocationException tiex)
                    {
                        if (tiex.InnerException is NotImplementedException) { }
                    }

                    _currentMethod = null;
                    _propertyUses.Clear();
                }
            }

            contract.ConfigurePocos();

            foreach (PocoHolder ph in _pocos.Values.Where(v => v.Kind is PocoKind.Entity))
            {
                foreach(string inhe in ph.Inheritors)
                {
                    DFM_CopyPropertyUses(ph.PropertyUse!, _pocos[inhe].PropertyUse!);
                }
            }

            foreach (PocoHolder ph in _pocos.Values.Where(v => v.Kind is PocoKind.Entity))
            {

                if(!GetAllProperties(ph).Any(pm => pm.IsPrimaryKey)) 
                {
                    throw new InvalidOperationException($"An Entity must have at least one PrimaryKey defined, but {ph.Type} has not!");
                }
                if(_allPropertyUses.TryGetValue(ph.PropertyUse!.Type!, out List<PropertyUse>? list))
                {
                    foreach (PropertyUse pu in list)
                    {
                        DFM_CopyPropertyUses(ph.PropertyUse, pu);
                    }
                }
                SortPropertyUses(ph.PropertyUse);
            }
            foreach (MethodHolder mh in _methods.Values)
            {
                SortPropertyUses(mh.PropertyUse);
            }

        }

        Stop();
    }
    private void BuildProperties(PocoHolder ph)
    {
        foreach (PropertyInfo pi in ph.Type.GetProperties())
        {
            if(pi.DeclaringType == ph.Type)
            {
                NullabilityInfo ni = _nullabilityInfoContext.Create(pi);
                PocoKind pocoKind = PocoKind.None;
                bool isCollection = false;
                Type itemType = pi.PropertyType;
                if (itemType.IsGenericType)
                {
                    if (
                        pi.PropertyType.GetGenericTypeDefinition() != typeof(List<>)
                        && pi.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)
                    )
                    {
                        throw new InvalidOperationException($"TODO: InvalidOperationException: {pi.PropertyType}");
                    }
                    itemType = pi.PropertyType.GetGenericArguments()[0];
                    if (_pocos.TryGetValue(itemType.FullName!, out PocoHolder? ph1))
                    {
                        pocoKind = ph1.Kind;
                    }
                    isCollection = pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>);
                }
                else
                {
                    if (_pocos.TryGetValue(itemType.FullName!, out PocoHolder? ph1))
                    {
                        pocoKind = ph1.Kind;
                    }
                }
                PropertyModel pm = new()
                {
                    Name = pi.Name,
                    Type = pi.PropertyType,
                    TypeName = Util.MakeTypeName(pi.PropertyType),
                    ItemType = itemType,
                    ItemTypeName = Util.MakeTypeName(itemType),
                    IsReadOnly = !pi.CanWrite,
                    IsNullable = ni.ReadState is NullabilityState.Nullable,
                    PocoKind = pocoKind,
                    IsCollection = isCollection,
                };

                ph.Properties.Add(pm);
            }
        }
    }
    private static void SortPropertyUses(PropertyUse propertyUse)
    {
        PropertyUseComparer puc = new();
        if (propertyUse.Children is { })
        {
            propertyUse.Children.Sort(puc);
            foreach (PropertyUse pu in propertyUse.Children)
            {
                SortPropertyUses(pu);
            }
        }
    }
    private static void PrintPropertyUse(PropertyUse propertyUse, int depth)
    {
        string flags = string.Empty;
        if (propertyUse.Flags != PropertyUseFlags.None)
        {
            flags = "(";
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.Expected))
            {
                flags += "E";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.Mandatory))
            {
                flags += "M";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.PrimaryKey))
            {
                flags += "P";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.AccessSelector))
            {
                flags += "A";
            }
            if (propertyUse.Flags.HasFlag(PropertyUseFlags.Composition))
            {
                flags += "C";
            }
            flags += ")";
        }
        Console.WriteLine($"{string.Format($"{{0, {depth * 4}}}", string.Empty)}{flags}{(propertyUse.Type is { } ? $"{propertyUse.Type}, " : string.Empty)}{propertyUse.Name}");
        if (propertyUse.Children is { })
        {
            foreach (PropertyUse pu in propertyUse.Children)
            {
                PrintPropertyUse(pu, depth + 1);
            }
        }
    }
    private void Contract_ContractProcessing(ContractEventArgs args)
    {
        if (
            args.EventKind is ContractEventKind.PrimaryKey
            || args.EventKind is ContractEventKind.AccessSelector
            || args.EventKind is ContractEventKind.Composition
            || args.EventKind is ContractEventKind.Output
        )
        {
            _currentContractEventKind = args.EventKind;
            _currentObject = args.Poco;
        }
        else if (args.EventKind is ContractEventKind.Poco)
        {
            _currentContractEventKind = ContractEventKind.None;
            _currentPoco = _pocos[args.PocoType.FullName!];
            _propertyUses.Clear();
        }
        else
        {
            if (_currentContractEventKind is ContractEventKind.Output)
            {
                OutputEvent(args);
            }
            else if (
                _currentContractEventKind is ContractEventKind.PrimaryKey 
                || _currentContractEventKind is ContractEventKind.AccessSelector
                || _currentContractEventKind is ContractEventKind.Composition
            )
            {
                PrimaryKeyOrAccessSelectorOrCompositionEvent(args);
            }
        }
    }
    private void PrimaryKeyOrAccessSelectorOrCompositionEvent(ContractEventArgs args)
    {
        if (args.EventKind is ContractEventKind.Property)
        {
            if(args.Poco == _currentObject)
            {
                _currentPath.Clear();
            }

            if (_propertyUses.Count == 0)
            {
                _propertyUses.Add(args.Poco!, _currentPoco!.PropertyUse!);
            }
            PropertyUse? found = null;
            if (_propertyUses[args.Poco!].Children is { })
            {
                foreach (PropertyUse pu in _propertyUses[args.Poco!].Children!)
                {
                    if (pu.Name.Equals(args.Property))
                    {
                        found = pu;
                        break;
                    }
                }
            }
            if (found is null)
            {
                _propertyUses[args.Poco!].Children ??= [];
                found = new()
                {
                    Name = args.Property!,
                    Parent = _propertyUses[args.Poco!]
                };
                _propertyUses[args.Poco!].Children!.Add(found);
                if (args.Value is { })
                {
                    found.Type = args.Value.GetType();
                    _propertyUses.Add(args.Value, found);
                }
            }
            _currentPath.Add(found);
            if(_currentContractEventKind is ContractEventKind.PrimaryKey)
            {
                if(args.Value is {} && args.Value.GetType() == _currentObject!.GetType())
                {
                    throw new InvalidOperationException($"Primary key cannot be the same type, but {_currentObject!.GetType()}.{string.Join('.', _currentPath.Select(pu => pu.Name))} is!");
                }
                if (_currentPath.Count > 1)
                {
                    throw new InvalidOperationException($"Primary key must have one property path, for {_currentPath.First().Type} got {string.Join('.', _currentPath.Select(pu => pu.Name))}!");
                }
                if (_currentPoco?.Properties.Where(pu => pu.Name.Equals(args.Property)).FirstOrDefault() is PropertyModel pm)
                {
                    pm.IsPrimaryKey = true;
                }
            }
            else if (_currentContractEventKind is ContractEventKind.Composition)
            {
                if (args.Value is { } && args.Value.GetType() == _currentObject!.GetType())
                {
                    throw new InvalidOperationException($"Composition cannot be the same type, but {_currentObject!.GetType()}.{string.Join('.', _currentPath.Select(pu => pu.Name))} is!");
                }
                if (_currentPath.Count > 1)
                {
                    throw new InvalidOperationException($"Composition must have one property path, for {_currentPath.First().Type} got {string.Join('.', _currentPath.Select(pu => pu.Name))}!");
                }
                if (_currentPoco?.Properties.Where(pu => pu.Name.Equals(args.Property)).FirstOrDefault() is PropertyModel pm)
                {
                    if(!pm.IsCollection || !_pocos.TryGetValue(pm.ItemType.FullName!, out PocoHolder? ph) || ph.Kind is not PocoKind.Entity)
                    {
                        throw new InvalidOperationException($"Composition is applicable only to entities collections, but {_currentPoco.Type}.{pm.Name} is not!");
                    }
                    pm.IsComposition = true;
                }
            }
            found.Flags |= _currentContractEventKind switch {
                ContractEventKind.PrimaryKey => PropertyUseFlags.PrimaryKey,
                ContractEventKind.AccessSelector => PropertyUseFlags.AccessSelector,
                _ => PropertyUseFlags.Composition
            };
            if (args.Value is { } && !_propertyUses.ContainsKey(args.Value))
            {
                _propertyUses.Add(args.Value, found);
            }
        }
        else if (args.EventKind is ContractEventKind.Done)
        {
            _propertyUses.Clear();
        }
    }
}

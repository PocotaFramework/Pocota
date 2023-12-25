using Net.Leksi.E6dWebApp;
using Net.Leksi.Pocota.Server;
using System.Data;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Net.Leksi.Pocota.ORMGenerator;

public class Generator: Runner
{
    private string _ormProjectDir = string.Empty;
    private Assembly _serverAssembly = null!;
    private Dialect _dialect = Dialect.MSSql;
    private Contract _contract = null!;
    private readonly Dictionary<string, PocoHolder> _pocos = [];
    private IServiceProvider _services = null;

    public static string CreateDatabaseFileName => "CreateDatabase.sql";
    public static string DataSetSchemaFileName => "DataSetSchema.xml";

    private Generator() { }

    public static Generator Create(Options options)
    {
        Generator generator = new();
        generator._ormProjectDir = options.ORMProjectDir;
        generator._serverAssembly = options.ServerAssembly;
        generator._dialect = options.Dialect;
        generator._contract = options.Contract;

        return generator;
    }
    public void Generate()
    {
        Start();

        _pocos.Clear();

        ProcessContract();

        IConnector connector = GetConnector();

        DataSet dataSet = GenerateDataSet();

        FileStream fs = File.OpenWrite(Path.Combine(_ormProjectDir, DataSetSchemaFileName));

        dataSet.WriteXmlSchema(fs);
        fs.Close();

        GenerateDatabaseMetadata(dataSet, connector, _ormProjectDir);

        Stop();
    }

    internal void RenderDatabase(DatabaseModel model)
    {
        DataSet dataSet = (DataSet)model.HttpContext.RequestServices.GetRequiredService<RequestParameter>().Parameter!;
        HashSet<Type> types = [];
        foreach (DataTable table in dataSet.Tables)
        {
            foreach (DataColumn col in table.Columns)
            {
                types.Add(col.DataType);
            }
        }
        if (types.Count > 0)
        {
            model.DataTypeMap = [];
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    model.DataTypeMap.Add(
                        type,
                        new DataTypeModel
                        {
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
    protected override void ConfigureBuilder(WebApplicationBuilder builder)
    {
        Type extensions = _serverAssembly.GetType($"{_contract.GetType().FullName}Extensions")!;
        MethodInfo mi = extensions.GetMethod($"Add{_contract.GetType().Name}")!;
        mi.Invoke(null, [ builder.Services ]);
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton(this);
    }

    protected override void ConfigureApplication(WebApplication app)
    {
        app.MapRazorPages();
        _services = app.Services;
    }
    private void ProcessContract()
    {
        _contract.ContractProcessing += _contract_ContractProcessing;
        _contract.ConfigurePocos();
        foreach(PocoHolder ph in _pocos.Values)
        {
            if (ph.PropertyUse!.Children is { })
            {
                foreach (PropertyUse pu in ph.PropertyUse.Children)
                {
                    if(ph.Properties.Where(p => p.EntityProperty == pu.Property).FirstOrDefault() is PropertyHolder prop)
                    {
                        if (pu.Flags.HasFlag(PropertyUseFlags.PrimaryKey))
                        {
                            prop.IsPrimaryKey = true;
                        }
                        if (pu.Flags.HasFlag(PropertyUseFlags.Composition))
                        {
                            prop.IsComposition = true;
                        }
                        if (pu.Flags.HasFlag(PropertyUseFlags.Auto))
                        {
                            prop.IsAuto = true;
                        }
                    }
                }
            }
        }
    }

    private void _contract_ContractProcessing(ContractEventArgs args)
    {
        if(args.PocoKind is PocoKind.Entity)
        {
            try
            {
                PocoHolder ph = new PocoHolder
                {
                    Type = _serverAssembly.GetType(args.PocoType.FullName!, true)!
                };
                ph.Poco = _services.GetRequiredService(ph.Type);
                ph.PropertyUse = ((IEntity)ph.Poco!).PropertyUse;
                foreach (PropertyInfo pi in ph.Type.GetProperties())
                {
                    if (pi.DeclaringType == ph.Type)
                    {
                        FieldInfo fi = ph.Poco.GetType().GetField($"s_{pi.Name}Property", BindingFlags.Static | BindingFlags.NonPublic)!;
                        PropertyHolder prop = new PropertyHolder
                        {
                            EntityProperty = (IEntityProperty)fi.GetValue(null)!,
                        };
                        ph.Properties.Add(prop);
                        ph.PropertiesByName.Add(prop.EntityProperty.Name, prop);
                    }
                }
                _pocos.Add(
                    args.PocoType.FullName!,
                    ph
                );
            }
            catch( Exception ex) 
            {
                throw new InvalidOperationException($"{_contract} and {_serverAssembly} are inconsistent!", ex);
            }
        }
    }

    private void GenerateDatabaseMetadata(DataSet dataSet, IConnector connector, string targetDir, string dialect = "mssql")
    {
        TextReader contractSource = connector.Get($"/{dialect}/Database", dataSet);
        File.WriteAllText(Path.Combine(targetDir, CreateDatabaseFileName), contractSource.ReadToEnd());
    }
    private DataSet GenerateDataSet()
    {
        DataSet result = new(_contract.GetType().Name!);

        List<string> path = [];
        foreach (PocoHolder ph in _pocos.Values)
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
            foreach (
                PropertyHolder pm in ph.PropertyUse!.Children!.Where(v => ph.PropertiesByName.ContainsKey(v.Property.Name))
                    .Select(v => ph.PropertiesByName[v.Property.Name])
            )
            {
                if (!pm.EntityProperty.IsCollection)
                {
                    if (pm.EntityProperty.PocoKind is PocoKind.None)
                    {
                        DataColumn col = new(pm.EntityProperty.Name, pm.EntityProperty.ItemType);
                        if (pm.EntityProperty.IsNullable)
                        {
                            col.AllowDBNull = true;
                        }
                        if (pm.IsPrimaryKey)
                        {
                            if (pm.IsAuto)
                            {
                                col.AutoIncrement = true;
                            }
                            pk.Add(col);
                        }
                        table.Columns.Add(col);
                    }
                    else if (_pocos.TryGetValue(pm.EntityProperty.Type.FullName!, out PocoHolder? holder))
                    {
                        fk.Clear();
                        path.Clear();
                        path.Add(pm.EntityProperty.Name);
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
        foreach (PocoHolder ph in _pocos.Values)
        {
            if (ph.ForeignKey is { })
            {
                DataTable parent = result.Tables[_pocos[ph.Type.BaseType!.FullName!].TableName]!;
                DataTable child = result.Tables[ph.TableName]!;
                ForeignKeyConstraint fkcn = new(parent.PrimaryKey, ph.ForeignKey);
                fkcn.ConstraintName = $"FK_{child.TableName}_{child.Constraints.Count + 1}";
                child.Constraints.Add(fkcn);
            }
            foreach (
                PropertyHolder pm in ph.PropertyUse!.Children!.Where(v => ph.PropertiesByName.ContainsKey(v.Property.Name))
                    .Select(v => ph.PropertiesByName[v.Property.Name])
            )
            {
                if (pm.EntityProperty.IsCollection)
                {
                    if (!pm.IsComposition)
                    {
                        string name = $"{ph.Type.Name}_{pm.EntityProperty.Name}";
                        for (int i = 1; result.Tables.Contains(name); ++i)
                        {
                            name = $"{ph.Type.Name}_{pm.EntityProperty.Name}_{i}";
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

                        if (_pocos.TryGetValue(pm.EntityProperty.ItemType.FullName!, out PocoHolder? holder))
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
                            DataColumn col = new(pm.EntityProperty.Name, pm.EntityProperty.ItemType);
                            if (pm.EntityProperty.IsNullable)
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
                    else if (_pocos.TryGetValue(pm.EntityProperty.ItemType.FullName!, out PocoHolder? holder))
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
                        DataTable parent = result.Tables[_pocos[pm.EntityProperty.Type.FullName!].TableName]!;
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
        foreach (PropertyUse pu in holder.PropertyUse!.Children!.Where(v => v.Flags.HasFlag(PropertyUseFlags.PrimaryKey)))
        {
            if (holder.Properties.Where(p => p.EntityProperty.Name.Equals(pu.Property.Name)).FirstOrDefault() is PropertyHolder pm)
            {
                path.Add(pu.Property.Name);
                if (_pocos.TryGetValue(pm.EntityProperty.ItemType!.FullName!, out PocoHolder? ph))
                {
                    DFM_GetForeignKeys(ph, table, path, pk, fk);
                }
                else
                {
                    DataColumn col = new(string.Join('_', path), pm.EntityProperty.ItemType);
                    if (pm.EntityProperty.IsNullable)
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
}

using CatsCommon;
using CatsCommon.Filters;
using CatsCommon.Model;
using CatsServerDebug.Converters;
using CatsServerEngineDebug.Converters;
using Net.Leksi.Pocota.Common;
using Net.Leksi.Pocota.Server;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CatsServerEngine;

internal class Builder : IBuilder
{
    private readonly IServiceProvider _services;
    private readonly IPocoContext _pocoContext;
    private readonly ConditionalWeakTable<ICatFilter, Regex> _namesRegexCache = new();

    public Builder(IServiceProvider services)
    {
        _services = services;
        _pocoContext = _services.GetRequiredService<IPocoContext>();
    }

    public void BuildTitles(BuildingOptions options)
    {
        JsonSerializer.Serialize<IEnumerable<string>>(
            options.Output!,
            SpinTitles()
        );
    }

    public void BuildExteriors(BuildingOptions options)
    {
        JsonSerializer.Serialize<IEnumerable<string>>(
            options.Output!,
            SpinExteriors()
        );
    }

    public void BuildBreeds(IBreedFilter? filter, BuildingOptions options)
    {
        options.Spinner = SpinBreeds(filter);
        _pocoContext.Build<List<IBreed>>(
            options
        );
    }

    public void BuildCatteries(ICatteryFilter? filter, BuildingOptions options)
    {
        options.Spinner = SpinCatteries(filter);
        _pocoContext.Build<List<ICattery>>(
            options
        );
    }


    private static BuildingScriptMapping BuildCatMapping = new BuildingScriptMapping("BuildCatMapping")
        .AddPathMapEntry("/Gender", "Gender", typeof(GenderConverter))
        .AddPathMapEntry("/Description", "OwnerInfo")
        .AddPathMapEntry("/Breed/IdBreed", "IdBreed")
        .AddPathMapEntry("/Breed/IdGroup", "IdGroup")
        .AddPathMapEntry("/Litter/IdLitter", "IdLitter")
        .AddPathMapEntry("/Litter/IdFemale", "IdMother")
        .AddPathMapEntry("/Litter/IdFemaleCattery", "IdMotherCattery")
        .AddPathMapEntry("/Litter/Date", "Date", typeof(DateOnlyConverter))
        .AddPathMapEntry("/Litter/Female/NameNat", "MomNameNat")
        .AddPathMapEntry("/Litter/Female/NameEng", "MomNameEng")
        .AddPathMapEntry("/Litter/Female/Breed/IdBreed", "MomIdBreed")
        .AddPathMapEntry("/Litter/Female/Breed/IdGroup", "MomIdGroup")
        .AddPathMapEntry("/Litter/Female/Cattery/NameNat", "MomCatteryNameNat")
        .AddPathMapEntry("/Litter/Female/Cattery/NameEng", "MomCatteryNameEng")
        .AddPathMapEntry("/Litter/Female/Litter/IdLitter", "MomIdLitter")
        .AddPathMapEntry("/Litter/Female/Litter/IdFemale", "MomIdMother")
        .AddPathMapEntry("/Litter/Female/Litter/IdFemaleCattery", "MomIdMotherCattery")
        .AddPathMapEntry("/Litter/Female/Litter/Date", "MomDate", typeof(DateOnlyConverter))
        .AddPathMapEntry("/Litter/Female/Exterior", "MomExterior")
        .AddPathMapEntry("/Litter/Female/Title", "MomTitle")
        .AddPathMapEntry("/Litter/Female/Description", "MomOwnerInfo")
        .AddPathMapEntry("/Litter/Female/Gender", "MomGender", typeof(GenderConverter))
        .AddPathMapEntry("/Litter/Male/IdCat", "IdFather")
        .AddPathMapEntry("/Litter/Male/IdCattery", "IdFatherCattery")
        .AddPathMapEntry("/Litter/Male/NameNat", "DadNameNat")
        .AddPathMapEntry("/Litter/Male/NameEng", "DadNameEng")
        .AddPathMapEntry("/Litter/Male/Breed/IdBreed", "DadIdBreed")
        .AddPathMapEntry("/Litter/Male/Breed/IdGroup", "DadIdGroup")
        .AddPathMapEntry("/Litter/Male/Cattery/NameNat", "DadCatteryNameNat")
        .AddPathMapEntry("/Litter/Male/Cattery/NameEng", "DadCatteryNameEng")
        .AddPathMapEntry("/Litter/Male/Litter/IdLitter", "DadIdLitter")
        .AddPathMapEntry("/Litter/Male/Litter/IdFemale", "DadIdMother")
        .AddPathMapEntry("/Litter/Male/Litter/IdFemaleCattery", "DadIdMotherCattery")
        .AddPathMapEntry("/Litter/Male/Litter/Date", "DadDate", typeof(DateOnlyConverter))
        .AddPathMapEntry("/Litter/Male/Exterior", "DadExterior")
        .AddPathMapEntry("/Litter/Male/Title", "DadTitle")
        .AddPathMapEntry("/Litter/Cats", BuildingScript.Skip)
        ;

    private static BuildingScriptMapping BuildCatLitterWithCatsMapping = new BuildingScriptMapping("BuildCatsLitterWithCatsMapping")
            .AddPathMapEntry("/Litters/[]/IdLitter", "IdLitter")
            .AddPathMapEntry("/Litters/[]/IdFemale", "IdFemale")
            .AddPathMapEntry("/Litters/[]/IdFemaleCattery", "IdFemaleCattery")
            .AddPathMapEntry("/Litters/[]/Date", "Date", typeof(DateOnlyConverter))

            .AddPathMapEntry("/Litters/[]/Male/IdCat", "IdMale")
            .AddPathMapEntry("/Litters/[]/Male/IdCattery", "IdMaleCattery")
            .AddPathMapEntry("/Litters/[]/Male/NameNat", "DadNameNat")
            .AddPathMapEntry("/Litters/[]/Male/NameEng", "DadNameEng")
            .AddPathMapEntry("/Litters/[]/Male/Exterior", "DadExterior")
            .AddPathMapEntry("/Litters/[]/Male/Title", "DadTitle")
            .AddPathMapEntry("/Litters/[]/Male/Breed/IdBreed", "DadIdBreed")
            .AddPathMapEntry("/Litters/[]/Male/Breed/IdGroup", "DadIdGroup")
            .AddPathMapEntry("/Litters/[]/Male/Litter/IdLitter", "DadIdLitter")
            .AddPathMapEntry("/Litters/[]/Male/Litter/IdFemale", "DadIdMother")
            .AddPathMapEntry("/Litters/[]/Male/Litter/IdFemaleCattery", "DadIdMotherCattery")
            .AddPathMapEntry("/Litters/[]/Male/Litter/Date", "DadBirthDate", typeof(DateOnlyConverter))
            .AddPathMapEntry("/Litters/[]/Male/Cattery/NameNat", "DadCatteryNameNat")
            .AddPathMapEntry("/Litters/[]/Male/Cattery/NameEng", "DadCatteryNameEng")

            .AddPathMapEntry("/Litters/[]/Female/NameNat", "MomNameNat")
            .AddPathMapEntry("/Litters/[]/Female/NameEng", "MomNameEng")
            .AddPathMapEntry("/Litters/[]/Female/Exterior", "MomExterior")
            .AddPathMapEntry("/Litters/[]/Female/Title", "MomTitle")
            .AddPathMapEntry("/Litters/[]/Female/Breed/IdBreed", "MomIdBreed")
            .AddPathMapEntry("/Litters/[]/Female/Breed/IdGroup", "MomIdGroup")
            .AddPathMapEntry("/Litters/[]/Female/Litter/IdLitter", "MomIdLitter")
            .AddPathMapEntry("/Litters/[]/Female/Litter/IdFemale", "MomIdMother")
            .AddPathMapEntry("/Litters/[]/Female/Litter/IdFemaleCattery", "MomIdMotherCattery")
            .AddPathMapEntry("/Litters/[]/Female/Litter/Date", "MomBirthDate", typeof(DateOnlyConverter))
            .AddPathMapEntry("/Litters/[]/Female/Cattery/NameNat", "MomCatteryNameNat")
            .AddPathMapEntry("/Litters/[]/Female/Cattery/NameEng", "MomCatteryNameEng")
        ;

    public void BuildCat<T>(ICat self, BuildingOptions options) where T : class
    {
        options.Script = _services.GetRequiredService<BuildingScript>();

        options.Script.Mapping = BuildCatMapping;
        options.Script.AddPathHandler("/Litters", args =>
        {
            ILitterFilter filter = _services.GetRequiredService<ILitterFilter>();
            ICat cat = ((IProjection)args.GetOwner(1)).As<ICat>()!;
            if (cat.Gender is Gender.Female || cat.Gender is Gender.FemaleCastrate)
            {
                filter.Female = cat;
            }
            else
            {
                filter.Male = cat;
            }
            BuildingScript script = _services.GetRequiredService<BuildingScript>();
            script.Mapping = BuildCatLitterWithCatsMapping;

            script.AddPathHandler("/Litters/[]/Cats", args =>
            {
                if (typeof(T) == typeof(ICatWithSiblings))
                {
                    ICatFilter filter1 = _services.GetRequiredService<ICatFilter>();
                    filter1.Litter = ((IProjection)args.GetOwner(1)!).As<ILitter>();
                    BuildingScript script1 = _services.GetRequiredService<BuildingScript>();
                    //script.WithTrace = true;
                    script1.Mapping = BuildCatsLitterWithCatsMapping;
                    args.UseSpinner(SpinCats(filter1), script1);
                }
                else
                {
                    args.Skip();
                }
            });


            args.UseSpinner(SpinLitters(filter), script);
        });

        options.Spinner = SpinCat(self);
        _pocoContext.Build<T>(options);
    }

    private static BuildingScriptMapping BuildCatsMapping = new BuildingScriptMapping("BuildCatsMapping")
        .AddPathMapEntry("/Breed/IdBreed", "IdBreed")
        .AddPathMapEntry("/Breed/IdGroup", "IdGroup")
        .AddPathMapEntry("/Litter/IdLitter", "IdLitter")
        .AddPathMapEntry("/Litter/Female", BuildingScript.KeyOnly)
        .AddPathMapEntry("/Litter/IdFemale", "IdMother")
        .AddPathMapEntry("/Litter/IdFemaleCattery", "IdMotherCattery")
        .AddPathMapEntry("/Description", "OwnerInfo")
        .AddPathMapEntry("/Litter/Male", BuildingScript.KeyOnly)
        //.AddPathMapEntry("/Litter/Cats", BuildingScript.Skip)
        .AddPathMapEntry("/Litter/Male/IdCat", "IdFather")
        .AddPathMapEntry("/Litter/Male/IdCattery", "IdFatherCattery")
        .AddPathMapEntry("/Litter/Date", "Date", typeof(DateOnlyConverter))
        .AddPathMapEntry("/Gender", "Gender", typeof(GenderConverter))
        //ILitterWithCats
        .AddPathMapEntry("/IdFemale", "IdMother")
        .AddPathMapEntry("/IdFemaleCattery", "IdMotherCattery")
        ;

    private static BuildingScriptMapping BuildCatsLitterWithCatsMapping = new BuildingScriptMapping("BuildCatsLitterWithCatsMapping")
            .AddPathMapEntry("/Cats/[]/IdCat", "IdCat")
            .AddPathMapEntry("/Cats/[]/IdCattery", "IdCattery")
            .AddPathMapEntry("/Cats/[]/Breed/IdBreed", "IdBreed")
            .AddPathMapEntry("/Cats/[]/Breed/IdGroup", "IdGroup")
            .AddPathMapEntry("/Cats/[]/Litter/IdLitter", "IdLitter")
            .AddPathMapEntry("/Cats/[]/Litter/IdFemale", "IdMother")
            .AddPathMapEntry("/Cats/[]/Litter/IdFemaleCattery", "IdMotherCattery")
            .AddPathMapEntry("/Cats/[]/Litter/Female", BuildingScript.KeyOnly)
            .AddPathMapEntry("/Cats/[]/Description", "OwnerInfo")
            .AddPathMapEntry("/Cats/[]/Litter/Male/IdCat", "IdFather")
            .AddPathMapEntry("/Cats/[]/Litter/Male/IdCattery", "IdFatherCattery")
            .AddPathMapEntry("/Cats/[]/Litter/Male", BuildingScript.KeyOnly)
            .AddPathMapEntry("/Cats/[]/Litter/Date", "Date", typeof(DateOnlyConverter))
            .AddPathMapEntry("/Cats/[]/Litter/Cats", BuildingScript.Skip)
            .AddPathMapEntry("/Cats/[]/Gender", "Gender", typeof(GenderConverter))
            .AddPathMapEntry("/Cats/[]/NameNat", "NameNat")
            .AddPathMapEntry("/Cats/[]/NameEng", "NameEng")
            .AddPathMapEntry("/Cats/[]/Breed/NameEng", "BreedNameEng")
            .AddPathMapEntry("/Cats/[]/Breed/NameNat", "BreedNameNat")
            .AddPathMapEntry("/Cats/[]/Exterior", "Exterior")
            .AddPathMapEntry("/Cats/[]/Title", "Title")
            .AddPathMapEntry("/Cats/[]/Cattery/NameEng", "CatteryNameEng")
            .AddPathMapEntry("/Cats/[]/Cattery/NameNat", "CatteryNameNat")
        ;

    public void BuildCats<T>(ICatFilter? filter, BuildingOptions options) where T : class
    {
        if (filter?.Ancestor is { } || filter?.Descendant is { } || filter?.Child is { })
        {
            JsonSerializerOptions jsonSerializerOptions = _pocoContext.BindJsonSerializerOptions();
            if (typeof(T) == typeof(ILitterWithCats))
            {
                _pocoContext.AddJsonConverters(typeof(ICatWithSiblings), options.JsonSerializerOptions!);
                _pocoContext.AddJsonConverters(typeof(ICatWithSiblings), jsonSerializerOptions);
                JsonSerializer.Serialize(
                    options.Output!,
                    FindLittersWithCats(filter, options),
                    jsonSerializerOptions
                );
            }
            else
            {
                _pocoContext.AddJsonConverters<T>(options.JsonSerializerOptions!);
                _pocoContext.AddJsonConverters<T>(jsonSerializerOptions);
                JsonSerializer.Serialize(
                    options.Output!,
                    FindCats<T>(filter, options),
                    jsonSerializerOptions
                );
            }
        }
        else
        {
            options.Script = _services.GetRequiredService<BuildingScript>();
            options.Script.Mapping = BuildCatsMapping;

            //options.Script.WithTrace = true;
            if (typeof(T) == typeof(ILitterWithCats) || typeof(T) == typeof(ICatWithSiblings))
            {
                options.Script.AddPathHandler("/Litter/Cats", args =>
                {
                    ICatFilter filter = _services.GetRequiredService<ICatFilter>();
                    filter.Litter = ((IProjection)args.GetOwner(1)!).As<ILitter>();
                    BuildingScript script = _services.GetRequiredService<BuildingScript>();
                    //script.WithTrace = true;
                    script.Mapping = BuildCatsLitterWithCatsMapping;
                    args.UseSpinner(SpinCats(filter), script);
                });

            }
            else
            {
                options.Script.AddPathMapEntry("/Litter/Cats", BuildingScript.Skip);
            }
            options.Spinner = SpinCats(filter);

            if (typeof(T) == typeof(ILitterWithCats))
            {
                options.Mapper = _pocoContext.GetProperty<ICatWithSiblings>("Litter");
                _pocoContext.Build<List<ICatWithSiblings>>(
                    options
                );
            }
            else
            {
                _pocoContext.Build<List<T>>(
                    options
                );
            }
        }
    }

    private IEnumerable<DbDataReader?> SpinLitters(ILitterFilter filter)
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetLitters(filter);

        while (dataReader.Read())
        {
            yield return dataReader;
        }
        dataReader.Close();
    }

    private IEnumerable<ILitterWithCats> FindLittersWithCats(ICatFilter filter, BuildingOptions options)
    {
        return FindCats<ICatWithSiblings>(filter, options).Select(cat => cat.Litter)!;
    }

    private IEnumerable<T> FindCats<T>(ICatFilter? filter, BuildingOptions options) where T : class
    {
        int numTests = 0;
        Dictionary<T, int> crossing = new();
        int countTests = 0;
        if (filter?.Child is { })
        {
            ++countTests;
        }
        if (filter?.Ancestor is { })
        {
            ++countTests;
        }
        if (filter?.Descendant is { })
        {
            ++countTests;
        }
        if (filter?.Child is { })
        {
            ++numTests;
            foreach (T cat in FindParentCats<T>(filter, options))
            {
                if (!crossing.TryGetValue(cat, out int value))
                {
                    if (numTests == 1)
                    {
                        crossing.Add(cat, 1);
                    }
                }
                else
                {
                    if (value == numTests - 1)
                    {
                        crossing[cat] = value + 1;
                    }
                }
                if (crossing.TryGetValue(cat, out value) && value == countTests)
                {
                    if(TestFilter(filter!, ((IProjection)cat).As<ICat>()!))
                    {
                        yield return ((IProjection)cat).As<T>()!;
                    }
                    crossing.Remove(cat);
                }
            }
        }
        if (filter?.Descendant is { })
        {
            ++numTests;
            foreach (T cat in FindAncestorCats<T>(filter, options))
            {
                if (!crossing.TryGetValue(cat, out int value))
                {
                    if (numTests == 1)
                    {
                        crossing.Add(cat, 1);
                    }
                }
                else
                {
                    if (value == numTests - 1)
                    {
                        crossing[cat] = value + 1;
                    }
                }
                if (crossing.TryGetValue(cat, out value) && value == countTests)
                {
                    if (TestFilter(filter!, ((IProjection)cat).As<ICat>()!))
                    {
                        yield return ((IProjection)cat).As<T>()!;
                    }
                    crossing.Remove(cat);
                }
            }
        }
        if (filter?.Ancestor is { })
        {
            ++numTests;
            foreach (T cat in FindDescendantCats<T>(filter, options))
            {
                if (!crossing.TryGetValue(cat, out int value))
                {
                    if (numTests == 1)
                    {
                        crossing.Add(cat, 1);
                    }
                }
                else
                {
                    if (value == numTests - 1)
                    {
                        crossing[cat] = value + 1;
                    }
                }
                if (crossing.TryGetValue(cat, out value) && value == countTests)
                {
                    if (TestFilter(filter!, ((IProjection)cat).As<ICat>()!))
                    {
                        yield return ((IProjection)cat).As<T>()!;
                    }
                    crossing.Remove(cat);
                }
            }
        }
    }

    public void BuildLittersWithCats(ICatFilter? filter, BuildingOptions options)
    {
        BuildCats<ILitterWithCats>(filter, options);
    }

    public IEnumerable<DbDataReader?> SpinCats(ICatFilter? filter)
    {
        Regex? NameRegex = null;
        Regex? ExteriorRegex = null;
        Regex? TitleRegex = null;

        if (filter is { })
        {
            if (filter.NameRegex is { })
            {
                NameRegex = new(filter.NameRegex, RegexOptions.IgnoreCase);
            }
            if (filter.ExteriorRegex is { })
            {
                ExteriorRegex = new(filter.ExteriorRegex, RegexOptions.IgnoreCase);
            }
            if (filter.TitleRegex is { })
            {
                TitleRegex = new(filter.TitleRegex, RegexOptions.IgnoreCase);
            }
        }

        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetCats(filter);

        while (dataReader.Read())
        {
            if (
                (
                    NameRegex is null
                    || NameRegex.IsMatch(dataReader["NameEng"].ToString()!.Trim())
                    || NameRegex.IsMatch(dataReader["NameNat"].ToString()!.Trim())
                )
                && (
                    ExteriorRegex is null
                    || ExteriorRegex.IsMatch(dataReader["Exterior"].ToString()!.Trim())
                )
                && (
                    TitleRegex is null
                    || TitleRegex.IsMatch(dataReader["Title"].ToString()!.Trim())
                )
            )
            {
                yield return dataReader;
            }
        }
        dataReader.Close();
    }

    private IEnumerable<string> SpinExteriors()
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetExteriors();

        while (dataReader.Read())
        {
            yield return dataReader[0].ToString()!;
        }
        dataReader.Close();
    }

    private IEnumerable<string> SpinTitles()
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetTitles();

        while (dataReader.Read())
        {
            yield return dataReader[0].ToString()!;
        }
        dataReader.Close();
    }

    private IEnumerable<T> FindParentCats<T>(ICatFilter filter, BuildingOptions options) where T : class
    {
        List<T> cats = new();
        ICatFilter catsFilter = _services.GetRequiredService<ICatFilter>();
        BuildingOptions catsOptions = new()
        {
            JsonSerializerOptions = _pocoContext.BindJsonSerializerOptions(),
            Target = cats,
        };

        catsFilter.Self = filter.Child;
        BuildCats<T>(catsFilter, catsOptions);

        if (cats.Count > 0)
        {
            ICat self = ((IProjection)cats[0]).As<ICat>()!;
            if(self.Litter is { })
            {
                cats.Clear();
                catsOptions.Target = cats;
                catsFilter.Self = self.Litter!.Female;
                if (catsFilter.Self is null)
                {
                    throw new InvalidOperationException();
                }
                BuildCats<T>(catsFilter, catsOptions);
                if (cats.Count > 0)
                {
                    yield return cats[0];
                }
                cats.Clear();
                if (self.Litter!.Male is { })
                {
                    catsFilter.Self = self.Litter!.Male;
                    BuildCats<T>(catsFilter, catsOptions);
                    if (cats.Count > 0)
                    {
                        yield return cats[0];
                    }
                }
            }
        }

    }

    private IEnumerable<T> FindAncestorCats<T>(ICatFilter filter, BuildingOptions options) where T : class
    {
        Queue<T> queue = new();
        List<T> cats = new();
        List<ILitterForCat> litters = new();
        ICatFilter catsFilter = _services.GetRequiredService<ICatFilter>();
        catsFilter.Self = filter.Descendant;

        BuildingOptions catsOptions = new()
        {
            JsonSerializerOptions = _pocoContext.BindJsonSerializerOptions(),
            Target = cats
        };

        BuildingOptions littersOptions = new()
        {
            JsonSerializerOptions = _pocoContext.BindJsonSerializerOptions(),
            Target = litters,
        };
        littersOptions.Script = _services.GetRequiredService<BuildingScript>();
        littersOptions.Script.AddPathMapEntry("/Cats", BuildingScript.Skip);
        littersOptions.Script.AddPathMapEntry("/Male", BuildingScript.KeyOnly);
        littersOptions.Script.AddPathMapEntry("/Male/IdCat", "/IdMale");
        littersOptions.Script.AddPathMapEntry("/Male/IdCattery", "/IdMaleCattery");

        BuildCats<T>(catsFilter, catsOptions);
        foreach (T item in cats)
        {
            queue.Enqueue(item);
        }
        cats.Clear();
        catsFilter.Self = null;
        while (queue.Count > 0)
        {
            ICat cat = ((IProjection)queue.Dequeue()).As<ICat>()!;
            if (cat.Litter is { })
            {
                litters.Add(((IProjection)cat.Litter).As<ILitterForCat>()!);
                littersOptions.Spinner = SpinLitter(cat.Litter);
                _pocoContext.Build<List<ILitterForCat>>(
                    littersOptions
                );
                litters.Clear();

                for (int step = 0; step < 2; ++step)
                {
                    catsFilter.Self = null;
                    if (step == 0)
                    {
                        catsFilter.Self = cat.Litter.Female;
                    }
                    else if (step == 1 && cat.Litter.Male is { })
                    {
                        catsFilter.Self = cat.Litter.Male;
                    }
                    if (catsFilter.Self is { })
                    {
                        BuildCats<T>(catsFilter, catsOptions);
                        foreach (T item in cats)
                        {
                            if (step == 0)
                            {
                                cat.Litter.Female = ((IProjection?)item)?.As<ICat>()!;
                            }
                            else
                            {
                                cat.Litter.Male = ((IProjection?)item)?.As<ICat>()!;
                            }
                            queue.Enqueue(item);
                        }
                        cats.Clear();
                    }
                }
            }
            if (!PocoBase.ReferenceEquals(cat, filter.Descendant) && TestFilter(filter, (ICat)cat))
            {
                yield return ((IProjection)cat).As<T>()!;
            }
        }
    }

    private IEnumerable<DbDataReader?> SpinLitter(ILitter litter)
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetLitter(((IProjection)litter).As<IEntity>()!.PrimaryKey);

        if (dataReader.Read())
        {
            yield return dataReader;
        }
        dataReader.Close();
    }

    private IEnumerable<T> FindDescendantCats<T>(ICatFilter filter, BuildingOptions options) where T : class
    {
        Queue<T> queue = new();
        List<T> cats = new();
        ICatFilter catsFilter = _services.GetRequiredService<ICatFilter>();
        catsFilter.Self = filter.Ancestor;
        BuildingOptions catsOptions = new()
        {
            JsonSerializerOptions = _pocoContext.BindJsonSerializerOptions(),
            Target = cats,
            OnItem = it => 
            {
                //Console.WriteLine(it);
            }
        };
        BuildCats<T>(catsFilter, catsOptions);
        foreach (T item in cats)
        {
            queue.Enqueue(item);
        }
        cats.Clear();
        catsFilter.Self = null;
        while (queue.Count > 0)
        {
            ICat cat = ((IProjection)queue.Dequeue()).As<ICat>()!;
            if (!PocoBase.ReferenceEquals(cat, filter.Ancestor) && TestFilter(filter, cat))
            {
                yield return ((IProjection)cat).As<T>()!;
            }
            for(int i = 0; i < 2; ++i)
            {
                if(i == 0)
                {
                    catsFilter.Mother = cat;
                    catsFilter.Father = null;
                }
                else
                {
                    catsFilter.Father = cat;
                    catsFilter.Mother = null;
                }
                BuildCats<T>(catsFilter, catsOptions);
                foreach (ICat item in cats.Select(v => ((IProjection)v).As<ICat>()!))
                {
                    queue.Enqueue(((IProjection)item).As<T>()!);
                }
                cats.Clear();
            }
        }
    }

    private bool TestFilter(ICatFilter filter, ICat cat)
    {
        if (filter.Self is { })
        {
            IPrimaryKey? pk = ((IEntity)cat).PrimaryKey;
            IPrimaryKey primaryKeyFather = ((IEntity)filter.Self).PrimaryKey;
            if (!primaryKeyFather.Equals(pk))
            {
                return false;
            }
        }
        if (filter.Father is { })
        {
            if (cat.Litter is { } && cat.Litter.Male is { })
            {
                IPrimaryKey? pk = ((IEntity)cat.Litter.Male).PrimaryKey;
                IPrimaryKey primaryKeyFather = ((IEntity)filter.Father).PrimaryKey;
                if (!primaryKeyFather.Equals(pk))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        if (filter.Mother is { })
        {
            if (cat.Litter is { })
            {
                IPrimaryKey? pk = ((IEntity)cat.Litter.Female).PrimaryKey;
                IPrimaryKey primaryKeyMother = ((IEntity)filter.Mother).PrimaryKey;
                if (!primaryKeyMother.Equals(pk))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        if (filter.Cattery is { })
        {
            IPrimaryKey primaryKeyFilterCattery = ((IEntity)filter.Cattery).PrimaryKey;
            IPrimaryKey primaryKeyCatCattery = ((IEntity)cat.Cattery).PrimaryKey;
            if (!primaryKeyFilterCattery.Equals(primaryKeyCatCattery))
            {
                return false;
            }
        }
        if (filter.Breed is { })
        {
            IPrimaryKey primaryKeyFilterBreed = ((IEntity)filter.Breed).PrimaryKey;
            IPrimaryKey primaryKeyCatBreed = ((IEntity)cat.Breed!).PrimaryKey;
            if (!primaryKeyFilterBreed.Equals(primaryKeyCatBreed))
            {
                return false;
            }
        }
        if (filter.BornAfter is { })
        {
            if (cat.Litter is { } && cat.Litter.Date < filter.BornAfter)
            {
                return false;
            }
        }
        if (filter.BornBefore is { })
        {
            if (cat.Litter is { } && cat.Litter.Date > filter.BornBefore)
            {
                return false;
            }
        }
        if (filter.Gender is { })
        {
            if (cat.Gender != filter.Gender)
            {
                return false;
            }
        }
        if (filter.NameRegex is { })
        {
            if (!_namesRegexCache.TryGetValue(filter, out Regex? regex))
            {
                regex = new Regex(filter.NameRegex);
                _namesRegexCache.Add(filter, regex);
            }
            if (!regex.IsMatch(cat.NameNat!) && !regex.IsMatch(cat.NameEng!))
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerable<DbDataReader?> SpinCat(ICat self)
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetCat(((IProjection)self).As<IEntity>()!.PrimaryKey);

        if (dataReader.Read())
        {
            yield return dataReader;
        }
        dataReader.Close();
    }

    private IEnumerable<DbDataReader?> SpinCatteries(ICatteryFilter filter)
    {
        Regex? SearchRegex = null;

        if (filter is { })
        {
            if (filter.SearchRegex is { })
            {
                SearchRegex = new(filter.SearchRegex, RegexOptions.IgnoreCase);
            }
        }

        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetCatteries(filter);

        while (dataReader.Read())
        {
            if (
                SearchRegex is null
                || SearchRegex.IsMatch(dataReader["NameEng"].ToString()!.Trim())
                || SearchRegex.IsMatch(dataReader["NameNat"].ToString()!.Trim())
            )
            {
                yield return dataReader;
            }
        }
        dataReader.Close();
    }

    private IEnumerable<DbDataReader?> SpinBreeds(IBreedFilter? filter)
    {
        Regex? SearchRegex = null;

        if (filter is { })
        {
            if (filter.SearchRegex is { })
            {
                SearchRegex = new(filter.SearchRegex, RegexOptions.IgnoreCase);
            }
        }

        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetBreeds(filter);

        while (dataReader.Read())
        {
            if (
                SearchRegex is null
                || SearchRegex.IsMatch(dataReader["NameEng"].ToString()!.Trim()) || SearchRegex.IsMatch(dataReader["NameNat"].ToString()!.Trim())
                || SearchRegex.IsMatch(dataReader["IdBreed"].ToString()!.Trim()) || SearchRegex.IsMatch(dataReader["IdGroup"].ToString()!.Trim())
            )
            {
                yield return dataReader;
            }
        }
        dataReader.Close();
    }
}

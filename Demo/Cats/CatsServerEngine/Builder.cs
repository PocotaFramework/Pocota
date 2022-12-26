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


    public void BuildCat<T>(ICat self, BuildingOptions options)
    {
        options.Script = _services.GetRequiredService<BuildingScript>();
        options.Script.AddPathMapEntry("/Gender", "Gender", typeof(GenderConverter));
        options.Script.AddPathMapEntry("/Description", "OwnerInfo");
        options.Script.AddPathMapEntry("/Breed/IdBreed", "IdBreed");
        options.Script.AddPathMapEntry("/Breed/IdGroup", "IdGroup");
        options.Script.AddPathMapEntry("/Litter/IdLitter", "IdLitter");
        options.Script.AddPathMapEntry("/Litter/IdFemale", "IdMother");
        options.Script.AddPathMapEntry("/Litter/IdFemaleCattery", "IdMotherCattery");
        options.Script.AddPathMapEntry("/Litter/Date", "Date", typeof(DateOnlyConverter));
        options.Script.AddPathMapEntry("/Litter/Female/NameNat", "MomNameNat");
        options.Script.AddPathMapEntry("/Litter/Female/NameEng", "MomNameEng");
        options.Script.AddPathMapEntry("/Litter/Female/Breed/IdBreed", "MomIdBreed");
        options.Script.AddPathMapEntry("/Litter/Female/Breed/IdGroup", "MomIdGroup");
        options.Script.AddPathMapEntry("/Litter/Female/Cattery/NameNat", "MomCatteryNameNat");
        options.Script.AddPathMapEntry("/Litter/Female/Cattery/NameEng", "MomCatteryNameEng");
        options.Script.AddPathMapEntry("/Litter/Female/Litter/IdLitter", "MomIdLitter");
        options.Script.AddPathMapEntry("/Litter/Female/Litter/IdFemale", "MomIdMother");
        options.Script.AddPathMapEntry("/Litter/Female/Litter/IdFemaleCattery", "MomIdMotherCattery");
        options.Script.AddPathMapEntry("/Litter/Female/Litter/Date", "MomDate", typeof(DateOnlyConverter));
        options.Script.AddPathMapEntry("/Litter/Female/Exterior", "MomExterior");
        options.Script.AddPathMapEntry("/Litter/Female/Title", "MomTitle");
        options.Script.AddPathMapEntry("/Litter/Female/Description", "MomOwnerInfo");
        options.Script.AddPathMapEntry("/Litter/Female/Gender", "MomGender", typeof(GenderConverter));
        options.Script.AddPathMapEntry("/Litter/Male/IdCat", "IdFather");
        options.Script.AddPathMapEntry("/Litter/Male/IdCattery", "IdFatherCattery");
        options.Script.AddPathMapEntry("/Litter/Male/NameNat", "DadNameNat");
        options.Script.AddPathMapEntry("/Litter/Male/NameEng", "DadNameEng");
        options.Script.AddPathMapEntry("/Litter/Male/Breed/IdBreed", "DadIdBreed");
        options.Script.AddPathMapEntry("/Litter/Male/Breed/IdGroup", "DadIdGroup");
        options.Script.AddPathMapEntry("/Litter/Male/Cattery/NameNat", "DadCatteryNameNat");
        options.Script.AddPathMapEntry("/Litter/Male/Cattery/NameEng", "DadCatteryNameEng");
        options.Script.AddPathMapEntry("/Litter/Male/Litter/IdLitter", "DadIdLitter");
        options.Script.AddPathMapEntry("/Litter/Male/Litter/IdFemale", "DadIdMother");
        options.Script.AddPathMapEntry("/Litter/Male/Litter/IdFemaleCattery", "DadIdMotherCattery");
        options.Script.AddPathMapEntry("/Litter/Male/Litter/Date", "DadDate", typeof(DateOnlyConverter));
        options.Script.AddPathMapEntry("/Litter/Male/Exterior", "DadExterior");
        options.Script.AddPathMapEntry("/Litter/Male/Title", "DadTitle");
        options.Script.AddPathHandler("/Litters", args =>
        {
            ILitterFilter filter = _services.GetRequiredService<ILitterFilter>();
            ICat cat = (args.GetOwner(1) as ICat)!;
            if(cat.Gender is Gender.Female || cat.Gender is Gender.FemaleCastrate)
            {
                filter.Female = cat;
            }
            else
            {
                filter.Male = cat;
            }
            BuildingScript script = _services.GetRequiredService<BuildingScript>();
            script.AddPathMapEntry("/Litters/[]/IdLitter", "IdLitter");
            script.AddPathMapEntry("/Litters/[]/IdFemale", "IdFemale");
            script.AddPathMapEntry("/Litters/[]/IdFemaleCattery", "IdFemaleCattery");
            script.AddPathMapEntry("/Litters/[]/Date", "Date", typeof(DateOnlyConverter));

            script.AddPathMapEntry("/Litters/[]/Male/IdCat", "IdMale");
            script.AddPathMapEntry("/Litters/[]/Male/IdCattery", "IdMaleCattery");
            script.AddPathMapEntry("/Litters/[]/Male/NameNat", "DadNameNat");
            script.AddPathMapEntry("/Litters/[]/Male/NameEng", "DadNameEng");
            script.AddPathMapEntry("/Litters/[]/Male/Exterior", "DadExterior");
            script.AddPathMapEntry("/Litters/[]/Male/Title", "DadTitle");
            script.AddPathMapEntry("/Litters/[]/Male/Breed/IdBreed", "DadIdBreed");
            script.AddPathMapEntry("/Litters/[]/Male/Breed/IdGroup", "DadIdGroup");
            script.AddPathMapEntry("/Litters/[]/Male/Litter/IdLitter", "DadIdLitter");
            script.AddPathMapEntry("/Litters/[]/Male/Litter/IdFemale", "DadIdMother");
            script.AddPathMapEntry("/Litters/[]/Male/Litter/IdFemaleCattery", "DadIdMotherCattery");
            script.AddPathMapEntry("/Litters/[]/Male/Litter/Date", "DadBirthDate", typeof(DateOnlyConverter));
            script.AddPathMapEntry("/Litters/[]/Male/Cattery/NameNat", "DadCatteryNameNat");
            script.AddPathMapEntry("/Litters/[]/Male/Cattery/NameEng", "DadCatteryNameEng");

            script.AddPathMapEntry("/Litters/[]/Female/NameNat", "MomNameNat");
            script.AddPathMapEntry("/Litters/[]/Female/NameEng", "MomNameEng");
            script.AddPathMapEntry("/Litters/[]/Female/Exterior", "MomExterior");
            script.AddPathMapEntry("/Litters/[]/Female/Title", "MomTitle");
            script.AddPathMapEntry("/Litters/[]/Female/Breed/IdBreed", "MomIdBreed");
            script.AddPathMapEntry("/Litters/[]/Female/Breed/IdGroup", "MomIdGroup");
            script.AddPathMapEntry("/Litters/[]/Female/Litter/IdLitter", "MomIdLitter");
            script.AddPathMapEntry("/Litters/[]/Female/Litter/IdFemale", "MomIdMother");
            script.AddPathMapEntry("/Litters/[]/Female/Litter/IdFemaleCattery", "MomIdMotherCattery");
            script.AddPathMapEntry("/Litters/[]/Female/Litter/Date", "MomBirthDate", typeof(DateOnlyConverter));
            script.AddPathMapEntry("/Litters/[]/Female/Cattery/NameNat", "MomCatteryNameNat");
            script.AddPathMapEntry("/Litters/[]/Female/Cattery/NameEng", "MomCatteryNameEng");
            args.UseSpinner(SpinLitters(filter), script);
        });

        options.Spinner = SpinCat(self);
        _pocoContext.Build<T>(options);
    }

    public void BuildCats<T>(ICatFilter? filter, BuildingOptions options) where T : notnull
    {
        options.Script = _services.GetRequiredService<BuildingScript>();
        options.Script.AddPathMapEntry("/Breed/IdBreed", "IdBreed");
        options.Script.AddPathMapEntry("/Breed/IdGroup", "IdGroup");
        options.Script.AddPathMapEntry("/Litter/IdLitter", "IdLitter");
        options.Script.AddPathMapEntry("/Litter/Female", BuildingScript.KeyOnly);
        options.Script.AddPathMapEntry("/Litter/IdFemale", "IdMother");
        options.Script.AddPathMapEntry("/Litter/IdFemaleCattery", "IdMotherCattery");
        options.Script.AddPathMapEntry("/Description", "OwnerInfo");
        options.Script.AddPathMapEntry("/Litter/Male", BuildingScript.KeyOnly);
        options.Script.AddPathMapEntry("/Litter/Male/IdCat", "IdFather");
        options.Script.AddPathMapEntry("/Litter/Male/IdCattery", "IdFatherCattery");
        options.Script.AddPathMapEntry("/Litter/Date", "Date", typeof(DateOnlyConverter));
        options.Script.AddPathMapEntry("/Gender", "Gender", typeof(GenderConverter));

        //ILitterWithCats
        options.Script.AddPathMapEntry("/IdFemale", "IdMother");
        options.Script.AddPathMapEntry("/IdFemaleCattery", "IdMotherCattery");
        options.Script.AddPathHandler("/Cats", args =>
        {
            try
            {
                ICatFilter filter = _services.GetRequiredService<ICatFilter>();
                filter.Litter = ((IProjection)args.GetOwner(1)!).As<ILitter>();
                BuildingScript script = _services.GetRequiredService<BuildingScript>();
                script.AddPathMapEntry("/Cats/[]/IdCat", "IdCat");
                script.AddPathMapEntry("/Cats/[]/IdCattery", "IdCattery");
                script.AddPathMapEntry("/Cats/[]/Breed/IdBreed", "IdBreed");
                script.AddPathMapEntry("/Cats/[]/Breed/IdGroup", "IdGroup");
                script.AddPathMapEntry("/Cats/[]/Litter/IdLitter", "IdLitter");
                script.AddPathMapEntry("/Cats/[]/Litter/IdFemale", "IdMother");
                script.AddPathMapEntry("/Cats/[]/Litter/IdFemaleCattery", "IdMotherCattery");
                script.AddPathMapEntry("/Cats/[]/Litter/Female", BuildingScript.KeyOnly);
                script.AddPathMapEntry("/Cats/[]/Description", "OwnerInfo");
                script.AddPathMapEntry("/Cats/[]/Litter/Male/IdCat", "IdFather");
                script.AddPathMapEntry("/Cats/[]/Litter/Male/IdCattery", "IdFatherCattery");
                script.AddPathMapEntry("/Cats/[]/Litter/Male", BuildingScript.KeyOnly);
                script.AddPathMapEntry("/Cats/[]/Litter/Date", "Date", typeof(DateOnlyConverter));
                script.AddPathMapEntry("/Cats/[]/Gender", "Gender", typeof(GenderConverter));
                script.AddPathMapEntry("/Cats/[]/NameNat", "NameNat");
                script.AddPathMapEntry("/Cats/[]/NameEng", "NameEng");
                script.AddPathMapEntry("/Cats/[]/Breed/NameEng", "BreedNameEng");
                script.AddPathMapEntry("/Cats/[]/Breed/NameNat", "BreedNameNat");
                script.AddPathMapEntry("/Cats/[]/Exterior", "Exterior");
                script.AddPathMapEntry("/Cats/[]/Title", "Title");
                script.AddPathMapEntry("/Cats/[]/Cattery/NameEng", "CatteryNameEng");
                script.AddPathMapEntry("/Cats/[]/Cattery/NameNat", "CatteryNameNat");
                args.UseSpinner(SpinCats(filter), script);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        });

        _pocoContext.AddJsonConverters<T>(options.JsonSerializerOptions!);

        if (filter?.Ancestor is { } || filter?.Descendant is { } || filter?.Child is { })
        {


            JsonSerializer.Serialize<IEnumerable<T>>(
                options.Output!,
                FindCats<T>(filter, options),
                options.JsonSerializerOptions
            );
        }
        else
        {
            options.Spinner = SpinCats(filter);
            _pocoContext.Build<List<T>>(
                options
            );
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

    private IEnumerable<T> FindCats<T>(ICatFilter? filter, BuildingOptions options) where T : notnull
    {
        int numTests = 0;
        Dictionary<T, int> crossing = new();
        if (filter?.Child is { })
        {
            if(filter?.Descendant is null && filter?.Ancestor is null)
            {
                return FindParentCats<T>(filter, options).Where(v => TestFilter(filter!, (ICat)v));
            }
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
            }
        }
        if (filter?.Descendant is { })
        {
            if (filter?.Child is null && filter?.Ancestor is null)
            {
                return FindAncestorCats<T>(filter, options).Where(v => TestFilter(filter!, (ICat)v));
            }
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
            }
        }
        if (filter?.Ancestor is { })
        {
            if (filter?.Child is null && filter?.Descendant is null)
            {
                return SpinDescendantCats<T>(filter, options).Where(v => TestFilter(filter!, (ICat)v));
            }
            ++numTests;
            foreach (T cat in SpinDescendantCats<T>(filter, options))
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
            }
        }

        return  crossing.Where(e => e.Value == numTests && TestFilter(filter!, (ICat)e.Key)).Select(e => (T)e.Key);
    }

    public void BuildLittersWithCats<T>(ICatFilter? filter, BuildingOptions options) where T : notnull
    {
        if(filter?.Child is { } || filter?.Ancestor is { } || filter?.Descendant is { })
        {
            JsonSerializer.Serialize<IEnumerable<T>>(
                options.Output!,
                new T[0],
                options.JsonSerializerOptions
            );
        }
        else
        {
            BuildCats<T>(filter, options);
        }
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

    private IEnumerable<T> SpinDescendantAndAncestorCats<T>(ICatFilter catFilter, BuildingOptions options)
    {
        HashSet<T> crossing = new();
        foreach (T cat in FindAncestorCats<T>(catFilter, options))
        {
            crossing.Add(cat);
        }
        foreach (T cat in SpinDescendantCats<T>(catFilter, options))
        {
            if (!crossing.Add(cat))
            {
                yield return cat;
            }
        }
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

    private IEnumerable<T> FindParentCats<T>(ICatFilter filter, BuildingOptions options)
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

        if (cats.Count > 0 && ((ICat)cats[0]).Litter is { })
        {
            T self = cats[0];
            cats.Clear();
            catsOptions.Target = cats;
            catsFilter.Self = ((ICat)self).Litter!.Female;
            if(catsFilter.Self is null)
            {
                throw new InvalidOperationException();
            }
            BuildCats<T>(catsFilter, catsOptions);
            if(cats.Count > 0)
            {
                yield return cats[0];
            }
            cats.Clear();
            if (((ICat)self).Litter!.Male is { })
            {
                catsFilter.Self = ((ICat)self).Litter!.Male;
                BuildCats<T>(catsFilter, catsOptions);
                if (cats.Count > 0)
                {
                    yield return cats[0];
                }
            }
        }

    }

    private IEnumerable<T> FindAncestorCats<T>(ICatFilter filter, BuildingOptions options)
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
        littersOptions.Script.AddPathMapEntry("/Male", BuildingScript.KeyOnly);
        littersOptions.Script.AddPathMapEntry("/Male/IdCat", "/IdMale");
        littersOptions.Script.AddPathMapEntry("/Male/IdCattery", "/IdMaleCattery");
        littersOptions.Script.WithTrace = true;

        BuildCats<T>(catsFilter, catsOptions);
        foreach (T item in cats)
        {
            queue.Enqueue(item);
        }
        cats.Clear();
        catsFilter.Self = null;
        while (queue.Count > 0)
        {
            T cat = queue.Dequeue();
            if (((ICat)cat).Litter is { })
            {
                litters.Add((ILitterForCat)((ICat)cat).Litter);
                littersOptions.Spinner = SpinLitter(((ICat)cat).Litter);
                _pocoContext.Build<List<ILitterForCat>>(
                    littersOptions
                );
                litters.Clear();

                for (int step = 0; step < 2; ++step)
                {
                    catsFilter.Self = null;
                    if (step == 0)
                    {
                        catsFilter.Self = ((ICat)cat).Litter.Female;
                    }
                    else if (step == 1 && ((ICat)cat).Litter.Male is { })
                    {
                        catsFilter.Self = ((ICat)cat).Litter.Male;
                    }
                    if (catsFilter.Self is { })
                    {
                        BuildCats<T>(catsFilter, catsOptions);
                        foreach (T item in cats)
                        {
                            if (step == 0)
                            {
                                ((ICat)cat).Litter.Female = (ICat)item;
                            }
                            else
                            {
                                ((ICat)cat).Litter.Male = (ICat)item;
                            }
                            queue.Enqueue(item);
                        }
                        cats.Clear();
                    }
                }
            }
            if (!object.ReferenceEquals(cat, filter.Descendant) && TestFilter(filter, (ICat)cat))
            {
                yield return cat;
            }
        }
    }

    private IEnumerable<DbDataReader?> SpinLitter(ILitter litter)
    {
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetLitter(((IEntity)litter).PrimaryKey);

        if (dataReader.Read())
        {
            yield return dataReader;
        }
        dataReader.Close();
    }

    private IEnumerable<T> SpinDescendantCats<T>(ICatFilter filter, BuildingOptions options)
    {
        Queue<T> queue = new();
        List<T> cats = new();
        ICatFilter catsFilter = _services.GetRequiredService<ICatFilter>();
        catsFilter.Self = filter.Ancestor;
        BuildingOptions catsOptions = new()
        {
            JsonSerializerOptions = _pocoContext.BindJsonSerializerOptions(),
            Target = cats
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
            T cat = queue.Dequeue();
            if (!object.ReferenceEquals(cat, filter.Ancestor) && TestFilter(filter, ((ICat)cat)))
            {
                yield return cat;
            }
            for (int step = 0; step < 2; ++step)
            {
                if (step == 0 && (((ICat)cat)!.Gender is Gender.Female || ((ICat)cat).Gender is Gender.FemaleCastrate))
                {
                    catsFilter.Mother = ((ICat)cat);
                    catsFilter.Father = null;
                }
                else if (step == 1 && (((ICat)cat)!.Gender is Gender.Male || ((ICat)cat).Gender is Gender.MaleCastrate))
                {
                    catsFilter.Father = ((ICat)cat);
                    catsFilter.Mother = null;
                }
                if (catsFilter.Mother is { } || catsFilter.Father is { })
                {
                    BuildCats<T>(catsFilter, catsOptions);
                    foreach (T item in cats)
                    {
                        if (((ICat)item).Litter is { })
                        {
                            if (step == 0)
                            {
                                ((ICat)item).Litter.Female = ((ICat)cat);
                            }
                            else
                            {
                                ((ICat)item).Litter.Male = ((ICat)cat);
                            }
                        }
                        queue.Enqueue(item);
                    }
                    cats.Clear();
                }
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
        DbDataReader dataReader = _services.GetRequiredService<IStorage>().GetCat(((IEntity)self).PrimaryKey);

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

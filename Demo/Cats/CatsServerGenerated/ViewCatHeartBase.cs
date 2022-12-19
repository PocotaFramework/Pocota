/////////////////////////////////////////////////////////////////////
// Server Poco Implementation                                      //
// CatsClient.ViewCatHeartBase                                     //
// Generated automatically from CatsClient.ICatsFormHeartsContract //
// at 2022-12-19T17:40:44                                          //
/////////////////////////////////////////////////////////////////////


using CatsCommon.Model;
    using Net.Leksi.Pocota;
    using Net.Leksi.Pocota.Common;
    using Net.Leksi.Pocota.Server;
    using System;
    using System.Collections.Generic;
    
namespace CatsClient;

public class ViewCatHeartBase: EnvelopeBase, IProjector, IProjection<ViewCatHeartBase>
{

    #region Projection classes;


    [Poco(typeof(IViewCatHeart))]
    public class ViewCatHeartProjection: IViewCatHeart, IProjector, IProjection<ViewCatHeartBase>
    {
        private readonly ProjectionList<LitterBase,ILitter> _selectedLitters;

        public  ViewCatHeartBase Source  { get; init; }

        public virtual EditKind EditKind 
        {
            get => Source.EditKind!;
            set => Source.EditKind = value;
        }

        public virtual ICatForView Cat 
        {
            get => Source.Cat!;
            set => Source.Cat = value;
        }

        public virtual Object LittersView 
        {
            get => Source.LittersView!;
            set => Source.LittersView = value;
        }

        public virtual IList<ILitter> SelectedLitters 
        {
            get => _selectedLitters;
            set => throw new NotImplementedException();
        }


        internal ViewCatHeartProjection(ViewCatHeartBase source)
        {
            Source = source;
            _selectedLitters = new(Source.SelectedLitters);
        }

        public I As<I>()
        {
            return (I)Source.As(typeof(I))!;
        }

        public object? As(Type type) 
        {
            return Source.As(type);
        }




    }
    #endregion Projection classes;

    
    public static void InitProperties()
    {
        Properties.Add(typeof(ViewCatHeartBase), new Properties<PocoBase>());
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "EditKind", 
                typeof(EditKind),
                GetEditKindValue, 
                SetEditKindValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, EditKind>()
        );
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "Cat", 
                typeof(CatBase),
                GetCatValue, 
                SetCatValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, ICatForView>()
        );
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "LittersView", 
                typeof(Object),
                GetLittersViewValue, 
                SetLittersViewValue, 
                null, 
                false, 
                false, 
                false            
            )
            .AddPropertyType<IViewCatHeart, Object>()
        );
        Properties[typeof(ViewCatHeartBase)].Add(
                new Property<PocoBase>(
                "SelectedLitters", 
                typeof(List<LitterBase>),
                GetSelectedLittersValue, 
                null, 
                null, 
                false, 
                false, 
                true            
            )
            .AddPropertyType<IViewCatHeart, IList<ILitter>>()
        );
    }


    
    private ViewCatHeartProjection? _asViewCatHeartProjection = null;

    public ViewCatHeartProjection AsViewCatHeartProjection => _asViewCatHeartProjection ??= new(this);


    
    public ViewCatHeartBase Source { get => this; }

    
    public EditKind        EditKind  { get; set; } = default!;            
    public CatBase        Cat  { get; set; } = default!;            
    public Object        LittersView  { get; set; } = default!;            
    public List<LitterBase>        SelectedLitters  { get; init; } = new();            


    public ViewCatHeartBase(IServiceProvider services) : base(services) 
    { 
    }

    
    public override Properties<PocoBase> GetProperties() => Properties[typeof(ViewCatHeartBase)];

    public override object? As(Type type)
    {
        if(type == typeof(ViewCatHeartProjection) || type == typeof(IViewCatHeart))
        {
            return AsViewCatHeartProjection;
        }
        return null;
    }




    
    #region Properties accessors;

    private static object? GetEditKindValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).EditKind;
    }

    private static void SetEditKindValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).EditKind = (EditKind)value!;
    }
    private static object? GetCatValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).Cat;
    }

    private static void SetCatValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).Cat = (CatBase)value!;
    }
    private static object? GetLittersViewValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).LittersView;
    }

    private static void SetLittersViewValue(PocoBase target, object? value)
    {
        ((ViewCatHeartBase)target).LittersView = (Object)value!;
    }
    private static object? GetSelectedLittersValue(PocoBase target)
    {
        return ((ViewCatHeartBase)target).SelectedLitters;
    }


    #endregion Properties accessors;


}
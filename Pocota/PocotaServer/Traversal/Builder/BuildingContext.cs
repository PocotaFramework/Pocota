using System.Data.Common;

namespace Net.Leksi.Pocota.Server;

internal class BuildingContext
{
    private readonly IServiceProvider _services;

    internal TreeWalkerBufferWriter? BufferWriter { get; set; }

    internal Dictionary<string, object> Presets { get; init; } = new();

    internal string? Name { get; set; } = null;

    internal BuildingEventArgs BuildingEventArgs { get; init; }

    internal PocoTraversalContext? TraversalContext { get; set; }

    internal DbDataReader? DataReader { get; set; } = null;

    internal Stack<SpinnerHolder> Spinners { get; init; } = new();

    internal int Level { get; set; } = 0;

    internal CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    internal BuildingLog? Log { get; set; } = null;

    public Action<object>? OnItem { get; set; } = null;

    public BuildingContext(IServiceProvider services)
    {
        _services = services;
        BuildingEventArgs = new((_services.GetRequiredService<IPocoContext>() as PocoContext)!, this);
    }


}

using Net.Leksi.Pocota.Common;

namespace Net.Leksi.Pocota.Server;

internal class BuildingContext
{
    private readonly BuildingContext? _parent;
    private bool _hasError = false;

    internal PropertyUse PropertyUse { get; set; } = null!;
    internal Dictionary<string, BuildingContext> PropertyUsesContexts { get; init; } = new();
    internal BuildingContext DataReaderRoot { get; set; } = null!;
    internal DataProvider? DataProvider { get; set; }
    internal int EntityLevel { get; set; } = -1;
    internal bool IsSingleQuery { get; set; } = true;
    internal bool WithDirectOutput { get; init; }
    internal List<TracingHolder> TracingLog { get; init; }
    internal object? Value { get; set; } = null;
    internal Dictionary<string, object> SetKeyParts { get; init; } = new();
    internal bool WithTracing { get; init; } = false;
    internal bool IsTop => _parent is null;
    internal bool HasError
    {
        get => _hasError;
        set
        {
            if(!_hasError && value)
            {
                _hasError = true;
                if(_parent is { })
                {
                    _parent.HasError = true;
                }
            }
        }
    }

    internal BuildingContext(BuildingContext parent)
    {
        this._parent = parent;
        TracingLog = this._parent.TracingLog;
        WithDirectOutput = this._parent.WithDirectOutput;
        WithTracing = this._parent.WithTracing;
    }

    internal BuildingContext(bool withDirectOutput, bool withTracing)
    {
        WithDirectOutput = withDirectOutput;
        WithTracing = withTracing;
        _parent = null;
        TracingLog = new();
    }
}

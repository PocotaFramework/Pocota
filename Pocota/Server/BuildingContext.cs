using Net.Leksi.Pocota.Common;
using System.Collections;

namespace Net.Leksi.Pocota.Server;

internal class BuildingContext
{
    private readonly BuildingContext? _parent;
    private bool _hasError = false;
    private List<TracingEntry> _tracingLog { get; init; }

    internal PropertyUse PropertyUse { get; set; } = null!;
    internal Dictionary<string, BuildingContext> PropertyUsesContexts { get; init; } = new();
    internal BuildingContext DataReaderRoot { get; set; } = null!;
    internal DataProvider? DataProvider { get; set; }
    internal int EntityLevel { get; set; } = -1;
    internal bool IsSingleQuery { get; set; } = true;
    internal bool WithDirectOutput { get; init; }
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
    internal IEnumerable<TracingEntry> TracingLog => _tracingLog.Select(e => e);

    internal TracingEntry? LastTracingEntry => _tracingLog.LastOrDefault();

    internal BuildingContext(BuildingContext parent)
    {
        _parent = parent;
        _tracingLog = _parent._tracingLog;
        WithDirectOutput = _parent.WithDirectOutput;
        WithTracing = _parent.WithTracing;
        _hasError = _parent.HasError;
    }

    internal BuildingContext(bool withDirectOutput, bool withTracing)
    {
        WithDirectOutput = withDirectOutput;
        WithTracing = withTracing;
        _parent = null;
        _tracingLog = new();
    }

    internal void Clear()
    {
        if (IsTop)
        {
            _tracingLog.Clear();
        }
        Value = null;
    }

    internal void Trace(TracingEntry tracingEntry)
    {
        _tracingLog.Add(tracingEntry);
    }
}

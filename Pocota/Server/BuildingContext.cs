﻿using Net.Leksi.Pocota.Common;
using System.Collections;

namespace Net.Leksi.Pocota.Server;

public class BuildingContext
{
    private readonly BuildingContext? _parent;
    private bool _hasError = false;
    private List<TracingEntry> _tracingLog { get; init; }

    internal Dictionary<string, BuildingContext> PropertyUsesContexts { get; init; } = new();
    internal BuildingContext DataReaderRoot { get; set; } = null!;
    internal BuildingContext Root { get; init; } = null!;
    internal DataProvider? DataProvider { get; set; }
    internal bool IsSingleQuery { get; set; } = true;
    internal Dictionary<string, object> SetKeyParts { get; init; } = new();
    internal TracingEntry? LastTracingEntry => _tracingLog.LastOrDefault();

    public object? Value { get; internal set; } = null;
    public PropertyUse PropertyUse { get; init; } = null!;
    public bool WithTracing { get; init; } = false;
    public bool IsRoot => _parent is null;
    public bool HasError
    {
        get => _hasError;
        internal set
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
    public IEnumerable<TracingEntry> TracingLog => _tracingLog.Select(e => e);
    public bool WithDirectOutput { get; init; } = false;
    public BuildingContext? Parent => _parent;

    internal BuildingContext(BuildingContext parent)
    {
        _parent = parent;
        _tracingLog = _parent._tracingLog;
        WithDirectOutput = _parent.WithDirectOutput;
        WithTracing = _parent.WithTracing;
        _hasError = _parent.HasError;
        DataReaderRoot = _parent.DataReaderRoot;
        Root = _parent.Root;
    }

    internal BuildingContext(bool withDirectOutput, bool withTracing)
    {
        WithDirectOutput = withDirectOutput;
        WithTracing = withTracing;
        _parent = null;
        _tracingLog = new();
        Root = this;
    }

    internal void Clear()
    {
        if (IsRoot)
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

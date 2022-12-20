using Net.Leksi.Pocota.Server;
using Net.Leksi.Pocota.Traversal;
using Net.Leksi.Pocota.Traversal.Builder;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace Net.Leksi.Pocota.Builder;

internal class BuildingContext
{
    private readonly IServiceProvider _services;
    private readonly List<BuildingLogEntry> _buildingLog = new();

    internal bool Failed { get; private set; } = false;

    internal TreeWalkerBufferWriter? BufferWriter { get; set; }

    internal Dictionary<string, object> PresetKeys { get; init; } = new();

    internal string? Name { get; set; } = null;

    internal BuildingEventArgs BuildingEventArgs { get; init; }

    internal PocoTraversalContext? TraversalContext { get; set; }

    internal DbDataReader? DataReader { get; set; } = null;

    internal Stack<SpinnerHolder> Spinners { get; init; } = new();

    internal int Level { get; set; } = 0;

    internal CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    internal string StackTrace { get; set; }

    public BuildingContext(IServiceProvider services)
    {
        _services = services;
        BuildingEventArgs = new((_services.GetRequiredService<IPocoContext>() as PocoContext)!, this);
    }

    internal void AddLogEntry(bool isKeyRequest, Type type, string? path)
    {
        _buildingLog.Add(new BuildingLogEntry
        {
            IsKeyRequest = isKeyRequest,
            Type = type,
            PathSelector = path,
            Data = null,
            Result = BuildingEventResult.Matching
        });
    }

    internal void UpdateLogEntry(object? data, BuildingEventResult result)
    {
        if (_buildingLog.Last().Result is not BuildingEventResult.Matching && result != _buildingLog.Last().Result)
        {
            AddLogEntry(_buildingLog.Last().IsKeyRequest, _buildingLog.Last().Type, _buildingLog.Last().PathSelector);
        }
        _buildingLog.Last().Data = data;
        _buildingLog.Last().Result = result;
        if (_buildingLog.Last().Result != BuildingEventResult.Matched)
        {
            Failed = true;
        }
    }

    internal void ResetBuildingLog()
    {
        _buildingLog.Clear();
        Failed = false;
    }

    internal void Throw()
    {
        string message = $"Several errors occurred during the build process!\n{GetLog()}\n{SqueezeStackTrace(StackTrace)}";
        throw new InvalidOperationException(message);
    }

    private string GetLog()
    {
        List<Tuple<string, string, string, string, string>> log = new();
        int pos = 0;
        int[] alignment = _buildingLog.Where(e => e.Result is not BuildingEventResult.Matched).Aggregate<BuildingLogEntry, int[], int[]>(
            new int[] { 0, 0, 0, 0 },
            (longest, next) =>
            {
                string comment = next.Data is null ? String.Empty
                : (next.Data is Exception ex ? BuildCommentFromException(ex) : BuildCommentFromArray((object[])next.Data, next.Result));
                log.Add(new Tuple<string, string, string, string, string>(
                    (++pos).ToString() + ".    ",
                    (next.IsKeyRequest ? "k" : "p") + "> " + next.Type.ToString(),
                    next.PathSelector!,
                    next.Result.ToString(),
                    comment
                ));
                if (longest[0] < log.Last().Item1.ToString().Length)
                {
                    longest[0] = log.Last().Item1.ToString().Length;
                }
                if (longest[1] < log.Last().Item2.Length)
                {
                    longest[1] = log.Last().Item2.Length;
                }
                if (longest[2] < log.Last().Item3.Length)
                {
                    longest[2] = log.Last().Item3.Length;
                }
                if (longest[3] < log.Last().Item4.Length)
                {
                    longest[3] = log.Last().Item4.Length;
                }
                return longest;
            },
            res => res
        );
        return String.Join(
                    "\n", log.Select(
                        v => String.Format(
                                $"{{0,{(alignment[0])}}}{{1,{-(alignment[1] + 4)}}}{{2,{-(alignment[2] + 4)}}}{{3,{-(alignment[3] + 4)}}}{{4}}",
                                v.Item1, v.Item2, v.Item3, v.Item4, v.Item5
                            )
                    )
                )
                + "\n";
    }

    private string BuildCommentFromArray(object[] data, BuildingEventResult result)
    {
        return $"[{string.Join(", ", data)}]";
    }

    private string BuildCommentFromException(Exception ex)
    {
        return $"{ex.Message}\n{SqueezeStackTrace(ex.StackTrace)}\n{SqueezeStackTrace(StackTrace)}";
    }

    private string SqueezeStackTrace(string? stackTrace)
    {
        Regex regex = new Regex($@":line\s+\d+");
        bool points = false;

        return string.Join('\n', 
            stackTrace?.ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(line =>
            {
                if (regex.IsMatch(line))
                {
                    points = false;
                    return line;
                }
                if (!points)
                {
                    points = true;
                    return "   ...";
                }
                return null;
            }).Where(line => line is { })!
        );
    }

}

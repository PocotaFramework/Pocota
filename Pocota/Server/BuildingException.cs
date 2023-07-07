using System.Text;

namespace Net.Leksi.Pocota.Server;

public class BuildingException: Common.BuildingException
{
    private static readonly Func<TracingEntry, string> _getResponse = t =>
    {
        string? r = t.Response!.ToString(); 
        return r!.Length <= s_responseTrim 
            ? r : 
            $"{r.Substring(0, (s_responseTrim - 3) / 2)}...{r.Substring(r.Length - (s_responseTrim - 3) / 2)}";
    };

    public IEnumerable<TracingEntry> TracingLog { get; init; }

    internal BuildingException(string? message, List<TracingEntry> tracingsLog): base(message)
    {
        TracingLog = tracingsLog;
        RecommendedRequestFieldLength = tracingsLog.Select(t => Math.Max(t.Request.ToString().Length, s_requestHeader.Length)).Max();
        RecommendedPathFieldLength = tracingsLog.Select(t => Math.Max(t.Path?.Length ?? 0, s_pathHeader.Length)).Max();
        RecommendedResponseFieldLength = tracingsLog.Select(_getResponse).Select(r => r.Length).Max();
        RecommendedCommentFieldLength = tracingsLog.Select(t => Math.Max(t.Comment?.Length ?? 0, s_commentHeader.Length)).Max();
        List<TracingEntry>.Enumerator enumerator = tracingsLog.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); ++i)
        {
            TracingEntry tracing = enumerator.Current;
            if (tracing.Success is bool success)
            {
                if (tracing.Exception is { })
                {
                    tracing.Comment = $"Exception: [{_exceptions.Count + 1}]";
                    _exceptions.Add(tracing.Exception);
                }
                TracingEntries.Add(
                    new Common.TracingEntry
                    {
                        Request = tracing.Request.ToString(),
                        Path = tracing.Path!,
                        Response = tracing.Response!.ToString()!,
                        Comment = tracing.Comment,
                    }
                );
            }
        }
    }

    internal static BuildingException Create(string? message, IEnumerable<TracingEntry> tracings)
    {
        StringBuilder sb = new();
        List<Exception> exceptions = new();

        if (message is { })
        {
            sb.AppendLine(message);
        }
        else
        {
            sb.AppendLine("There are building errors:");
        }
        int maxPathLength = tracings.Select(t => Math.Max(t.Path?.Length ?? 0, s_pathHeader.Length)).Max();
        int maxCommentLength = tracings.Select(t => Math.Max(t.Comment?.Length ?? 0, s_commentHeader.Length)).Max();
        int maxRequestLength = tracings.Select(t => Math.Max(t.Request.ToString().Length, s_requestHeader.Length)).Max();
        List<string> responses = tracings.Select(_getResponse).ToList();
        int maxResponseLength = responses.Select(r => r.Length).Max();
        sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        sb.AppendFormat($"{{0,-{maxRequestLength}}}|", s_requestHeader);
        sb.AppendFormat($"{{0,-{maxPathLength}}}|", s_pathHeader);
        sb.AppendFormat($"{{0,-{maxResponseLength}}}|", s_responseHeader);
        sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", s_successHeader);
        sb.AppendFormat($"{{0, -{maxCommentLength}}}", s_commentHeader);
        sb.AppendLine();
        sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        IEnumerator<TracingEntry> enumerator = tracings.GetEnumerator();
        for (int i = 0; enumerator.MoveNext(); ++i)
        {
            TracingEntry tracing = enumerator.Current;
            if (tracing.Success is bool success)
            {
                if(tracing.Exception is { })
                {
                    tracing.Comment = $"Exception: [{exceptions.Count + 1}]";
                    exceptions.Add(tracing.Exception);
                }
                sb.AppendFormat($"{{0,-{maxRequestLength}}}|", tracing.Request);
                sb.AppendFormat($"{{0,-{maxPathLength}}}|", tracing.Path);
                string response = tracing.Response?.ToString() ?? "null";
                sb.AppendFormat($"{{0,-{maxResponseLength}}}|", responses[i]);
                sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", success ? "OK" : "Fail");
                sb.AppendFormat($"{{0, -{maxCommentLength}}}", tracing.Comment ?? string.Empty);
                sb.AppendLine();
            }
        }
        sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        if (exceptions.Any())
        {
            sb.AppendLine("Exceptions:");
            for(int i = 0; i < exceptions.Count; ++i)
            {
                sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
                sb.Append($"[{i + 1}]: ").AppendLine(exceptions[i].ToString());
            }
            sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        }

        return new BuildingException(sb.ToString(), tracings);
    }
}

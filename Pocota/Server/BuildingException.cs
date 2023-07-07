using Net.Leksi.Pocota.Common;
using System.Text;

namespace Net.Leksi.Pocota.Server;

public class BuildingException: Exception
{
    private const int s_responseTrim = 80;
    private const string s_requestHeader = "Request";
    private const string s_pathHeader = "Path";
    private const string s_responseHeader = "Response";
    private const string s_successHeader = "Success";
    private const string s_commentHeader = "Comment";
    public IEnumerable<TracingEntry> TracingLog { get; init; }

    private BuildingException(string? message, IEnumerable<TracingEntry> tracingsLog): base(message)
    {
        TracingLog = tracingsLog;
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
        List<string> responses = tracings.Select(t => t.Response.ToString()).Select(r => r.Length <= s_responseTrim ? r : $"{r.Substring(0, (s_responseTrim - 3) / 2)}...{r.Substring(r.Length - (s_responseTrim - 3) / 2)}").ToList();
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

using Net.Leksi.Pocota.Common;
using System.Text;

namespace Net.Leksi.Pocota.Server;

public class BuildingException: Exception
{
    private const int s_responseTrim = 20;
    private const string s_requestHeader = "Request";
    private const string s_pathHeader = "Path";
    private const string s_responseHeader = "Response";
    private const string s_successHeader = "Success";
    private const string s_commentHeader = "Comment";
    public List<TracingHolder> TracingLog { get; init; }

    private BuildingException(string? message, List<TracingHolder> tracings): base(message)
    {
        TracingLog = tracings;
    }

    internal static BuildingException Create(string? message, List<TracingHolder> tracings)
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

        sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + s_responseTrim + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        sb.AppendFormat($"{{0,-{maxRequestLength}}}|", s_requestHeader);
        sb.AppendFormat($"{{0,-{maxPathLength}}}|", s_pathHeader);
        sb.AppendFormat($"{{0,-{s_responseTrim}}}|", s_responseHeader);
        sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", s_successHeader);
        sb.AppendFormat($"{{0, -{maxCommentLength}}}", s_commentHeader);
        sb.AppendLine();
        sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + s_responseTrim + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        foreach (TracingHolder tracing in tracings)
        {
            if(tracing.Success is bool success)
            {
                if(tracing.Exception is { })
                {
                    tracing.Comment = $"Exception: [{exceptions.Count + 1}]";
                    exceptions.Add(tracing.Exception);
                }
                sb.AppendFormat($"{{0,-{maxRequestLength}}}|", tracing.Request);
                sb.AppendFormat($"{{0,-{maxPathLength}}}|", tracing.Path);
                string response = tracing.Response?.ToString() ?? "null";
                sb.AppendFormat($"{{0,-{s_responseTrim}}}|", response.Length <= s_responseTrim ? response : $"{response.Substring(0, (s_responseTrim - 3) / 2)}...{response.Substring(response.Length - (s_responseTrim - 3) / 2)}");
                sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", success ? "OK" : "Fail");
                sb.AppendFormat($"{{0, -{maxCommentLength}}}", tracing.Comment ?? string.Empty);
                sb.AppendLine();
            }
        }

        return new BuildingException(sb.ToString(), tracings);
    }
}

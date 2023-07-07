using System.Text;

namespace Net.Leksi.Pocota.Common;

public class BuildingException: Exception
{
    protected const int s_responseTrim = 80;
    protected const string s_requestHeader = "Request";
    protected const string s_pathHeader = "Path";
    protected const string s_responseHeader = "Response";
    protected const string s_successHeader = "Success";
    protected const string s_commentHeader = "Comment";

    protected List<Exception> _exceptions = new();

    protected List<TracingEntry> TracingEntries { get; init; } = new();

    public int RecommendedRequestFieldLength { get; init; } = 0;
    public int RecommendedPathFieldLength { get; init; } = 0;
    public int RecommendedResponseFieldLength { get; init; } = 0;
    public int RecommendedCommentFieldLength { get; init; } = 0;

    public BuildingException(string? message): base(message) { }

    public string GetExtendedMessage()
    {
        StringBuilder sb = new();

        if (Message is { })
        {
            sb.AppendLine(Message);
        }
        sb.AppendLine("There are building errors:");
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
                if (tracing.Exception is { })
                {
                    tracing.Comment = $"Exception: [{_exceptions.Count + 1}]";
                    _exceptions.Add(tracing.Exception);
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
        if (_exceptions.Any())
        {
            sb.AppendLine("Exceptions:");
            for (int i = 0; i < _exceptions.Count; ++i)
            {
                sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
                sb.Append($"[{i + 1}]: ").AppendLine(_exceptions[i].ToString());
            }
            sb.AppendLine(string.Format($"{{0, -{maxRequestLength + maxPathLength + maxResponseLength + s_successHeader.Length + maxCommentLength + 4}}}", string.Empty).Replace(' ', '-'));
        }
        return sb.ToString();
    }

}

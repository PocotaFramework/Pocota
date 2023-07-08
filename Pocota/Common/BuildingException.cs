using System.Text;

namespace Net.Leksi.Pocota.Common;

public class BuildingException: Exception
{
    protected const string s_requestHeader = "Request";
    protected const string s_pathHeader = "Path";
    protected const string s_responseHeader = "Response";
    protected const string s_successHeader = "Success";
    protected const string s_commentHeader = "Comment";

    protected List<TracingEntry> TracingEntries { get; init; } = new();

    public int RecommendedRequestFieldLength { get; protected set; } = 0;
    public int RecommendedPathFieldLength { get; protected set; } = 0;
    public int RecommendedResponseFieldLength { get; protected set; } = 0;
    public int RecommendedCommentFieldLength { get; protected set; } = 0;

    public BuildingException(string? message): base(message) 
    { 
    }

    public string GetExtendedMessage()
    {
        StringBuilder sb = new();

        if (Message is { })
        {
            sb.AppendLine(Message);
        }
        sb.AppendLine("There are building errors:");
        sb.AppendLine(string.Format($"{{0, -{RecommendedRequestFieldLength + RecommendedPathFieldLength + RecommendedResponseFieldLength + s_successHeader.Length + RecommendedCommentFieldLength + 4}}}", string.Empty).Replace(' ', '-'));
        sb.AppendFormat($"{{0,-{RecommendedRequestFieldLength}}}|", s_requestHeader);
        sb.AppendFormat($"{{0,-{RecommendedPathFieldLength}}}|", s_pathHeader);
        sb.AppendFormat($"{{0,-{RecommendedResponseFieldLength}}}|", s_responseHeader);
        sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", s_successHeader);
        sb.AppendFormat($"{{0, -{RecommendedCommentFieldLength}}}", s_commentHeader);
        sb.AppendLine();
        sb.AppendLine(string.Format($"{{0, -{RecommendedRequestFieldLength + RecommendedPathFieldLength + RecommendedResponseFieldLength + s_successHeader.Length + RecommendedCommentFieldLength + 4}}}", string.Empty).Replace(' ', '-'));

        List<string> exceptions = new();

        for (int i = 0; i < TracingEntries.Count; ++i)
        {
            TracingEntry tracing = TracingEntries[i];

            if (tracing.Success is { })
            {
                if (tracing.Exception is { })
                {
                    exceptions.Add(tracing.Exception);
                }
                sb.AppendFormat($"{{0,-{RecommendedRequestFieldLength}}}|", tracing.Request);
                sb.AppendFormat($"{{0,-{RecommendedPathFieldLength}}}|", tracing.Path);
                sb.AppendFormat($"{{0,-{RecommendedResponseFieldLength}}}|", _ge tracing.Response);
                sb.AppendFormat($"{{0, -{s_successHeader.Length}}}|", tracing.Success);
                sb.AppendFormat($"{{0, -{RecommendedCommentFieldLength}}}", tracing.Comment);
                sb.AppendLine();
            }
        }
        sb.AppendLine(string.Format($"{{0, -{RecommendedRequestFieldLength + RecommendedPathFieldLength + RecommendedResponseFieldLength + s_successHeader.Length + RecommendedCommentFieldLength + 4}}}", string.Empty).Replace(' ', '-'));
        if (exceptions.Any())
        {
            sb.AppendLine("Exceptions:");
            for (int i = 0; i < exceptions.Count; ++i)
            {
                sb.AppendLine(string.Format($"{{0, -{RecommendedRequestFieldLength + RecommendedPathFieldLength + RecommendedResponseFieldLength + s_successHeader.Length + RecommendedCommentFieldLength + 4}}}", string.Empty).Replace(' ', '-'));
                sb.Append($"[{i + 1}]: ").AppendLine(exceptions[i]);
            }
            sb.AppendLine(string.Format($"{{0, -{RecommendedRequestFieldLength + RecommendedPathFieldLength + RecommendedResponseFieldLength + s_successHeader.Length + RecommendedCommentFieldLength + 4}}}", string.Empty).Replace(' ', '-'));
        }
        return sb.ToString();
    }

}

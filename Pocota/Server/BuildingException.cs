using System.Text;

namespace Net.Leksi.Pocota.Server;

public class BuildingException : Common.BuildingException
{
    protected const int s_responseTrim = 80;

    private static readonly Func<TracingEntry, string> _getResponse = t =>
    {
        string? r = t.Response!.ToString();
        return r!.Length <= s_responseTrim
            ? r :
            $"{r.Substring(0, (s_responseTrim - 3) / 2)}...{r.Substring(r.Length - (s_responseTrim - 3) / 2)}";
    };

    internal BuildingException(string? message, IList<TracingEntry> tracingsLog) : base(message)
    {
        RecommendedRequestFieldLength = tracingsLog.Select(t => Math.Max(t.Request.ToString().Length, s_requestHeader.Length)).Max();
        RecommendedPathFieldLength = tracingsLog.Select(t => Math.Max(t.Path?.Length ?? 0, s_pathHeader.Length)).Max();
        RecommendedResponseFieldLength = tracingsLog.Select(_getResponse).Select(r => r.Length).Max();
        RecommendedCommentFieldLength = tracingsLog.Select(t => Math.Max(t.Comment?.Length ?? 0, s_commentHeader.Length)).Max();
        int exceptionNum = 1;
        for (int i = 0; i < tracingsLog.Count; ++i)
        {
            TracingEntry tracingEntry = tracingsLog[i];
            if (tracingEntry.Success is bool success)
            {
                if (tracingEntry.Exception is { })
                {
                    tracingEntry.Comment = $"Exception: [{exceptionNum}]";
                    ++exceptionNum;
                }
                TracingEntries.Add(
                    new Common.TracingEntry
                    {
                        Request = tracingEntry.Request.ToString(),
                        Path = tracingEntry.Path!,
                        Response = _getResponse(tracingEntry),
                        Comment = tracingEntry.Comment,
                        Success = success ? "OK" : "Fail",
                    }
                );
                if (tracingEntry.Exception is { })
                {
                    TracingEntries.Last().Exception = tracingEntry.Exception.ToString();
                }
            }
        }
    }
}

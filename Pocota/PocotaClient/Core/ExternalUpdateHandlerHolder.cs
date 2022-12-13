namespace Net.Leksi.Pocota.Client.Core;

internal class ExternalUpdateHandlerHolder
{
    internal Action<object> Handler { get; set; } = null!;
    internal int ReenteringCount { get; set; } = 0;
}

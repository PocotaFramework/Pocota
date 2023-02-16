using System;
using System.ComponentModel;

namespace Net.Leksi.Pocota.Client;

internal class WindowInfo
{
    public bool IsChanged { get; set; } = false;
    public EventHandler<PropertyChangedEventArgs>? PropertyChangedEventHandler { get; set; }
}

﻿using System.Collections.ObjectModel;
using System.Reflection;
using System;

namespace Net.Leksi.Pocota.Client;

public class ConnectorHolder
{
    public Connector Connector { get; set; } = null!;
    public ObservableCollection<Tuple<string, MethodInfo?>> Methods { get; init; } = new();
}

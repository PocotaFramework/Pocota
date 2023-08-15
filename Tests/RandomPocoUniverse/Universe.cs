﻿using System.Data;

namespace Net.Leksi.Pocota.Test.RandomPocoUniverse;

public class Universe
{
    public List<Node> Entities { get; private init; } = new();
    public List<Node> Envelopes { get; private init; } = new();
    public DataSet DataSet { get; private init; } = new();
    public string Sql { get; internal set; } = string.Empty;
}

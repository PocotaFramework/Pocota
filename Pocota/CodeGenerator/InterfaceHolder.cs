﻿namespace Net.Leksi.Pocota.Common
{
    internal class InterfaceHolder
    {
        internal Type Interface { get; set; } = null!;
        internal Type Contract { get; set; } = null!;
        internal SortedDictionary<string, PrimaryKeyDefinition> KeysDefinitions { get; init; } = new();
        internal string Name { get; set; } = null!;
        internal List<Type> Projections { get; init; } = new();
    }
}
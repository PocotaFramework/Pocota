﻿namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class PocoAttribute: Attribute
{
    public Type Interface { get; init; }
    public Type[]? Projections { get; set; }
    public object[]? PrimaryKey { get; set; }

    public PocoAttribute(Type @interface)
    {
        Interface = @interface;
    }

}
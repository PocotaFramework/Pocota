﻿namespace Net.Leksi.Pocota.Common;

[AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
public class PocoAttribute: Attribute
{
    public Type Projector { get; init; }
    public Type[]? Projections { get; set; }

    public object[]? PrimaryKey { get; set; }

    public PocoAttribute(Type projector)
    {
        Projector = projector;
    }

}
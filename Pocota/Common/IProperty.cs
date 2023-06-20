﻿namespace Net.Leksi.Pocota.Common;

internal interface IProperty
{
    string Name { get; }
    Type Type { get; }
    bool IsNullable { get; }
    bool IsReadOnly { get; }
    bool IsPoco { get; }
    bool IsEntity { get; }
    bool IsList { get; }
    Type? ItemType { get; }
    PropertyAccessMode GetAccess(object obj);
}
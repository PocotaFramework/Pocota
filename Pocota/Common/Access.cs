﻿namespace Net.Leksi.Pocota;
[Flags]
public enum Access
{
    None = 0,
    Read = 1,
    Update = 2,
    Create = 4,
    Delete = 8,
}

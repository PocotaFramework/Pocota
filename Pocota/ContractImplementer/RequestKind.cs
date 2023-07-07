﻿using System.ComponentModel;

namespace Net.Leksi.Pocota.Common;

internal enum RequestKind
{
    Connector,
    ControllerInterface,
    ControllerProxy,
    ServerImplementation,
    ClientImplementation,
    PrimaryKey
}
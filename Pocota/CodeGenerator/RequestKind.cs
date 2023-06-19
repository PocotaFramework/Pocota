using System.ComponentModel;

namespace Net.Leksi.Pocota.Common;

internal enum RequestKind
{
    [Description("Connector")]
    Connector,
    [Description("Controller Interface")]
    ControllerInterface,
    [Description("Controller Proxy")]
    ControllerProxy,
    [Description("Server Poco Implementation")]
    ServerImplementation,
    [Description("Client Poco Implementation")]
    ClientImplementation,
    [Description("Server Poco Primary Key")]
    PrimaryKey
}

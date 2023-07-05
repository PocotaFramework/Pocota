using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Leksi.Pocota.Common;

public interface IExtender
{
    IPrimaryKey PrimaryKey { get; }
}

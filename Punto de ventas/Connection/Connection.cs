using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_ventas.conecrtion
{
    public class Connection : DataConnection
    {
        public Connection() : base ("conexion") { }
    }
}

using LinqToDB;
using LinqToDB.Data;
using Punto_de_ventas.Models;
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
        public ITable<Clientes> Cliente { get { return GetTable<Clientes>(); } }
        public ITable<reportes_clientes> ReportesClientes { get { return GetTable<reportes_clientes>(); } }

    }

    
}

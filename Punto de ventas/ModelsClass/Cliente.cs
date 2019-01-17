using LinqToDB;
using Punto_de_ventas.conecrtion;
using Punto_de_ventas.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_ventas.ModelsClass
{
    public class Cliente : Connection
    {
        public List<Clientes> GetClientes()
        {
            var query = from c in Cliente
                        select c;
            return query.ToList();
        }

        public void insertCliente(string id, string nombre, string apellido, string direccion,
            string telefono)
        {
            int posicionCliente, idCliente;
            using (var db = new Connection())
            {
                db.Insert(new Clientes()
                {
                    ID =id,
                    Nombre = nombre,
                    Apellido=apellido,
                    Direccion=direccion,
                    Telefono=telefono
                });
                List<Clientes> cliente = GetClientes();
                posicionCliente = cliente.Count;
                posicionCliente--;
                idCliente = cliente[posicionCliente].IdCliente;
                db.Insert(new reportes_clientes()
                {
                    IdCliente = idCliente,
                    SaldoActual = "$0.00",
                    FechaActual="Sin fecha",
                    UltimoPago="0.00",
                    FechaPago="Sin fecha",
                    ID=id
                });
                 
            }

        }
        public void searchCliente(DataGridView dataGridView,string campo, int num_pagina,int reg_por_pagina)
        {
            IEnumerable<Clientes> query;
            int inicio = (num_pagina - 1) * reg_por_pagina;
            if (campo == "")
            {
                query = from c in Cliente select c;
            }
            else
            {
                query = from c in Cliente where c.ID.StartsWith(campo) || c.Nombre.StartsWith(campo)
                        || c.Apellido.StartsWith(campo) select c;
            }
            dataGridView.DataSource = query.Skip(inicio).Take(reg_por_pagina).ToList();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = 190;
            dataGridView.Columns[2].Width = 190;
            dataGridView.Columns[3].Width = 190;
            dataGridView.Columns[4].Width = 190;
            dataGridView.Columns[5].Width = 190;

            dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.Columns[5].DefaultCellStyle.BackColor = Color.WhiteSmoke;


        }
    }
}

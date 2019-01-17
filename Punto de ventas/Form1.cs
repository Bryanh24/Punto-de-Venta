using Punto_de_ventas.conecrtion;
using Punto_de_ventas.Models;
using Punto_de_ventas.ModelsClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_ventas
{
    public partial class Form1 : Form
    {
        TextBoxEvent evento = new TextBoxEvent();
        Cliente cliente = new Cliente();
        List<Clientes> numCliente = new List<Clientes>();
        private string accion = "insert", deudaActual, pago, dia, fecha;
        int paginas = 4, pageSize=10, maxReg=0, pageCount, numeroPagina=1;


        public Form1()
        {
            InitializeComponent();
         


            /***************************************
          * 
          * 
          *              CLIENTE
          * 
          *                    
          * **************************************/
            #region
            radioButton_IngresarCliente.Checked = true;
            radioButton_IngresarCliente.ForeColor = Color.DarkCyan;

            #endregion
        }

        //Paginador
        #region
            private void cargarDatos()
        {
            switch (paginas)
            {
                case 1:
                    numCliente = cliente.GetClientes();
                    cliente.searchCliente(dataGridView_Cliente,"", 1, pageSize);
                   
                    maxReg = numCliente.Count;

                    break;
            }
            pageCount = (maxReg / pageSize);
            if((maxReg % pageSize) >0)
            {
                pageCount += 1;
            }
            label_PaginasCliente.Text = "Paginas" + "1" + "/" + pageCount.ToString();
        }
        #endregion


        /***************************************
         * 
         * 
         *              CLIENTE
         * 
         *                    
         * **************************************/
        #region
        private void button_Clientes_Click(object sender, EventArgs e)
        {
            paginas = 1;
            accion = "insert";
            tabControl1.SelectedIndex = 1;
            cargarDatos();
            button_Clientes.Enabled = false;
            button_Ventas.Enabled = true;
            button_Productos.Enabled = true;
            button_Compras.Enabled = true;
            button_Dpto.Enabled = true;
            button_Compras.Enabled = true;
        }
        private void radioButton_IngresarCliente_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_IngresarCliente.ForeColor = Color.DarkCyan;
            radioButton_PagosDeudas.ForeColor = Color.Black;
            textBox_Nombre.ReadOnly = false;
            textBox_Apellido.ReadOnly = false;
            textBox_Direccion.ReadOnly = false;
            textBox_Telefono.ReadOnly = false;
            textBox_PagoscCliente.ReadOnly = true;
            label_PagoCliente.Text = "Pagos de Deudas";
            label_PagoCliente.ForeColor = Color.DarkCyan;

        }
        private void radioButton_PagosDeudas_CheckedChanged(object sender, EventArgs e)
        {
            radioButton_PagosDeudas.ForeColor = Color.DarkCyan;
            radioButton_IngresarCliente.ForeColor = Color.Black;
            textBox_Id.ReadOnly = false;
            textBox_Nombre.ReadOnly = true;
            textBox_Apellido.ReadOnly = true;
            textBox_Direccion.ReadOnly = true;
            textBox_Telefono.ReadOnly = true;
            textBox_PagoscCliente.ReadOnly = false;
        }
        private void textBox_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberKeyPress(e);
        }

        private void textBox_Id_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Nombre.Text == "")
            {
                label_Nombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Nombre.Text = "Nombre Completo";
                label_Nombre.ForeColor = Color.Green;
            }
        }

        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.textKeyPress(e);
        }

        private void textBox_Apellido_TextChanged(object sender, EventArgs e)
        {
            if (label_Apellido.Text == "")
            {
                label_Apellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Apellido.Text = "Apellido";
                label_Apellido.ForeColor = Color.Green;
            }

        }

        private void textBox_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.textKeyPress(e);
        }


        private void textBox_Direccion_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Direccion.Text == "")
            {
                label_Direccion.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Direccion.Text = "Direccion";
                label_Direccion.ForeColor = Color.Green;
            }
        }

       

        private void textBox_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Telefono.Text == "")
            {
                label_Telefono.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_Direccion.Text = "Dirección";
                label_Telefono.ForeColor = Color.Green;
            }

        }

        private void textBox_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberKeyPress(e);
        }

        private void textBox_PagoscCliente_TextChanged(object sender, EventArgs e)
        {
            if (textBox_PagoscCliente.Text == "")
            {
                label_PagoCliente.ForeColor = Color.LightSlateGray;
            }
            else
            {
                label_PagoCliente.Text = "Pagos";
                label_PagoCliente.ForeColor = Color.Green;
            }
        }

      
        private void textBox_PagoscCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            evento.numberDecimalKeyPress(textBox_PagoscCliente, e);
        }

        private void button_GuardarCliente_Click(object sender, EventArgs e)
        {
            if (radioButton_IngresarCliente.Checked)
            {
                guardadCliente();
            }
        }
        private void guardadCliente()
        {
            if (textBox_Id.Text == "")
            {
                label_Id.Text = "Ingrese el ID";
                label_Id.ForeColor = Color.Red;
                textBox_Id.Focus();
            }
            else
            {
                if (textBox_Nombre.Text == "")
                {
                    label_Nombre.Text = "Ingrese el Nombre";
                    label_Nombre.ForeColor = Color.Red;
                    textBox_Nombre.Focus();
                }
                else
                {
                    if (textBox_Apellido.Text == "")
                    {
                        label_Apellido.Text = "Ingrese el Apellido";
                        label_Apellido.ForeColor = Color.Red;
                        textBox_Apellido.Focus();
                    }
                    else
                    {
                        if (textBox_Direccion.Text == "")
                        {
                            label_Direccion.Text = "Ingrese la Direccion";
                            label_Direccion.ForeColor = Color.Red;
                            textBox_Direccion.Focus();
                        }
                        else
                        {
                            if (textBox_Telefono.Text == "")
                            {
                                label_Telefono.Text = "Ingrese el Telefono";
                                label_Telefono.ForeColor = Color.Red;
                                textBox_Telefono.Focus();
                            }
                            else
                            {
                                string ID = textBox_Id.Text;
                                string Nombre = textBox_Nombre.Text;
                                string Apellido = textBox_Apellido.Text;
                                string Direccion = textBox_Direccion.Text;
                                string Telefono = textBox_Telefono.Text;
                                if(accion == "insert")
                                {
                                    cliente.insertCliente(ID,Nombre,Apellido,Direccion,Telefono);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void button_PrimerosClientes_Click(object sender, EventArgs e)
        {
            numeroPagina = 1;
            label_PaginasCliente.Text = "paginas" + numeroPagina.ToString() + "/" + pageCount.ToString();
            cliente.searchCliente(dataGridView_Cliente, "", 1, pageSize);
        }

        private void button_AnteriosClientes_Click(object sender, EventArgs e)
        {
            if (numeroPagina > 1)
            {
                numeroPagina -= 1;
                label_PaginasCliente.Text = "paginas" + numeroPagina.ToString() + "/" + pageCount.ToString();
                cliente.searchCliente(dataGridView_Cliente, "", numeroPagina, pageSize);

            }
        }

        private void button_SiguientesClientes_Click(object sender, EventArgs e)
        {
            if (numeroPagina < pageCount)
            {
                numeroPagina += 1;
                label_PaginasCliente.Text = "paginas" + numeroPagina.ToString() + "/" + pageCount.ToString();
                cliente.searchCliente(dataGridView_Cliente, "", numeroPagina, pageSize);

            }
        }

        private void button_UltimosClientes_Click(object sender, EventArgs e)
        {
            numeroPagina = pageCount;
            if (numeroPagina == 0)
            {
                numeroPagina = 1;
                
            }
            label_PaginasCliente.Text = "paginas" + numeroPagina.ToString() + "/" + pageCount.ToString();
            cliente.searchCliente(dataGridView_Cliente, "", pageCount, pageSize);

        }
        private void textBox_Direccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        #endregion
    }
}

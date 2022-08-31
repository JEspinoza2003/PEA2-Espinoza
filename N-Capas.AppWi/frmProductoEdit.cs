using N_Capas.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace N_Capas.AppWi
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            if(producto.IdProducto > 0)
            {
                txtNombre.Text = producto.Nombre;
                txtMarca.Text = producto.Marca;
                decimal.Parse(txtPrecio.Text = producto.Precio.ToString());
                int.Parse(txtStock.Text = producto.Stock.ToString());
            }
        }





        private void MostrarMensaje() 
        {
            MessageBox.Show("Mensaje por defecto");
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void MostrarMensaje(string mensaje,bool tipo)
        {
            if (tipo)
            {
                MessageBox.Show(mensaje);
            }
            else {
                MessageBox.Show(mensaje, "Mensajito");
            }
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //MostrarMensaje("ggg");

            producto.Nombre = txtNombre.Text;
            producto.Marca = txtMarca.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text.ToString());
            producto.Stock = int.Parse(txtStock.Text.ToString());


            //if (producto.Precio > 2500) 
            //{
            //    MessageBox.Show("Lo siento el precio maximo para los productos solo es 2500");
            //    return;
            //}


            //if (producto.Stock <= 5)
            //{
            //    MessageBox.Show("El Stock tiene que se mayor a 5");
            //    return;
            //}



            //if (producto.Precio > 2500)
            //{
            //    MessageBox.Show("Lo siento el precio maximo para los productos solo es 2500");
            //    return;
            //}
            //else {

            //    if (producto.Stock <= 5)
            //    {
            //        MessageBox.Show("El Stock tiene que se mayor a 5");
            //        return;
            //    }

            //}



            //sobrecarga de metodos o metodos sobrecargados.
            //contructores sobrecargos

            if (producto.Precio > 2500 || producto.Stock <= 5)
            {
                MessageBox.Show("Lo siento el precio maximo para los productos solo es 2500 y El Stock tiene que se mayor a 5", "Parcial", MessageBoxButtons.OK);
                return;
            }
            else
            {

                this.DialogResult = DialogResult.OK;
            }
        }

        
    }
}

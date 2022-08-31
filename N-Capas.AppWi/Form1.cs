using N_Capas.Dominio;
using N_Capas.Logic;

namespace N_Capas.AppWi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dataGridView1.Rows.Clear();
            foreach(var producto in listado)
            {
                dataGridView1.Rows.Add(producto.IdProducto, producto.Nombre, producto.Marca, producto.Precio, producto.Stock);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new frmProductoEdit(nuevoProducto);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito)
                {
                    MessageBox.Show("El producto ha sido registrado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar al cliente", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                int filaActual = dataGridView1.CurrentRow.Index;
                var idProducto = int.Parse(dataGridView1.Rows[filaActual].Cells[0].Value.ToString());
                var productoEditar = ProductoBL.BuscarPorId(idProducto);
                var frm = new frmProductoEdit(productoEditar);
                if( frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(productoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido actualizado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la operacion de" +
                            " actualizacion", "Parcial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                int filaActual = dataGridView1.CurrentRow.Index;
                var idProducto = int.Parse(dataGridView1.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dataGridView1.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿realmente desea eliminar este producto",
                    "Parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(idProducto);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido eliminado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la eliminacion del producto", 
                            "Parcial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
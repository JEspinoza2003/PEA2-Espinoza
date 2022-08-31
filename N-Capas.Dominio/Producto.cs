using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Capas.Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Observacion { get; set; }
        public string Foto { get; set; }
        public int IdCategoria { get; set; }
    }
}

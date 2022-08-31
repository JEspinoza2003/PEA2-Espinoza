using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Capas.Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
    }
}

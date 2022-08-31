using N_Capas.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Capas.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; database=Parcial; Integrated Security=true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Producto tipo;
                            while (lector.Read())
                            {
                                tipo = new Producto();
                                tipo.IdProducto = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[1].ToString();
                                tipo.Marca = (lector[1].ToString());
                                tipo.Precio = int.Parse(lector[2].ToString());
                                tipo.Stock = int.Parse(lector[3].ToString());
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Cliente BuscarPorId(int id)
        {
            Cliente cliente = new Cliente();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Cliente WHERE IdCliente = @id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            cliente = new Cliente();
                            cliente.IdCliente = int.Parse(lector[0].ToString());
                            cliente.NroDocumento = (lector[1].ToString());
                            cliente.Nombre = (lector[2].ToString());
                            cliente.Direccion = (lector[3].ToString());
                            cliente.Telefono = (lector[4].ToString());
                            cliente.Observacion = (lector[5].ToString());
                        }
                    }
                }
            }
            return cliente;
        }
        public bool Insertar(Producto tipo)
        {
            int filasInsertardas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Producto (Nombre," +
                    "Marca, Precio, Stock )" +
                    "VALUES(@Nombre, @Marca," +
                    "@Precio, @Stock )";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@Marca", tipo.Marca);
                    comando.Parameters.AddWithValue("@Precio", tipo.Precio);
                    comando.Parameters.AddWithValue("@Stock", tipo.Stock);
                    filasInsertardas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertardas > 0;
        }
        public bool Actualizar(Producto tipo)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Producto SET Nombre=@Nombre," +
                    "Marca=@Marca, Precio=@Precio," +
                    "Stock=@Stock WHERE IdProducto=@ID";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", tipo.Nombre);
                    comando.Parameters.AddWithValue("@Marca", tipo.Marca);
                    comando.Parameters.AddWithValue("@Precio", tipo.Precio);
                    comando.Parameters.AddWithValue("@Stock", tipo.Stock);
                    comando.Parameters.AddWithValue("@ID", tipo.IdProducto);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }
        public bool Eliminar(int id)
        {
            int filasEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "DELETE FROM Producto WHERE IdProducto=@id";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    filasEliminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEliminadas > 0;
        }
    }
}

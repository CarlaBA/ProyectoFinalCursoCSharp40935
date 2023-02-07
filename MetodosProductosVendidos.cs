using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class MetodosProductosVendidos
    {
        public static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        public static List<Producto> ObtenerProductosVendidos(long idUsuario)
        {
            List<long> idProductos = new List<long>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario} ", con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                       
                    }
                }
                List<Producto> productos = new List<Producto>();
                foreach (var item in idProductos)
                {

                    Producto producto = new Producto();
                    MetodosProducto.ObtenerProducto(item);
                    productos.Add(producto);
                }
                
                
                return productos;

            }
        }
    }
}

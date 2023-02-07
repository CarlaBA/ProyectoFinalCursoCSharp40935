using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal static class MetodosProducto
    {
        public static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        public static List<Producto> ObtenerProducto(long idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = reader.GetInt64(0);
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);

                        productos.Add(producto);
                    }
                } return productos;

            }
        }


        


















    }
}

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
        public static List<ProductoVendido> ObtenerProductosVendidos(long id)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT Stock, IdProducto, IdVenta FROM ProductoVendido WHERE Id = {id} ", con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        ProductoVendido productoVendido = new ProductoVendido();
                        productoVendido.Id = reader.GetInt64(0);
                        productoVendido.Stock = reader.GetInt32(1);
                        productoVendido.IdProducto= reader.GetInt64(2);
                        productoVendido.IdVenta = reader.GetInt64(3);

                        productosVendidos.Add(productoVendido);
                    }
                } return productosVendidos;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class MetodosVenta
    {
        public static List<Venta> TraerVentas(long id)
        {
            
            List<Venta> listaObtenerVentas = new List<Venta>();


            SqlCommand comando = new SqlCommand ("SELECT * FROM Venta WHERE @Id = id");
            comando.Parameters.AddWithValue("@Id", id);
            Program.conexionSql.GetCommand(comando);

            SqlDataReader reader = comando.ExecuteReader();
                
            if (reader.HasRows)
            {
               while (reader.Read())
               {
                 Venta venta = new Venta();
                 venta.Id = reader.GetInt64(0);
                 venta.Comentarios = reader.GetString(1);
                 venta.IdUsuario = reader.GetInt64(2);
                 listaObtenerVentas.Add(venta);
               }
                            
            }
            return listaObtenerVentas;
            
            
        }
    }
}

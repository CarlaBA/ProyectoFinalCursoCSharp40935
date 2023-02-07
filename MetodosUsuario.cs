using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal class MetodosUsuario
    {
        public static string conexion = "Data Source = DESKTOP-2FTHB12\\MSSQLSERVER1; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        public static List<Usuario> TraerUsuario(long id)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand ($"SELECT * FROM Usuario WHERE Id = {id} ",con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contrasenia = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                        listaUsuario.Add(usuario);
                    }
                }
                return listaUsuario;

            }
            
        }


        public static Usuario LogginUsuario(string usuario, string contraseña)
        {
            Usuario usuarioLogin = new Usuario();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario = {usuario} and Contraseña = {contraseña}", con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario user = new Usuario();
                        user.Id = reader.GetInt64(0);
                        user.Nombre = reader.GetString(1);
                        user.Apellido = reader.GetString(2);
                        user.NombreUsuario = reader.GetString(3);
                        user.Contrasenia = reader.GetString(4);
                        user.Mail = reader.GetString(5);

                        usuarioLogin = user;
                    }
                }
            }   
            return usuarioLogin;

        }
    }
}











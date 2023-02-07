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


        public static bool LogginUsuario(string usuario, string contraseña)
        {
            int cont = 0;
            bool logingExitoso = false;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comando = new SqlCommand ($"SELECT * FROM Usuario WHERE NombreUsuario = {usuario}, Contraseña = {contraseña}",con);
                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
              
                do
                {
                if (contraseña == contraseña && usuario == usuario)
                {
                        logingExitoso = true;
                }
                 else
                {
                  Console.WriteLine("PASWORD  O NOMBRE INCORRECTO, por favor vuelva a intentarlo");
                }

                 cont++;

                 if (cont > 5)
                {
                 if (cont == 4)
                {
                Console.WriteLine("ULTIMO INTENGO ANTES DE QUE EL PROGRAMA SE CIERRE");
                }
                break;
                }

                } while (logingExitoso is false);


                if (logingExitoso)
                {
                            Console.WriteLine("BIENVENIDO!!!");
                            return logingExitoso = true;
                }
                        else
                        {
                            Console.WriteLine("ERROR AL LOGEARSE");
                            return logingExitoso = false;
                        }

                    }
            return logingExitoso;

        }
    }
}











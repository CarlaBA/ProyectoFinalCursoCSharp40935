﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    internal static class MetodosUsuario
    {
        public static List<Usuario> TraerUsuario(long id)
        {
            List<Usuario> listaUsuario = new List<Usuario>();

  
            SqlCommand comando = new SqlCommand ("SELECT * FROM Usuario WHERE @Id = id");
            comando.Parameters.AddWithValue("@id", id);

            Program.conexionSql.GetCommand(comando);

            using (SqlDataReader reader = comando.ExecuteReader())
            {
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
            Usuario user = new Usuario();

            
          
            SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @NombreUsuario = NombreUsuario and @Contraseña = Contraseña");
            comando.Parameters.AddWithValue("@NombreUsuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);
            Program.conexionSql.GetCommand(comando);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
               while (reader.Read())
               {
                  
                  user.Id = reader.GetInt64(0);
                  user.Nombre = reader.GetString(1);
                  user.Apellido = reader.GetString(2);
                  user.NombreUsuario = reader.GetString(3);
                  user.Contrasenia = reader.GetString(4);
                  user.Mail = reader.GetString(5);

                  
               }
            }
             
            return user;

        }
    }
}











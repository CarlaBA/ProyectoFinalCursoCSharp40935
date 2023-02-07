using System;
using System.Reflection.Metadata.Ecma335;

namespace Proyecto_final
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***OBTENER TODOS LOS USUARIOS***");
            List<Usuario> listaUsuario = MetodosUsuario.TraerUsuario(1);

            Console.WriteLine("---Nombre---\t---Apellido---\t---Usuario---");
            foreach (var list in listaUsuario)
            {

                Console.WriteLine(list.Nombre);

            }
            foreach (var item in listaUsuario)
            {

                Console.WriteLine(item.Apellido);

            }
            foreach (var user in listaUsuario)
            {

                Console.WriteLine(user.NombreUsuario);

            }





            Console.WriteLine("***OBTENER TODOS LOS PRODUCTOS QUE CARGO EL USUARIO 1***");
            List<Producto> productos = MetodosProducto.ObtenerProducto(1);

            Console.WriteLine("---ID--- \t  ---Descripciones---");
            foreach (var id in productos)
            {

                Console.WriteLine(id.Id);

            }
            foreach (var item in productos)
            {
               
                    Console.WriteLine(item.Descripciones);
            
            }



            Console.WriteLine("***OBTENER TODOS LOS PRODUCTOS VENDIDOS QUE CARGO EL USUARIO 1***");
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            MetodosProductosVendidos.ObtenerProductosVendidos(1);

            Console.WriteLine("---ID Producto--- \t  ---Descripciones---");
            foreach (var id in productosVendidos)
            {

                Console.WriteLine(id.IdProducto);

            }
          
            foreach (var item in productos)
            {

                Console.WriteLine(item.Descripciones);

            }


            Console.WriteLine("***OBTENER TODOS LAS VENTAS REALIZADAS POR EL USUARIO 1***");
            List<Venta> listaObtenerVentas = MetodosVenta.TraerVentas(1);

            Console.WriteLine("---ID Venta--- \t  ---Descripciones---");
            foreach (var id in listaObtenerVentas)
            {

                Console.WriteLine(id.Id);

            }

            foreach (var item in productos)
            {

                Console.WriteLine(item.Descripciones);

            }


            Console.WriteLine("***INICIO DE SESION***");
            Usuario usuarioLogin = MetodosUsuario.LogginUsuario("tcasazza","SoyTobiasCasazza");
            Console.WriteLine($"Nombre:{usuarioLogin.Nombre} \tApellido:{usuarioLogin.Apellido}\tMail:{usuarioLogin.Mail}");
            
           






        }
    }
}
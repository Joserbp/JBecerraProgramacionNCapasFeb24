using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {

        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Escriba el nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Escriba el ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escriba el ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            //bool resultado = BL.Usuario.Add(usuario);
            bool resultado = BL.Usuario.AddSP(usuario);

            if (resultado)
            {
                Console.WriteLine("Se inserto correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }

        public static void GetAll()
        {

            List<ML.Usuario> usuarios = BL.Usuario.GetAll();


            if (usuarios.Count > 0) //Trae datos
            {

                foreach(ML.Usuario usuario in usuarios)
                {
                    Console.WriteLine("El id es: " +  usuario.IdUsuario);
                    Console.WriteLine("El Nombre es: " +  usuario.Nombre);
                    Console.WriteLine("-------------------------------------------");

                    //Pintar todo lo demas
                }
            }
            else
            {
                Console.WriteLine("La tabla esta vacia");
            }

        }

        public static void GetById()
        {
            Console.WriteLine("ingrese el Id a buscar");
            int idUsuario = int.Parse(Console.ReadLine());

            ML.Usuario usuario = BL.Usuario.GetByIdSP(idUsuario);


            if (usuario.IdUsuario != 0) //Trae datos
            {

                
                    Console.WriteLine("El id es: " + usuario.IdUsuario);
                    Console.WriteLine("El Nombre es: " + usuario.Nombre);
                    Console.WriteLine("-------------------------------------------");


            }
            else
            {
                Console.WriteLine("La tabla esta vacia");
            }

        }
    }


}

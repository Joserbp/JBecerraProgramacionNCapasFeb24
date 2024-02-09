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

            bool resultado = BL.Usuario.Add(usuario);

            if (resultado)
            {
                Console.WriteLine("Se inserto correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }
        }
    }
}

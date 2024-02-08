using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba el nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el ApellidoPaterno");
            string apellidoPaterno = Console.ReadLine();
            Console.WriteLine("Escriba el ApellidoMaterno");
            string apellidoMaterno = Console.ReadLine();

            bool resultado = Usuario.Add(nombre,apellidoPaterno,apellidoMaterno);

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

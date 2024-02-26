using System;

namespace Logica // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Examen de logica Palindromo // Ordenamiento //Fibonacci


            //Fibo  sig num es la suma de sus dos anteriores 0 1
            //cuanto quieres ver  0 1 1 2 3 

            int inicio = 0;  //2
            int anterior = 1; //2
            int repeticiones = int.Parse(Console.ReadLine());

            Console.WriteLine(0);
            for (int i = 0; i < repeticiones; i++)  
            {
                int resultado = inicio + anterior;
                Console.WriteLine(resultado); 
                inicio = anterior;
                anterior = resultado;
            }


            Console.ReadKey();



            //Palindromo  //Lee izq-derecha ------ derecha-izq


            Console.WriteLine("Palindromo");
            string palabra = Console.ReadLine().Replace(" ","").ToLower();
            string palabraReversa = "";

            Console.WriteLine(palabra);
            //palabra long -- palabra 0  i--
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                    palabraReversa += palabra[i];
            }

            if(palabra == palabraReversa)
            {
                Console.WriteLine("Es palindromo");
            }
            else
            {
                Console.WriteLine("No es palindromo");
            }

        }
    }
}
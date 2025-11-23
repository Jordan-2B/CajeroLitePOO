using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CajeroLitePOO
{
    internal static class Utilidades
    {
        // Validar si una entrada es número entero
        public static bool EsNumeroEntero(string entrada)
        {
            return int.TryParse(entrada, out _);
        }

        // Validar si una entrada es decimal
        public static bool EsNumeroDecimal(string entrada)
        {
            return decimal.TryParse(entrada, out _);
        }

        // Validar opción de menú
        public static bool ValidarOpcionMenu(string opcion, int max)
        {
            if (!EsNumeroEntero(opcion))
            {
                Console.WriteLine("❌ La opción debe ser un número.");
                return false;
            }

            int op = int.Parse(opcion);

            if (op < 1 || op > max)
            {
                Console.WriteLine("❌ Opción fuera del rango permitido.");
                return false;
            }

            return true;
        }

      
        public static void MostrarEncabezado(string titulo)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("   " + titulo);
            Console.WriteLine("===================================");
        }

       
        public static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    
        public static void Mensaje(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

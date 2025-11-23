using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CajeroLitePOO
{
    internal static class Cajero
    {
        public static void Iniciar(Usuario[] usuarios)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Ingrese su ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese su PIN: ");
            int pin = int.Parse(Console.ReadLine());

            // Buscar usuario
            Usuario usuario = null;

            foreach (var u in usuarios)
            {
                if (u.ValidarAcceso(id, nombre, pin))
                {
                    usuario = u;
                    break;
                }
            }

            if (usuario == null)
            {
                Console.WriteLine("Credenciales incorrectas.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Bienvenido, {usuario.Nombre}");
            Menu(usuario);
        }

        public static void Menu(Usuario usuario)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DEL CAJERO ===");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Cambiar PIN");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        usuario.Cuenta.ConsultarSaldo();
                        break;

                    case "2":
                        Console.Write("Monto a depositar: ");
                        usuario.Cuenta.Depositar(decimal.Parse(Console.ReadLine()));
                        break;

                    case "3":
                        Console.Write("Monto a retirar: ");
                        usuario.Cuenta.Retirar(decimal.Parse(Console.ReadLine()));
                        break;

                    case "4":
                        Console.Write("Nuevo PIN: ");
                        usuario.CambiarPin(int.Parse(Console.ReadLine()));
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

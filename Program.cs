using System;

namespace CajeroLitePOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilidades.MostrarEncabezado("Cajero Automático");

            Console.WriteLine("Ingrese su ID:");
            string idEntrada = Console.ReadLine();

            if (!Utilidades.EsNumeroEntero(idEntrada))
            {
                Console.WriteLine("❌ El ID debe ser un número.");
                return;
            }

            int id = int.Parse(idEntrada);

            Console.WriteLine("Ingrese su nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su PIN:");
            string pinEntrada = Console.ReadLine();

            if (!Utilidades.EsNumeroEntero(pinEntrada))
            {
                Console.WriteLine("❌ El PIN debe ser numérico.");
                return;
            }

            int pin = int.Parse(pinEntrada);

            // Buscar índice del usuario en Data
            int indice = Array.IndexOf(Data.IDUsuarios, id);

            if (indice == -1 ||
                Data.Usuarios[indice] != nombre ||
                Data.Pines[indice] != pin)
            {
                Console.WriteLine("❌ Datos incorrectos. Acceso denegado.");
                return;
            }

            Console.WriteLine($"\n✅ Bienvenido {nombre}");

           
            Cuenta cuenta = new Cuenta(indice);

            // Crear usuario y asociar cuenta
            Usuario usuario = new Usuario(
                Data.IDUsuarios[indice],
                Data.Usuarios[indice],
                Data.Pines[indice],
                cuenta
            );

            // Entrar al menú del cajero
            Cajero.Menu(usuario);
        }
    }
}

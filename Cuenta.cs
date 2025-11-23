using System;

namespace CajeroLitePOO
{
    internal class Cuenta
    {
        private int indiceUsuario;

       
        public Cuenta(int indice)
        {
            indiceUsuario = indice;
        }

        // ✔ Mostrar saldo
        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo actual: {Data.Saldo[indiceUsuario]}");
        }

        // ✔ Depositar
        public void Depositar(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("El monto debe ser mayor a 0.");
                return;
            }

            Data.Saldo[indiceUsuario] += cantidad;
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: {Data.Saldo[indiceUsuario]}");
        }

        // ✔ Retirar
        public void Retirar(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("El monto debe ser mayor a 0.");
                return;
            }

            if (cantidad > Data.Saldo[indiceUsuario])
            {
                Console.WriteLine("Fondos insuficientes.");
                return;
            }

            Data.Saldo[indiceUsuario] -= cantidad;
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: {Data.Saldo[indiceUsuario]}");
        }

        // ✔ MENÚ 
        public void Menu(int indice)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DEL CAJERO ===");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConsultarSaldo();
                        break;

                    case "2":
                        Console.Write("Monto a depositar: ");
                        decimal dep = decimal.Parse(Console.ReadLine());
                        Depositar(dep);
                        break;

                    case "3":
                        Console.Write("Monto a retirar: ");
                        decimal ret = decimal.Parse(Console.ReadLine());
                        Retirar(ret);
                        break;

                    case "4":
                        Console.WriteLine("Saliendo al login...");
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

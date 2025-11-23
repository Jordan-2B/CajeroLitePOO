using System;

namespace CajeroLitePOO
{
    internal class Usuario
    {
        public int IDUsuario { get; private set; }
        public string Nombre { get; private set; }
        public int Pin { get; private set; }

        public Cuenta Cuenta { get; private set; }

        // Ahora recibimos la cuenta desde afuera
        public Usuario(int idUsuario, string nombre, int pin, Cuenta cuenta)
        {
            IDUsuario = idUsuario;
            Nombre = nombre;
            Pin = pin;
            Cuenta = cuenta ?? throw new ArgumentNullException(nameof(cuenta));
        }

        public void CambiarPin(int nuevoPin)
        {
            if (nuevoPin <= 0)
            {
                Console.WriteLine("El PIN debe ser mayor que 0.");
                return;
            }

            Pin = nuevoPin;
           
            int i = Array.IndexOf(Data.IDUsuarios, IDUsuario);
            if (i >= 0) Data.Pines[i] = nuevoPin;

            Console.WriteLine("PIN cambiado correctamente.");
        }

        public bool ValidarAcceso(int id, string nombre, int pin)
        {
            return IDUsuario == id && Nombre == nombre && Pin == pin;
        }
    }
}

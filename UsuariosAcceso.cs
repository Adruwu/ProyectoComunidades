using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoComunidades
{
    internal class UsuariosAcceso : Usuarios
    {
        private bool CumpleRequisitosUsuario(string usuario)
        {

            if (usuario.Length < 5)
            {
                Console.WriteLine("El nombre de usuario debe tener al menos 5 caracteres.");
                return false;
            }

            if (!Regex.IsMatch(usuario, "^[a-zA-Z0-9]+$"))
            {
                Console.WriteLine("El nombre de usuario solo debe contener letras y números.");
                return false;
            }

            return true;
        }

        private bool CumpleRequisitosContrasenia(string contrasenia)
        {

            if (contrasenia.Length < 8)
            {
                Console.WriteLine("La contraseña debe tener al menos 8 caracteres.");
                return false;
            }

            if (!contrasenia.Any(char.IsUpper))
            {
                Console.WriteLine("La contraseña debe contener al menos una letra mayúscula.");
                return false;
            }

            if (!contrasenia.Any(char.IsLower))
            {
                Console.WriteLine("La contraseña debe contener al menos una letra minúscula.");
                return false;
            }

            if (!contrasenia.Any(char.IsDigit))
            {
                Console.WriteLine("La contraseña debe contener al menos un número.");
                return false;
            }

            return true;
        }

        private bool ComprobarUsuarioRepetido(string usuario)
        {
            string archivoPath = "C:\\Users\\admata\\source\\repos\\ProyectoComunidades\\database.txt";

            // Verificar si el archivo existe
            if (File.Exists(archivoPath))
            {
                string[] lineas = File.ReadAllLines(archivoPath);

                foreach (string linea in lineas)
                {
                    if (linea.Contains($"Usuario: {usuario} "))
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public override void Registrarse()
        {
            string usuarioTemporal;
            string contraseniaTemporal;
            string contraseniaTemporalRepetida;

            // El archivo (database.txt) suplirá temporalmente la función de una tabla de Usuarios en una BBDD.
            string contenidoArchivo = File.ReadAllText("C:\\Users\\admata\\source\\repos\\ProyectoComunidades\\database.txt");
            string[] elementos = contenidoArchivo.Split(' ');
            int proximoIdUsuario = elementos.Length + 1;


            Console.WriteLine("Nombre de usuario: ");
            usuarioTemporal = Console.ReadLine();

            while (ComprobarUsuarioRepetido(usuarioTemporal) == true)
            {
                Console.WriteLine("El usuario ya está registrado, inicia sesión o introduce otro");
                Console.WriteLine("Nombre de usuario: ");
                usuarioTemporal = Console.ReadLine();
            }
            

            while (!CumpleRequisitosUsuario(usuarioTemporal) || usuarioTemporal == null)
            {
                Console.WriteLine("El nombre de usuario no cumple los requisitos. Inténtalo de nuevo.");
                Console.WriteLine("Usuario: ");
                usuarioTemporal = Console.ReadLine();
            }

            Console.WriteLine("Contraseña: ");
            contraseniaTemporal = Console.ReadLine();
            while (!CumpleRequisitosContrasenia(contraseniaTemporal) || contraseniaTemporal == null)
            {
                Console.WriteLine("La contraseña no cumple los requisitos. Inténtalo de nuevo.");
                Console.WriteLine("Contraseña: ");
                contraseniaTemporal = Console.ReadLine();
            }

            Console.WriteLine("Repite la contraseña: ");
            contraseniaTemporalRepetida = Console.ReadLine();
            while (contraseniaTemporal != contraseniaTemporalRepetida || contraseniaTemporalRepetida == null)
            {
                Console.WriteLine("Las contraseñas no coinciden. Inténtalo de nuevo.");
                Console.WriteLine("Repite la Contraseña: ");
                contraseniaTemporalRepetida = Console.ReadLine();
            }

            Usuario nuevoUsuario = new Usuario(proximoIdUsuario, usuarioTemporal, contraseniaTemporal);
            ListaUsuarios.Add(nuevoUsuario);

            File.AppendAllText("C:\\Users\\admata\\source\\repos\\ProyectoComunidades\\database.txt", $"Usuario: {usuarioTemporal} Contrasenia: {contraseniaTemporal}\n");
            Console.WriteLine("\n~Usuario registrado con éxito.\n");

        }

        public override void IniciarSesion()
        {

        }
    }
}

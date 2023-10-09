using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades
{
    public class Plataforma : IPlataforma
    {
        private string usuarioActual;

        // Este "Menú" es una interfaz visual temporal para testear las primeras compilaciones.
        public void MostrarOpciones()
        {
            
            int opcion;

            do
            {
                Console.WriteLine("\n~ 1) Registrarse: \n" +
                                    "~ 2) Iniciar sesión: \n" +

                                    "~ 0) Ir Atrás: \n");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        Usuarios _usuarios = new UsuariosAcceso();
                        _usuarios.Registrarse();

                        break;

                    case 2:

                        break;
                        
                    case 0:

                        break;

                }

            } while (opcion != 0);
        }

        private void CrearChatComunitario()
        {

        }

        private void VerListaChatsComunitarios()
        {

        }
    }
}

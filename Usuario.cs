using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoComunidades
{
    public class Usuario
    {
        public Usuario(int idUsuario, string nombre, string contrasenia)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Contrasenia = contrasenia;
        }
        public Usuario(int idUsuario, string contrasenia)
        {
            this.IdUsuario = idUsuario;
            this.Contrasenia = contrasenia;
        }
        public Usuario(int idUsuario, string nombre, string contrasenia, int edad, string email, string descripcion)
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.Contrasenia = contrasenia;
            this.Edad = edad;
            this.Email = email;
            this.Descripcion = descripcion;
        }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }
    }
}

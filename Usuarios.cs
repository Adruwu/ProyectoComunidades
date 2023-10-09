using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades
{
    public abstract class Usuarios : IGestionarUsuarios
    {
        private List<Usuario> listaUsuarios;
        private int numeroUsuarios;

        public Usuarios()
        {
            ListaUsuarios = new List<Usuario>();
        }

        public List<Usuario> ListaUsuarios { get => listaUsuarios; set => listaUsuarios = value; }
        public int NumeroUsuarios { get => numeroUsuarios; set => numeroUsuarios = value; }

        public abstract void Registrarse();
        public abstract void IniciarSesion();

    }
}

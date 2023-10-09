using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades
{
    public abstract class Comunidades : IGestionarComunidades
    {
        private List<Comunidad> listaComunidades;
        private int numeroComunidades;

        public Comunidades()
        {
            ListaComunidades = new List<Comunidad>();
        }

        public List<Comunidad> ListaComunidades { get => listaComunidades; set => listaComunidades = value; }
        public int NumeroComunidades { get => numeroComunidades; set => numeroComunidades = value; }

        public void CrearComunidad()
        {

        }

        public void VerListaChatsComunitarios()
        {

        }
    }
}

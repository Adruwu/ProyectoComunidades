using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades
{
    public class Comunidad
    {

        private int idComunidad;
        private string nombre;
        private string tematica;
        private int numeroMiembros;

        public Comunidad(int idComunidad, string nombre, string tematica, int numeroMiembros)
        {
            this.idComunidad = idComunidad;
            this.nombre = nombre;
            this.tematica = tematica;
            this.numeroMiembros = numeroMiembros;
        }

        public int IdComunidad { get => idComunidad; set => idComunidad = value; }
        public string Nombre { get; set; }
        public string Tematica { get => tematica; set => tematica = value; }
        public int NumeroMiembros { get => numeroMiembros; set => numeroMiembros = value; }
    }
}

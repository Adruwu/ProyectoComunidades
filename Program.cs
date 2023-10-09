using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoComunidades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPlataforma _plataforma = new Plataforma();
            _plataforma.MostrarOpciones();

        }
    }
}

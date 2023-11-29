using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cCategoria
    {
        private int Codigo;
        private string Nombre;
        private string Descripcion;

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Codigo1 { get => Codigo; set => Codigo = value; }
    }
}

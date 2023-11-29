using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cCargo
    {
        private int IdCargo;
        private string Nombre;
        private string Descripcion;

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int IdCargo1 { get => IdCargo; set => IdCargo = value; }
    }
}

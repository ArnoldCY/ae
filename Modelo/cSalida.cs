using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cSalida
    {
        private int IdSalida;
        private DateTime fecha;
        private float total;
        private int cI_Empleado;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Total { get => total; set => total = value; }
        public int CI_Empleado { get => cI_Empleado; set => cI_Empleado = value; }
        public int IdSalida1 { get => IdSalida; set => IdSalida = value; }
    }
}

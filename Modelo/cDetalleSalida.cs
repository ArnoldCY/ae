using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cDetalleSalida
    {
        private int idSalida;
        private string idArticulo;
        private int cantidad;
        private float precio_unitario;

        public int IdSalida { get => idSalida; set => idSalida = value; }
        public string IdArticulo { get => idArticulo; set => idArticulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
    }
}

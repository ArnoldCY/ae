using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cDetalleEntrada
    {
        private int idEntrada;
        private string idArticulo;
        private int cantidad;
        private float precio_unitario;

        public int IdEntrada { get => idEntrada; set => idEntrada = value; }
        public string IdArticulo { get => idArticulo; set => idArticulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cArticulo
    {
        private string idArticulo;
        private string Nombre;
        private string Descripcion;
        private float Precio;
        private int Stock;
        private int idCategoria;

        public string IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
    }
}

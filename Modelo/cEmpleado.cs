using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class cEmpleado
    {
        private int CI;
        private string Usuario;
        private string Contraseña;
        private string Nombre;
        private string ApPaterno;
        private string ApMaterno;
        private int CargoID;
        private string Telefono;
        private string Correo;
        private string Direccion;

        public int CI1 { get => CI; set => CI = value; }
        public string Usuario1 { get => Usuario; set => Usuario = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string ApPaterno1 { get => ApPaterno; set => ApPaterno = value; }
        public string ApMaterno1 { get => ApMaterno; set => ApMaterno = value; }
        public int CargoID1 { get => CargoID; set => CargoID = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
    }
}

using Conexion;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion.Formularos
{
    public partial class FormCargo : Form
    {
        public FormCargo()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
        private void CargarGrid()
        {
            try
            {
                bdCargo fun = new bdCargo();
                DataTable dt = new DataTable();

                dt = fun.Cargar();

                if (dt.Rows.Count > 0)
                {
                    dgvCargo.DataSource = dt;
                    dgvCargo.DataMember = "Cargo";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                int sqlok;
                sqlok = 0;
                if (!string.IsNullOrEmpty(txtNombre.Text) & !string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    var dt = new cCargo();
                    var fu = new bdCargo();

                    dt.Nombre1 = Convert.ToString(txtNombre.Text);
                    dt.Descripcion1 = Convert.ToString(txtDescripcion.Text);
                    sqlok = fu.Insertar(dt);
                    if (sqlok > 0)
                    {
                        CargarGrid();
                        //LimpiarNuevo();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

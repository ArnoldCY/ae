using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularos
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void hideSubMenu()
        {
            if (PanelEntrada.Visible == true)
                PanelEntrada.Visible = false;
            if (PanelSalida.Visible == true)
                PanelSalida.Visible = false;
            if (PanelArticulo.Visible == true)
                PanelArticulo.Visible = false;
            if (PanelEmpleado.Visible == true)
                PanelEmpleado.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelEntrada);
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelSalida);
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelArticulo);
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelEmpleado);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}

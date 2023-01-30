using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnForm01_Click(object sender, EventArgs e)
        {
            Form01PrimerAdo form01PrimerAdo= new Form01PrimerAdo();
            form01PrimerAdo.ShowDialog();
        }

        private void btnForm02_Click(object sender, EventArgs e)
        {
            Form02BuscadorEmpleados form02BuscadorEmpleados = new();
            form02BuscadorEmpleados.ShowDialog();
        }

        private void btnForm03_Click(object sender, EventArgs e)
        {
            Form03EliminarEmpleado form03EliminarEmpleado = new Form03EliminarEmpleado();
            form03EliminarEmpleado.ShowDialog();
        }

        private void btnForm04_Click(object sender, EventArgs e)
        {
            Form04ModificarSalas form04ModificarSalas = new Form04ModificarSalas();
            form04ModificarSalas.ShowDialog();
        }

        private void btnForm05_Click(object sender, EventArgs e)
        {
            Form05DepartamentosEmpleados form05DepartamentosEmpleados = new();
            form05DepartamentosEmpleados.ShowDialog();
        }

        private void btnForm06_Click(object sender, EventArgs e)
        {
            Form06AccionDepartamento form06AccionDepartamento = new();
            form06AccionDepartamento.ShowDialog();
        }
    }
}

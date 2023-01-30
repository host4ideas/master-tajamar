using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaExamenFundamentos
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void form01ControlarInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form01FormularioHospital form01FormularioHospital = new();
            form01FormularioHospital.ShowDialog();
        }
    }
}

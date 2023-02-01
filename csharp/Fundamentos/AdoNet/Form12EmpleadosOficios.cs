using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Helpers;
using AdoNet.Models;
using AdoNet.Repositories;

namespace AdoNet
{
    public partial class Form12EmpleadosOficios : Form
    {
        private readonly RepositoryOficios repo;

        public Form12EmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new();
            this.LoadOficios();
            this.LoadEmpleados();
        }

        private void LoadOficios()
        {
            this.cmbOficios.Items.Clear();
            var oficios = this.repo.GetOficios();
            foreach (var oficio in oficios)
            {
                this.cmbOficios.Items.Add(oficio);
            }
        }

        private void LoadEmpleados()
        {
            DatosOficio datosOficio;

            if (this.cmbOficios.SelectedIndex != -1)
            {
                datosOficio = this.repo.GetDatosOficio(this.cmbOficios.SelectedItem.ToString()!);
            }
            else
            {
                datosOficio = this.repo.GetDatosOficio();
            }

            this.lstEmpleados.Items.Clear();

            foreach (var empleado in datosOficio.Empleados)
            {
                // New row
                ListViewItem vi = new(empleado.Apellido);
                vi.SubItems.Add(empleado.Oficio);
                vi.SubItems.Add(empleado.Salario.ToString());
                vi.Tag = empleado.Id;
                // Add empleado id to the list
                this.lstEmpleados.Items.Add(vi);
            }
        }

        private void cmbOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadEmpleados();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int affectedRows = this.repo.DeleteEmpleado(int.Parse(this.lstEmpleados.SelectedItems[0].Tag.ToString()!));
            MessageBox.Show($"Empleados eliminados: {affectedRows}");
            this.LoadEmpleados();
        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            int affectedRows = this.repo.IncrementarSalario(
                this.cmbOficios.SelectedItem.ToString()!,
                int.Parse(this.txtIncremento.Text));
            MessageBox.Show($"Empleados modificados: {affectedRows}");
            this.LoadEmpleados();
        }
    }
}

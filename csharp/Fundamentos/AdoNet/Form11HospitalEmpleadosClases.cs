using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Repositories;

namespace AdoNet
{
    public partial class Form11HospitalEmpleadosClases : Form
    {
        private readonly RepositoryHospital repo;

        public Form11HospitalEmpleadosClases()
        {
            InitializeComponent();
            this.repo = new();
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            var hospitales = this.repo.GetHospitales();

            foreach (var item in hospitales)
            {
                this.cmbHospital.Items.Add(item);
            }
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hospital = this.cmbHospital.SelectedItem.ToString();
            var datosHospital = this.repo.GetDatosHospital(hospital!);

            this.txtMedia.Text = datosHospital?.MediaSalarial.ToString();
            this.txtPersonas.Text = datosHospital?.Personas.ToString();
            this.txtSuma.Text = datosHospital?.SumaSalarial.ToString();

            this.lstEmpleados.Items.Clear();
            foreach (var item in datosHospital!.Empleados)
            {
                this.lstEmpleados.Items.Add(item.IdEmpleado + " - " + item.Apellido + " - " + item.Salario);
            }
        }
    }
}

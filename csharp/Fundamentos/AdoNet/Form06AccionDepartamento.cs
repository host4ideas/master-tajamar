using AdoNet.Models;
using AdoNet.Repositories;

namespace AdoNet
{
    public partial class Form06AccionDepartamento : Form
    {
        public RepositoryDepartamentos repoDepartamentos;
        private List<Departamento> departamentos;

        public Form06AccionDepartamento()
        {
            InitializeComponent();
            this.departamentos = new();
            this.repoDepartamentos = new RepositoryDepartamentos();
            try
            {
                this.ShowDepartamentos();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
            }
        }

        private async void ShowErrorMessage(string message)
        {
            this.lblError.Text = message;
            this.lblError.Visible = true;
            await Task.Delay(3000);
            this.lblError.Visible = false;
        }

        private void ShowDepartamentos()
        {
            try
            {
                this.departamentos = this.repoDepartamentos.GetDepartamentos();
                foreach (var departamento in this.departamentos)
                {
                    this.lstDepartamentos.Items.Add(departamento.Nombre);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                this.repoDepartamentos.InsertDepartamento(int.Parse(this.txtId.Text), this.txtLoc.Text, this.txtNombre.Text);
                this.ShowDepartamentos();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedDept = this.departamentos[this.lstDepartamentos.SelectedIndices[0]].IdDepartamento;
                this.repoDepartamentos.DeleteDepartamento(selectedDept);
                this.ShowDepartamentos();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedDept = this.departamentos[this.lstDepartamentos.SelectedIndices[0]].IdDepartamento;
                this.repoDepartamentos.UpdateDepartamento(selectedDept, txtNombre.Text, txtLoc.Text);
                this.ShowDepartamentos();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
            }
        }

        private void lstDepartamentos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.txtId.Text = this.departamentos[this.lstDepartamentos.SelectedIndex].IdDepartamento.ToString();
            this.txtNombre.Text = this.departamentos[this.lstDepartamentos.SelectedIndex].Nombre;
            this.txtLoc.Text = this.departamentos[this.lstDepartamentos.SelectedIndex].Localidad;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

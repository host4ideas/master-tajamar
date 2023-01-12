namespace Fundamentos
{
    public partial class Form04DateTime : Form
    {
        public Form04DateTime()
        {
            InitializeComponent();
            this.txtDate.Text = DateTime.Now.ToString();
        }

        private void btnIncr_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncr.Text);
            DateTime fecha = DateTime.Parse(this.txtDate.Text);
            if (this.rdbDays.Checked == true)
            {
                fecha = fecha.AddDays(incremento);
            }
            else if (this.rdbMonths.Checked == true)
            {
                fecha = fecha.AddMonths(incremento);
            }
            else
            {
                fecha = fecha.AddYears(incremento);
            }
            this.txtResultDate.Text = fecha.ToString();
        }

        private void chkFormat_CheckedChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(txtDate.Text);
            if (this.chkFormat.Checked)
            {
                this.txtDate.Text = date.ToLongDateString();
            }
            else
            {
                this.txtDate.Text = date.ToShortDateString();
            }
        }
    }
}

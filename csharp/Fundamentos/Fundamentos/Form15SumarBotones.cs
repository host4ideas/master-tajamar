using System;

namespace Fundamentos
{
    public partial class Form15SumarBotones : Form
    {
        int suma;
        readonly List<Button> botones;

        public Form15SumarBotones()
        {
            InitializeComponent();
            this.botones = new List<Button>();
            this.suma = 0;

            //foreach (Control control in this.Controls)
            //{
            //    if (control is Button button)
            //    {
            //        this.botones.Add(button);
            //    }
            //}

            foreach (Control control in this.panelControls.Controls)
            {
                if (control is Button button)
                {
                    this.botones.Add(button);
                }
            }

            Random random = new();
            foreach (Button boton in this.botones)
            {
                int num = random.Next(1, 200);
                boton.Text = num.ToString();
                boton.Click += SumarNumeros;
            }
        }

        private void SumarNumeros(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button button = (Button)sender;
                int num = this.suma += int.Parse(button.Text);
                this.txtResult.Text = num.ToString();
                button.BackColor= Color.LightCoral;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.suma = 0;
            this.txtResult.Text = "0";
            foreach (Button boton in this.botones)
            {
                boton.BackColor = Color.FromKnownColor(KnownColor.ButtonFace);
            }
        }
    }
}

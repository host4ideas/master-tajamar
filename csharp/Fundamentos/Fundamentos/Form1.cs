namespace Fundamentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPulsar_Click(object sender, EventArgs e)
        {
            // Aqu� es donde esbribiremos nuestras acciones al pulsar el bot�n
            this.txtNombre.Width= 150;
            this.btnPulsar.Text = "Bot�n pulsado!!!";
            Random rnd = new();
            int x = rnd.Next(600);
            int y = rnd.Next(600);
            this.txtNombre.Location = new Point(x, y);
            this.txtNombre.TextAlign = HorizontalAlignment.Center;
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            this.BackColor = Color.FromArgb(r, g, b);
        }
    }
}
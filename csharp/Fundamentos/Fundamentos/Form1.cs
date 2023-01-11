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
            // Aquí es donde esbribiremos nuestras acciones al pulsar el botón
            this.txtNombre.Width = 150;
            this.btnPulsar.Text = "Botón pulsado!!!";
            Random rnd = new();
            int x = rnd.Next(600);
            int y = rnd.Next(600);
            this.txtNombre.Location = new Point(x, y);
            this.txtNombre.TextAlign = HorizontalAlignment.Center;
            int r = rnd.Next(256);
            int g = rnd.Next(256);
            int b = rnd.Next(256);
            this.BackColor = Color.FromArgb(r, g, b);

            // Conversión automática
            short numero = 99;
            int mayor = numero;

            // Casting entre objetos
            int numeroMayor = 99;
            short numeroMenor = 888;

            // Necesitamos almacenar el número menor en el número mayor
            numeroMenor = (short)numeroMayor;

            // Convertir string a primitivo
            string textoNumero = "1444";
            int numeroEntero = 1000;
            double doble = double.Parse(textoNumero);

            // Convertir objetos a string
            int valor = 100;
            string texto = valor.ToString();
            string boton = this.btnPulsar.ToString();
        }

        private void formSumarNumerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formSumarNumeros = new Form01SumarNumeros();
            formSumarNumeros.ShowDialog();

        }

        private void formColoresPosicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form02ColoresPosicion formColoresPosicion = new Form02ColoresPosicion();
            formColoresPosicion.ShowDialog();
        }

        private void formDiaNacimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form03DiaNacimiento formDiaNacimiento = new Form03DiaNacimiento();
            formDiaNacimiento.ShowDialog();
        }

        private void formDateTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form04DateTime form04DateTime= new Form04DateTime();
            form04DateTime.ShowDialog();
        }
    }
}
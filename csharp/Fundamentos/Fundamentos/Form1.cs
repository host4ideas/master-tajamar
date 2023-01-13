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
            this.txtNombre.Width = 150;
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

            // Conversi�n autom�tica
            short numero = 99;
            int mayor = numero;

            // Casting entre objetos
            int numeroMayor = 99;
            short numeroMenor = 888;

            // Necesitamos almacenar el n�mero menor en el n�mero mayor
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

        private void formCharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form05Char form05Char = new Form05Char();
            form05Char.ShowDialog();
        }

        private void formValidarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form06Email form06Emailform = new Form06Email();
            form06Emailform.ShowDialog();
        }

        private void formSumarN�merosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form07SumarNumeros form07SumarNumeros = new Form07SumarNumeros();
            form07SumarNumeros.ShowDialog();
        }

        private void formColecci�nGr�ficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form08ColeccionGrafica form08ColeccionGrafica = new Form08ColeccionGrafica();
            form08ColeccionGrafica.ShowDialog();
        }

        private void formColecci�nMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form09ColeccionMultiple form09ColeccionMultiple = new Form09ColeccionMultiple();
            form09ColeccionMultiple.ShowDialog();
        }

        private void formColeccionParesImparesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10ColeccionRandom form10ColeccionRandom = new Form10ColeccionRandom();
            form10ColeccionRandom.ShowDialog();
        }

        private void formTiendaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11TiendaProductos form11TiendaProductos= new Form11TiendaProductos();
            form11TiendaProductos.ShowDialog();
        }

        private void formDobleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12Metodos form12Metodos= new Form12Metodos();
            form12Metodos.ShowDialog();
        }
    }
}
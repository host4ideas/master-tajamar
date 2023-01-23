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
            Form04DateTime form04DateTime = new Form04DateTime();
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

        private void formSumarNúmerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form07SumarNumeros form07SumarNumeros = new Form07SumarNumeros();
            form07SumarNumeros.ShowDialog();
        }

        private void formColecciónGráficaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form08ColeccionGrafica form08ColeccionGrafica = new Form08ColeccionGrafica();
            form08ColeccionGrafica.ShowDialog();
        }

        private void formColecciónMultipleToolStripMenuItem_Click(object sender, EventArgs e)
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
            Form11TiendaProductos form11TiendaProductos = new Form11TiendaProductos();
            form11TiendaProductos.ShowDialog();
        }

        private void formDobleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12Metodos form12Metodos = new Form12Metodos();
            form12Metodos.ShowDialog();
        }

        private void formArrayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13ArrayList form13ArrayList = new Form13ArrayList();
            form13ArrayList.ShowDialog();
        }

        private void formListEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14ListEvento form14ListEvento = new Form14ListEvento();
            form14ListEvento.ShowDialog();
        }

        private void formSumarBotonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15SumarBotones form15SumarBotones = new Form15SumarBotones();
            form15SumarBotones.ShowDialog();
        }

        private void formTablaMultiplicarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16TablaMultiplicar form16TablaMultiplicar = new Form16TablaMultiplicar();
            form16TablaMultiplicar.ShowDialog();
        }

        private void formMesesTemperaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17MesesTemp form17MesesTemp = new Form17MesesTemp();
            form17MesesTemp.ShowDialog();
        }

        private void formPruebaClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18PruebaClases form18PruebaClases = new Form18PruebaClases();
            form18PruebaClases.ShowDialog();
        }

        private void formTemperaturaClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19TemperaturaClases form19TemperaturaClases = new Form19TemperaturaClases();
            form19TemperaturaClases.ShowDialog();
        }

        private void formTemperaturasYearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20TemperaturasYears form20TemperaturasYears = new Form20TemperaturasYears();
            form20TemperaturasYears.ShowDialog();
        }

        private void formFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asdf form21Files = new asdf();
            form21Files.ShowDialog();
        }

        private void formMascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22Mascotas form22Mascotas = new Form22Mascotas();
            form22Mascotas.ShowDialog();
        }

        private void formMascotaXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form23ObjetoXMLMascota form23ObjetoXMLMascota = new();
            form23ObjetoXMLMascota.ShowDialog();
        }

        private void formColeccionMascotasXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24ColeccionXMLMascotas form24ColeccionXMLMascotas = new();
            form24ColeccionXMLMascotas.ShowDialog();
        }
    }
}
namespace Fundamentos
{
    public partial class Form14ListEvento : Form
    {
        // Declaramos la coleccion a nivel clase para utilizarla en otros eventos
        // Vamos a rellenar la coleccion con todos los botones del dibujo
        readonly List<Button> buttons = new();
        /*
            Vamos a tener una variable contador.
            Las variables a nivel clase mantienen su valor mientras estemos trabajando con esta clase
         */
        int contador;

        Button currentButton;

        public Form14ListEvento()
        {
            InitializeComponent();
            this.contador = 0;
            this.buttons = new List<Button>();
            /*
                Dentro de la clase Control (Form) hay una coleccion llamda Controls que contiene el Form.
                La norma es tener nuestras propias colecciones, no las del Form
             */
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    this.buttons.Add(button);
                }
            }

            /*
                Recorremos los botones
             */
            foreach (Button button in buttons)
            {
                button.Click += BotonPulsado;
            }
        }

        public void BotonPulsado(object? sender, EventArgs e)
        {
            this.contador++;
            this.txtMensaje.Text = "Contador: " + this.contador.ToString();

            if (sender != null)
            {
                Button button = (Button)sender;

                if (this.currentButton != button)
                {
                    this.currentButton = button;
                    button.BackColor = Color.White;
                }
                else
                {
                    this.currentButton = button;
                    button.BackColor = Color.Blue;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fundamentos
{
    public partial class Form07SumarNumeros : Form
    {
        public Form07SumarNumeros()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string textoNumeros = this.txtNumeros.Text;
            int suma = 0;

            for(int i = 0; i < textoNumeros.Length; i++)
            {
                char caracter = textoNumeros[i];
                suma += int.Parse(caracter.ToString());
            }
            this.txtResultado.Text = "La suma es: " + suma;

            foreach(Form f in this.OwnedForms)
            {

            }

            int[] numeros = new int[5] { 4, 5, 6, 7, 8 };
            int sumaArray = 0;

            foreach (int num in numeros)
            {
                sumaArray += num;
            }
        }
    }
}

using ProyectoClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fundamentos
{
    public partial class Form20TemperaturasYears : Form
    {
        List<Year> years;
        public Form20TemperaturasYears()
        {
            InitializeComponent();
            this.years = new List<Year>();
            GenerarYearsTemps();
        }

        private void GenerarYearsTemps()
        {
            this.years = new List<Year>();
            if (this.comboBoxYears.Items.Count > 0)
            {
                this.comboBoxYears.Items.Clear();
            }
            int yearNum = 2018;
            for (int i = 0; i < 5; i++)
            {
                var newYear = new Year(yearNum);
                this.years.Add(newYear);
                this.comboBoxYears.Items.Add(newYear.YearNum.ToString());
                yearNum++;
            }
            this.comboBoxYears.SelectedItem = this.comboBoxYears.Items[0];
            this.lstMeses.SelectedItem = this.lstMeses.Items[0];
        }

        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstMeses.Items.Clear();
            this.txtTempMaxYear.Text = years[this.comboBoxYears.SelectedIndex].TempMax.ToString();
            this.txtTempMinYear.Text = years[this.comboBoxYears.SelectedIndex].TempMin.ToString();
            this.txtTempMediaYear.Text = years[this.comboBoxYears.SelectedIndex].TempMedia.ToString();

            var meses = years[this.comboBoxYears.SelectedIndex].meses;

            for(int i = 0; i < meses.Count; i++)
            {
                this.lstMeses.Items.Add(meses[i]);
            }
        }

        private void lstMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedYear = years[this.comboBoxYears.SelectedIndex].YearNum;
            
            for(int i = 0; i < years.Count; i++)
            {
                if (years[i].YearNum == selectedYear)
                {
                    var indexSelectedMonth = this.lstMeses.SelectedIndex;
                    this.txtTempMax.Text = years[this.comboBoxYears.SelectedIndex].temperaturas[indexSelectedMonth].TempMax.ToString();
                    this.txtTempMin.Text = years[this.comboBoxYears.SelectedIndex].temperaturas[indexSelectedMonth].TempMin.ToString();
                    this.txtTempMedia.Text = years[this.comboBoxYears.SelectedIndex].temperaturas[indexSelectedMonth].TempMedia.ToString();
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarYearsTemps();
        }
    }
}

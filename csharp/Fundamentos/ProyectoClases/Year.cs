using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClases
{
    public class Year
    {
        public List<string> meses { get; set; }
        public List<Temperatura> temperaturas { get; set; }
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public float TempMedia { get; set; }
        public int YearNum { get; set; }

        public Year(int yearNum)
        {
            this.meses = new List<string>() { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviebre", "Diciembre" };
            this.temperaturas = new List<Temperatura>();
            GenerarMesesTemps();
            SetMinMaxMedia();
            YearNum = yearNum;
        }

        private void GenerarMesesTemps()
        {
            this.temperaturas = new List<Temperatura>();
            Random random = new();

            for (int i = 0; i < this.meses.Count; i++)
            {
                this.temperaturas.Add(new Temperatura(random.Next(-15, 40), random.Next(-15, 40)));
            }
        }

        private void SetMinMaxMedia()
        {
            int tempMax = 0;
            int tempMin = 0;
            int sumaTempsMedias = 0;

            for (int i = 0; i < this.meses.Count; i++)
            {
                if (this.temperaturas[i].TempMin < tempMin)
                {
                    tempMin = this.temperaturas[i].TempMin;
                }
                if (this.temperaturas[i].TempMax > tempMax)
                {
                    tempMax = this.temperaturas[i].TempMax;
                }
                sumaTempsMedias += this.temperaturas[i].TempMedia;
            }

            this.TempMax = tempMax;
            this.TempMin = tempMin;
            this.TempMedia = (sumaTempsMedias) / 12;
        }
    }
}

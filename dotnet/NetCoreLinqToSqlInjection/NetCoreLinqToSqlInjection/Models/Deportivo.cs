namespace NetCoreLinqToSqlInjection.Models
{
    public class Deportivo : ICoche
    {
        public Deportivo()
        {
            this.Marca = "Hyundai";
            this.Modelo = "i30N";
            this.VelocidadMaxima = 250;
            this.Velocidad = 0;
            this.Imagen = "image2.jpg";
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Imagen { get; set; }
        public int Velocidad { get; set; }
        public int VelocidadMaxima { get; set; }

        public int Acelerar()
        {
            this.Velocidad += 60;
            if (this.Velocidad > this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }
            return this.Velocidad;
        }

        public int Frenar()
        {
            this.Velocidad -= 10;
            if (this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;
        }
    }
}

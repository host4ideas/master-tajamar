namespace ProyectoClases
{
    public class Temperatura
    {
        public int TempMin { get; set; }
        public int TempMax { get; set; }
        public int TempMedia { get; set; }

        public Temperatura(int tempMin, int tempMax)
        {
            TempMin = tempMin;
            TempMax = tempMax;
            this.TempMedia = (TempMax + TempMin) / 2;
        }
    }
}

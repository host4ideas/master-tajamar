namespace PrimerMvcNetCore.Models
{
    public class ResultMultiplicarModel
    {
        public int Resultado { get; set; }
        public string Operacion { get; set; }

        public ResultMultiplicarModel(int resultado, string operacion)
        {
            Resultado = resultado;
            Operacion = operacion;
        }
    }
}

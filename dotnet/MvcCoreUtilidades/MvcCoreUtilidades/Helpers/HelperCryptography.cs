using System.Security.Cryptography;
using System.Text;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string EncriptarTextoBasico(string contenido)
        {
            byte[] entrada;

            UnicodeEncoding encoding = new();
            SHA1Managed sHA1 = new SHA1Managed();

            entrada = encoding.GetBytes(contenido);

            byte[] salida = sHA1.ComputeHash(entrada);

            string resultado = encoding.GetString(salida);
            
            return resultado;
        }
    }
}

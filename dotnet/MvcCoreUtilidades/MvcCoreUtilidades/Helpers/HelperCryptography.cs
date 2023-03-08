using System.Security.Cryptography;
using System.Text;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperCryptography
    {
        public static string Salt { get; set; }

        private static string GenerarSalt()
        {
            Random random = new();
            string salt = "";
            for (int i = 1; i <= 50; i++)
            {
                int aleatorio = random.Next(0, 255);
                char letra = Convert.ToChar(aleatorio);
                salt += letra;
            }
            return salt;
        }

        public static string EncriptarContenido(string contenido, bool comparar)
        {
            if (comparar == false)
            {
                Salt = GenerarSalt();
            }
            // Incluimos el contenido al final del password a cifrar
            string contenidoSalt = contenido + Salt;

            SHA256 sHA256 = SHA256.Create();
            byte[] salida;
            UnicodeEncoding encoding = new();
            // Convertimos a bytes el contenido del salt
            salida = encoding.GetBytes(contenidoSalt);
            // Debemos a realizar el cifrado sobre el cifrado N veces
            for (int i = 1; i <= 55; i++)
            {
                // Realizamos el cifrado
                salida = sHA256.ComputeHash(salida);
            }
            // Limpiamos el sHA256
            sHA256.Clear();

            string resultado = encoding.GetString(salida);
            return resultado;
        }

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

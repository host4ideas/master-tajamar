namespace ProyectoClases.Helpers
{
    public class HelperFiles
    {
        /// <summary>
        /// Metodo para leer ficheros
        /// </summary>
        /// <param name="path">
        /// Ruta al archivo
        /// </param>
        /// <returns></returns>
        public static async Task<string> ReadFileAsync(string path)
        {
            // El objeto fileinfo es un objeto para acceder a la info del archivo
            FileInfo file = new(path);
            // Para leer vamos a utilizar using para asegurarnos que dentro del código el objeto siempre estará accesible
            using (TextReader reader = file.OpenText())
            {
                string contenido = await reader.ReadToEndAsync();
                reader.Close();
                return contenido;
            }
        }

        /// <summary>
        /// Metodo para escribir en un file
        /// </summary>
        /// <param name="path">
        /// Ruta al archivo
        /// </param>
        /// <param name="content">
        /// Contenido
        /// </param>
        static public async Task WriteFileAsync(string path, string content)
        {
            FileInfo file = new(path);
            using (TextWriter writer = file.CreateText())
            {
                // El contenido que deseamos escribir esta en el listbox
                await writer.WriteAsync(content);
                // Siempre que trabajemos al escribir debemos terminar con el metodo flush
                await writer.FlushAsync();
                writer.Close();
            }
        }
    }
}

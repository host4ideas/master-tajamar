using ProyectoClases.Models;

namespace ProyectoClases.Helpers
{
    public class HelperMascotas
    {
        public List<Mascota> Mascotas { get; set; }
        public HelperMascotas()
        {
            this.Mascotas = new List<Mascota>();

        }

        #region METHODS
        /*
            Vamos a leer un file que contendra un text con las mascotas.
            GARFIELD#GATO,REX#PERRO
         */

        /// <summary>
        /// Crear una mascota
        /// </summary>
        /// <param name="data"></param>
        private void CreateMascota(string data)
        {
            // Limpiamos la coleccion para añadir nuevos datos
            this.Mascotas.Clear();

            // Separamos los objetos
            string[] datosMascotas = data.Split(',');
            foreach (string mascotaData in datosMascotas)
            {
                // GARFIELD#GATO
                string[] propiedades = mascotaData.Split('#');

                // Instanciamos objeto mascota 
                Mascota mascota = new(propiedades[0], propiedades[1]);
                this.Mascotas.Add(mascota);
            }
        }

        public async Task ReadFileMascotasAsync(string path)
        {
            string data = await HelperFiles.ReadFileAsync(path);
            this.CreateMascota(data);
        }

        /// <summary>
        /// Formateo de la lista de mascotas: [GARFIELD#GATO,REX#PERRO]
        /// </summary>
        /// <returns></returns>
        public string GetMascotasString()
        {
            string data = "";
            // Recorremos la coleccion mascotas y le damos formato string
            foreach (Mascota mascota in this.Mascotas)
            {
                // GARFIELD#GATO,REX#PERRO
                string temp = mascota.Nombre + "#" + mascota.Raza;
                data += temp + ",";
            }
            data = data.Trim('#');
            data = data.Trim(',');
            return data;
        }

        public async Task SaveFileMascotasAsync(string path)
        {
            string data = this.GetMascotasString();
            await HelperFiles.WriteFileAsync(path, data);
        }
        #endregion
    }
}

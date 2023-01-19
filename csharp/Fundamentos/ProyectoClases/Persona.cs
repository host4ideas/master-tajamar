namespace ProyectoClases
{
    public enum TipoGenero { Masculino = 99, Femenino = 109 }
    public enum Paises { España, Italia, GB, Brasil }
    public class Persona
    {
        public Persona()
        {
            this.DomicilioVacaciones = new Direccion("AA", 7777, "AAAA");
        }

        // Campos privados
        #region CAMPOS DE PROPIEDAD
        private int _Edad { get; set; }
        private TipoGenero _Genero;
        public Direccion Domicilio { get; set; }
        public Direccion DomicilioVacaciones { get; set; }
        #endregion

        // Propiedades publicas
        #region PROPIEDADES
        public Paises Nacionalidad { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public TipoGenero Genero
        {
            get { return this._Genero; }
            set
            {
                if (value != TipoGenero.Masculino && value != TipoGenero.Femenino)
                {
                    throw new Exception("Valor no isponible en enumeración");
                }
            }
        }
        public int Edad
        {
            get { return this._Edad; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("La edad no puede ser negativa");
                }
                else
                {
                    this._Edad = value;
                }
            }
        }
        #endregion

        #region METODOS
        public string GetNombreCompleto()
        {
            return this.Nombre + " " + this.Apellidos;
        }
        public string GetNombreCompleto(bool orden)
        {
            if (orden == true)
            {
                return this.Apellidos + " " + this.Nombre;
            }
            else
            {
                return GetNombreCompleto();
            }
        }
        public void GetNombreCompleto(string dato) { }
        public void GetNombreCompleto(int numero) { }
        public void GetNombreCompleto(int numero1, int numero2) { }
        public void MetodoParametrosOpciones(int numero1, int numero2 = 0, int numero3 = 0) { }
        #endregion
    }
}

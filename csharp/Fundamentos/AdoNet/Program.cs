namespace AdoNet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form01PrimerAdo());
            //Application.Run(new Form02BuscadorEmpleados());
            //Application.Run(new Form03EliminarEmpleado());
            //Application.Run(new Form04ModificarSalas());
            //Application.Run(new Form05DepartamentosEmpleados());
            //Application.Run(new Form06AccionDepartamento());
            Application.Run(new FormMenu());
        }
    }
}
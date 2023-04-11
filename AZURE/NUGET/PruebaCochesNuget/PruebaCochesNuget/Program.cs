using ProyectoNugetCoches;

Console.WriteLine("Prueba paquetes Nuget");

List<Coche> cars = new();
Garaje g = new();

foreach (Coche car in g.GetCoches())
{
    Console.Write("Marca: " + car.Marca);
    Console.WriteLine(" - Modelo: " + car.Modelo);
}

Console.WriteLine("Pulsa Enter para finalizar");

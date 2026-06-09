namespace Uppgift5;

internal class Program
{
    static void Main(string[] args)
    {
        var garage = new Garage<Vehicle>(10);
        garage.AddVehicle(new Vehicle("ABC321", "Blå"));
        garage.AddVehicle(new Vehicle("CAE321", "Röd"));
        garage.AddVehicle(new Vehicle("FEW453", "Gul"));
        garage.AddVehicle(new Vehicle("BBB111", "Grön"));
        garage.AddVehicle(new Vehicle("AAA444", "Vit"));
        garage.AddVehicle(new Vehicle("CUSTOM LIC", "Svart"));
        garage.AddVehicle(new Vehicle("VAA444", "Vit"));
        garage.AddVehicle(new Vehicle("AAA442", "Lila"));
        garage.AddVehicle(new Vehicle("Aaa414", "Vit"));
        garage.AddVehicle(new Vehicle("AEF544", "Vit"));

        foreach (var vehicle in garage)
            Console.WriteLine(vehicle.DisplayString);
        Console.WriteLine();

        garage.RemoveVehicle(new Vehicle("AAA414", "Svart"));

        foreach (var vehicle in garage)
            Console.WriteLine(vehicle.DisplayString);
        Console.WriteLine();

        var v = garage.FindVehicle("aaa442");
        Console.WriteLine(v != null ? v.DisplayString : "Vehicle not found");
        var v2 = garage.FindVehicle("fed442");
        Console.WriteLine(v2 != null ? v2.DisplayString : "Vehicle not found");
        Console.WriteLine();

        foreach (var vehicle in garage.Search("", "Vit"))
            Console.WriteLine(vehicle.DisplayString);

        //        Console.WriteLine();
        //        Console.Write("Press a key...");
        //        Console.ReadKey();
    }
}

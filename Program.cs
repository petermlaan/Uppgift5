using System.Diagnostics.Metrics;

namespace Uppgift5;

internal class Program
{
    static void Main(string[] args)
    {
        var garage = new Garage<Vehicle>(10);

        garage.AddVehicle(new Motorcycle("ABC321", "Blå", 2, 50));
        garage.AddVehicle(new Car("CAE321", "Röd", 4, "Gasoline"));
        garage.AddVehicle(new Car("FEW453", "Gul", 3, "Diesel"));
        garage.AddVehicle(new Bus("BBB111", "Grön", 6, 20));
        garage.AddVehicle(new Boat("AAA444", "Vit", 0, 30));
        garage.AddVehicle(new Boat("CUSLIC", "Svart", 0, 10));
        garage.AddVehicle(new Car("VAA444", "Vit", 4, "Gasoline"));
        garage.AddVehicle(new Motorcycle("AAA442", "Lila", 3, 30));
        garage.AddVehicle(new Airplane("Aaa414", "Vit", 3, 1));
        garage.AddVehicle(new Airplane("AEF544", "Vit", 6, 4));

        // Test(garage)

        bool run = true;
        while (run)
        {
            // Main menu
            Console.Clear();
            Console.WriteLine("Garage Huvudmeny");
            Console.WriteLine("");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("1. Visa alla fordon");
            Console.WriteLine("2. Visa fordonstyper");
            Console.WriteLine("3. Leta efter registreringsnummer");
            Console.WriteLine("4. Leta efter fordon");
            Console.WriteLine("5. Lägg till fordon");
            Console.WriteLine("6. Ta bort fordon");
            Console.WriteLine();
            Console.Write("> ");

            string? read = Console.ReadLine();
            switch (read)
            {
                case "0":  // Exit
                    run = false;
                    Console.WriteLine("Programmet avslutas...\n");
                    break;
                case "1": // show all
                    foreach (var vehicle in garage)
                        Console.WriteLine(vehicle.DisplayString);
                    WaitForUser();
                    break;
                case "2": // show vehicle types
                    foreach (var g in garage.GroupBy(v => v.GetType().Name))
                        Console.WriteLine(g.Key.ToString() + ": " + g.Count());
                    WaitForUser();
                    break;
                case "3": // search for license
                    {
                        Console.Write("Skriv ett registreringsnummer: ");
                        string license = Console.ReadLine() ?? "";
                        var v = garage.FindVehicle(license);
                        Console.WriteLine(v?.DisplayString);
                        WaitForUser();
                        break;
                    }
                case "4": // search for vehicles
                    {
                        Console.Write("Fordondstyp: ");
                        string type = Console.ReadLine() ?? "";
                        Console.Write("Färg: ");
                        string color = Console.ReadLine() ?? "";
                        Console.Write("Antal hjul: ");
                        string wheels = Console.ReadLine() ?? "";
                        foreach (var s in garage.Search(color, type, int.Parse(wheels)))
                            Console.WriteLine(s.DisplayString);
                        WaitForUser();
                        break;
                    }
                case "5": // add vehicle
                    {
                        string license = AskForString("Registreringsnummer");
                        string type = AskForString("Fordondstyp");
                        string color = AskForString("Färg");
                        int wheels = AskForInt("Antal hjul", 0);
                        Vehicle? vehicle = null;
                        switch (type)
                        {
                            case "Airoplane":
                                int engines = AskForInt("Antal motorer", 0);
                                vehicle = new Airplane(license, color, wheels, engines);
                                break;
                            case "Boat":
                                int length = AskForInt("Längd", 0);
                                vehicle = new Boat(license, color, wheels, length);
                                break;
                            case "Bus":
                                int seats = AskForInt("Antal säten", 0);
                                vehicle = new Bus(license, color, wheels, seats);
                                break;
                            case "Car":
                                string engineType = AskForString("Motortyp");
                                vehicle = new Car(license, color, wheels, engineType);
                                break;
                            case "Motorcycle":
                                int cc = AskForInt("Motorstorlek", 0);
                                vehicle = new Motorcycle(license, color, wheels, cc);
                                break;
                            default:
                                Error("Fel fordonstyp");
                                break;
                        }
                        if (vehicle != null)
                            garage.AddVehicle(vehicle);
                        else
                        {
                            Error("Fel");
                        }
                        WaitForUser();
                        break;
                    }
                case "6":
                    {
                        string license = AskForString("Registreringsnummer");
                        garage.RemoveVehicle(license);
                        break;
                    }
            
                default: // Incorrect choice
                    Error("Felaktigt val. Välj en siffra mellan 0 och 6.");
                    WaitForUser();
                    break;
            }
        }
    }

    private static string AskForString(string type)
    {
        Console.Write(type + ": ");
        return Console.ReadLine() ?? "";
    }
    private static int AskForInt(string type, int defaultValue)
    {
        Console.Write(type + ": ");
        string s = Console.ReadLine() ?? "";
        if (s.IsWhiteSpace())
            return defaultValue;
        return int.Parse(s);
    }
    /// <summary>
    /// Writes the error message to the console.
    /// </summary>
    /// <param name="message">The error message to be displayed.</param>
    private static void Error(string message)
    {
        Console.WriteLine(message + "\n");
    }
    /// <summary>
    /// Writes a prompt to the console and waits for the user to press any key.
    /// </summary>
    private static void WaitForUser()
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
    private static void Test(Garage<Vehicle> garage)
    {
        foreach (var vehicle in garage)
            Console.WriteLine(vehicle.DisplayString);
        Console.WriteLine();

        garage.RemoveVehicle("AAA414");

        foreach (var vehicle in garage)
            Console.WriteLine(vehicle.DisplayString);
        Console.WriteLine();

        var v = garage.FindVehicle("aaa442");
        Console.WriteLine(v != null ? v.DisplayString : "Vehicle not found");
        var v2 = garage.FindVehicle("fed442");
        Console.WriteLine(v2 != null ? v2.DisplayString : "Vehicle not found");
        Console.WriteLine();

        Console.WriteLine("Searching...");
        foreach (var vehicle in garage.Search("", "Car", -4))
            Console.WriteLine(vehicle.DisplayString);
        Console.WriteLine();

        foreach (var g in garage.GroupBy(v => v.GetType().Name))
            Console.WriteLine(g.Key.ToString() + ": " + g.Count());
    }
}

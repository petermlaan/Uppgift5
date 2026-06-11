using System;
using System.Collections.Generic;
using System.Text;
using Uppgift5;

namespace Uppgift5;

public class GarageHandler
{
    public static void Run()
    {
        var ui = new ConsoleUI();
        int cap = ui.AskForInt("Kapacitet för garaget", 0);
        if (cap < 1)
        {
            ui.Error("Dumsnut!");
            return;
        }
        var garage = new Garage<Vehicle>(cap);

        #region Add test data
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
        #endregion

        bool run = true;
        while (run)
        {
            #region Main menu
            ui.Clear();
            ui.WriteLine("Garage Huvudmeny");
            ui.WriteLine("");
            ui.WriteLine("0. Avsluta");
            ui.WriteLine("1. Visa alla fordon");
            ui.WriteLine("2. Visa fordonstyper");
            ui.WriteLine("3. Leta efter registreringsnummer");
            ui.WriteLine("4. Leta efter fordon");
            ui.WriteLine("5. Lägg till fordon");
            ui.WriteLine("6. Ta bort fordon");
            ui.WriteLine();
            ui.Write("> ");
            #endregion

            string read = ui.AskForString("> ");
            switch (read)
            {
                case "0":  // Exit
                    run = false;
                    ui.WriteLine("Programmet avslutas...\n");
                    break;
                case "1": // show all
                    foreach (var vehicle in garage)
                        ui.WriteLine(vehicle.DisplayString);
                    ui.WaitForUser();
                    break;
                case "2": // show vehicle types
                    foreach (var g in garage.GroupBy(v => v.GetType().Name))
                        ui.WriteLine(g.Key.ToString() + ": " + g.Count());
                    ui.WaitForUser();
                    break;
                case "3": // search for license
                    {
                        string license = ui.AskForString("Skriv ett registreringsnummer: ");
                        var v = garage.FindVehicle(license);
                        ui.WriteLine(v?.DisplayString ?? "");
                        ui.WaitForUser();
                        break;
                    }
                case "4": // search for vehicles
                    {
                        string type = ui.AskForString("Fordondstyp");
                        string color = ui.AskForString("Färg");
                        string wheels = ui.AskForString("Antal hjul");
                        foreach (var s in garage.Search(color, type, int.Parse(wheels)))
                            ui.WriteLine(s.DisplayString);
                        ui.WaitForUser();
                        break;
                    }
                case "5": // add vehicle
                    {
                        string license = ui.AskForString("Registreringsnummer");
                        string type = ui.AskForString("Fordondstyp");
                        string color = ui.AskForString("Färg");
                        int wheels = ui.AskForInt("Antal hjul", 0);
                        Vehicle? vehicle = null;
                        switch (type)
                        {
                            case "Airoplane":
                                int engines = ui.AskForInt("Antal motorer", 0);
                                vehicle = new Airplane(license, color, wheels, engines);
                                break;
                            case "Boat":
                                int length = ui.AskForInt("Längd", 0);
                                vehicle = new Boat(license, color, wheels, length);
                                break;
                            case "Bus":
                                int seats = ui.AskForInt("Antal säten", 0);
                                vehicle = new Bus(license, color, wheels, seats);
                                break;
                            case "Car":
                                string engineType = ui.AskForString("Motortyp");
                                vehicle = new Car(license, color, wheels, engineType);
                                break;
                            case "Motorcycle":
                                int cc = ui.AskForInt("Motorstorlek", 0);
                                vehicle = new Motorcycle(license, color, wheels, cc);
                                break;
                            default:
                                ui.Error("Fel fordonstyp");
                                break;
                        }
                        if (vehicle != null)
                            garage.AddVehicle(vehicle);
                        else
                        {
                            ui.Error("Fel");
                        }
                        ui.WaitForUser();
                        break;
                    }
                case "6":
                    {
                        string license = ui.AskForString("Registreringsnummer");
                        garage.RemoveVehicle(license);
                        break;
                    }
                default: // Incorrect choice
                    ui.Error("Felaktigt val. Välj en siffra mellan 0 och 6.");
                    ui.WaitForUser();
                    break;
            }
        }
    }
}

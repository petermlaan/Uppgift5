using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class Car: Vehicle
{
    public string Fueltype { get; }
    public override string DisplayString => base.DisplayString + "\t" + Fueltype;
    public Car(string license, string color, int wheels, string fueltype) : base(license, color, wheels)
    {
        Fueltype = fueltype;
    }
}

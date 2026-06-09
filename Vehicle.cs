using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class Vehicle
{
    public string License { get; set; }
    public string Color { get; set; }
    public virtual string DisplayString => License + "\t" + Color;

    public Vehicle(string license, string color)
    {
        License = license;
        Color = color;
    }
}

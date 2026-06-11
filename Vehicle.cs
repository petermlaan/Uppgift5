using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Uppgift5;

public abstract class Vehicle
{
    public string License { get; }
    public string Color { get; }
    public int Wheels { get; }
    public virtual string DisplayString => GetType().Name + "\t" + License + "\t" + Color;

    public Vehicle(string license, string color, int wheels)
    {
        License = license;
        Color = color;
        Wheels = wheels;
    }
}

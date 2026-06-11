using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class Boat : Vehicle
{
    public int Length { get; }
    public override string DisplayString => base.DisplayString + "\tLength:" + Length;
    public Boat(string license, string color, int wheels, int length) : base(license, color, wheels)
    {
        Length = length;
    }
}

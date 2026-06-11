using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class Airplane : Vehicle
{
    public int NoOfEngines { get; }
    public override string DisplayString => base.DisplayString + "\tEngines: " + NoOfEngines;
    public Airplane(string license, string color, int wheels, int noOfEngines) : base(license, color, wheels)
    {
        NoOfEngines = noOfEngines;
    }
}

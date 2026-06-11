using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5;

public class Motorcycle : Vehicle
{
    public int CylinderVolume { get; }
    public override string DisplayString => base.DisplayString + "\t" + CylinderVolume + " cc";
    public Motorcycle(string license, string color, int wheels, int cylinderVolume) : base(license, color, wheels)
    {
        CylinderVolume = cylinderVolume;
    }
}

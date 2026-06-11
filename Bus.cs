using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift5
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; }
        public override string DisplayString => base.DisplayString + "\tSeats:" + NumberOfSeats;
        public Bus(string license, string color, int wheels, int noOfSeats) : base(license, color, wheels)
        {
            NumberOfSeats = noOfSeats;
        }
    }
}

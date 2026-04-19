using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    internal class Car
    {
        public string Name { get; set; } = string.Empty;
        public double Speed { get; set; }
        public double Distance { get; set; } = 0;
        public bool Won = false;
        public bool Stopped { get; set; } = false;
        public DateTime FinishedAt {  get; set; }
        public string Problem { get; set; } = string.Empty;
        public Car(string name)
        {
            Name = name;
            Speed = 120;
            Distance = 0;
        }

        public void Drive()
        {
            Distance += (Speed * 1000) / 3600;
            
        }
    }
}

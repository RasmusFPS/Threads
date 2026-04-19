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
        public double Distance {get;set;}
        public bool IsFinished = false;
        public DateTime FinishedAt {  get; set; }
        public Car(string name)
        {
            Name = name;
            Speed = 120;
            Distance = 0;
        }

        public void Drive(int RaceDistants)
        {
            Console.WriteLine($"{Name} Har startat!");

            int seconds = 0;

            while(Distance < RaceDistants)
            {
               Thread.Sleep(1000);
                seconds++;

                Distance += Speed / 3600;

                if(seconds % 10 == 0)
                {
                    Random rnd = new Random();
                    int chance = rnd.Next(1, 51);
                    Events.HandleEvents(chance,this);
                }
            }

            IsFinished = true;
            FinishedAt = DateTime.Now;
            
        }
    }
}

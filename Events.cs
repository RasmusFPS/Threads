using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    internal class Events
    {
        public static void HandleEvents(int chance,Car car)
        {

            if (chance == 1)
            {
                Console.WriteLine($"{car.Name} Behöver tanka!");
                Thread.Sleep(15000);
            }
            else if (chance >= 2 && chance <= 3)
            {
                Console.WriteLine($"{car.Name} Fick punktering!");
                Thread.Sleep(10000);
            }
            else if(chance >= 4 && chance <= 8)
            {
                Console.WriteLine($"{car.Name} Fick en Fågel på vindruttan!");
                Thread.Sleep(5000);
            }
            else if (chance >= 9 && chance <= 18)
            {
                car.Speed--;
                Console.WriteLine($"{car.Name} FICK MOTORSTOP! Nu har den sänks deras hastighet permanent till {car.Speed}");
            }




        }
    }
}

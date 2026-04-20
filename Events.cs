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
        public static void HandleEvents(Car car)
        {
            Random rnd = new Random();
            int chance= rnd.Next(1, 51);

            if (chance == 1)
            {
                Console.WriteLine($"{car.Name} Behöver tanka, stannar 15 sekunder");
                car.Stopped = true;
                car.Wait = 15;
            }
            else if (chance >= 2 && chance <= 3)
            {
                Console.WriteLine($"{car.Name} Behöver byta däck, stannar 10 sekunder");
                car.Stopped = true;
                car.Wait = 10;
            }
            else if(chance >= 4 && chance <= 8)
            {
                Console.WriteLine($"{car.Name} Behöver tvätta vindrutan, stannar 5 sekunder");
                car.Stopped = true;
                car.Wait = 15;
            }
            else if (chance >= 9 && chance <= 18)
            {
                Console.WriteLine($"{car.Name} Hastigheten på bilen sänks med 1 km/h");
                car.Stopped = true;
                car.Speed--;
            }




        }
    }
}

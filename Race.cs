using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Threads;

internal class Race
{
    public bool isFinished = false;
    private static readonly object _lock = new object();
    public bool statusCheck = false;
    public static List<Car> cars = new List<Car>();
    public static double RaceDistans = 1000;

    public void StartRace()
    {
        Console.WriteLine("Tryck på valfri tangent för att starta tävlingen...");
        Console.ReadKey();
        Console.WriteLine("Loppet har startat! Tryck på [Enter] när som helst för att se status.");

        StartCars();

        while (cars.Any(car => !car.Won))
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine();

                lock (_lock)
                {
                    Console.WriteLine("\n--- AKTUELL STATUS ---");
                    foreach (var car in cars)
                    {
                        string statusText = car.Stopped ? "STÅR STILL (Problem)" : $"{car.Speed} km/h";
                        Console.WriteLine($"{car.Name,-14} | Distans: {car.Distance,7:F2}m | Hastighet: {statusText}");
                    }
                    Console.WriteLine("----------------------\n");
                }
            }

            Thread.Sleep(100);
        }

        Console.WriteLine("Loppet är över! Alla bilar är i mål.");
    }


    public void StartCars()
    {
        cars.Add(new Car("Nissa Micra"));
        cars.Add(new Car("Toyota Corola"));
        cars.Add(new Car("Volvo V70"));

        foreach (var car in cars)
        {
            Thread thread = new Thread(() =>InRace(car));
            thread.Start();
        }
    }

    static bool InRace(Car car)
    {
        int seconds = 0;

        while (!car.Won)
        {
            if (seconds % 10 == 0)
            {
                Events.HandleEvents(car);
            }
            car.Drive();
            if (car.Distance >= RaceDistans)
            {
                car.Won = true;
            }
            Thread.Sleep(1000);
            seconds++;

        }
        return true;
    }
}
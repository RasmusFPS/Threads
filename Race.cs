using System;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Threads;

internal class Race
{
    public bool isFinished = false;
    public bool statusCheck = false;
    public static List<Car> cars = new List<Car>();
    public static double RaceDistans = 5000;
    public static int Podium = 1;
    public static List<string> winners = new List<string>();

    private static readonly object _finishLock = new object();

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
               string input = Console.ReadLine();

                if (input == "status" || string.IsNullOrEmpty(input))
                {
                    Console.Clear();

                    Console.WriteLine("\n--- AKTUELL STATUS ---");
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Name,-14} | Distans: {Math.Round(car.Distance, 2)}m | Hastighet: {car.Speed} KM/H");
                    }
                    Console.WriteLine("----------------------\n");
                }
                Console.Clear();
            }

            Thread.Sleep(100);
        }

        Console.WriteLine("Loppet är över! Alla bilar är i mål.");
        ShowWinner();
        Console.ReadKey();
    }


    public void StartCars()
    {
        cars.Add(new Car("Nissa Micra"));
        cars.Add(new Car("Toyota Corola"));
        cars.Add(new Car("Volvo V70"));

        foreach (var car in cars)
        {
            Thread thread = new Thread(() => InRace(car));
            thread.Start();
        }
    }

    static bool InRace(Car car)
    {
        int seconds = 0;

        while (!car.Won)
        {
            if (seconds > 0 && seconds % 10 == 0)
            {
                Events.HandleEvents(car);
            }
            car.Drive();
            if (car.Distance >= RaceDistans)
            {
                lock (_finishLock)
                {
                    if (!car.Won)
                    {
                        car.Won = true;
                        winners.Add($"{car.Name} tagit Plats nr: {Podium} || Tid (s): {seconds}");
                        Podium++;
                    }
                }
            }
            Thread.Sleep(1000);
            seconds++;

        }
        return true;
    }

    static void ShowWinner()
    {
        foreach (var winner in winners)
        {
            Console.WriteLine(winner);
        }
    }
}
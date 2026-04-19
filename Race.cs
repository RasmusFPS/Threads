using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Threads;

internal class Race
{
    public bool isFinished = false;
    private static readonly object _lock = new object();
    public bool statusCheck = false;

    public void StartRace()
    {
        Car car1 = new Car("Nissa Micra");
        Car car2 = new Car("Toyota Corola");
        Car car3 = new Car("Volvo V70");

        Thread t1 = new Thread(() => car1.Drive(5000));
        Thread t2 = new Thread(() => car2.Drive(5000));
        Thread t3 = new Thread(() => car3.Drive(5000));

        t1.Start();
        t2.Start();
        t3.Start();




    }
}
using System;
using System.Globalization;

abstract class Vehicle
{
    public double Fuel { get; protected set; }
    public double ConsumptionPerKm { get; protected set; }
    protected double SummerIncrease { get; set; } = 0.0;

    protected Vehicle(double fuel, double consumption)
    {
        Fuel = fuel;
        ConsumptionPerKm = consumption;
    }
    public virtual bool Drive(double distance)
    {
        double needed = distance * (ConsumptionPerKm + SummerIncrease);
        if (needed <= Fuel)
        {
            Fuel -= needed;
            return true;
        }
        return false;
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
            throw new ArgumentException("Fuel must be a positive number");

        Fuel += liters;
    }
}

class Car : Vehicle
{
    public Car(double fuel, double consumption) : base(fuel, consumption)
    {
        SummerIncrease = 0.9;
    }
}

class Truck : Vehicle
{
    private const double RefuelEfficiency = 0.95;

    public Truck(double fuel, double consumption) : base(fuel, consumption)
    {
        SummerIncrease = 1.6;
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
            throw new ArgumentException("Fuel must be a positive number");

        Fuel += liters * RefuelEfficiency; 
    }
}

class Program
{
    static void Main()
    {
        CultureInfo ci = CultureInfo.InvariantCulture;

        string[] carInfo = Console.ReadLine().Split(' ');
        double carFuel = double.Parse(carInfo[1], ci);
        double carCons = double.Parse(carInfo[2], ci);
        Car car = new Car(carFuel, carCons);

        string[] truckInfo = Console.ReadLine().Split(' ');
        double truckFuel = double.Parse(truckInfo[1], ci);
        double truckCons = double.Parse(truckInfo[2], ci);
        Truck truck = new Truck(truckFuel, truckCons);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string cmd = parts[0];
            string type = parts[1];

            try
            {
                if (cmd == "Drive")
                {
                    double distance = double.Parse(parts[2], ci);

                    if (type == "Car")
                    {
                        if (car.Drive(distance))
                            Console.WriteLine($"Car travelled {distance} km");
                        else
                            Console.WriteLine("Car needs refueling");
                    }
                    else 
                    {
                        if (truck.Drive(distance))
                            Console.WriteLine($"Truck travelled {distance} km");
                        else
                            Console.WriteLine("Truck needs refueling");
                    }
                }
                else if (cmd == "Refuel")
                {
                    double liters = double.Parse(parts[2], ci);

                    if (type == "Car") car.Refuel(liters);
                    else truck.Refuel(liters);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine($"Car: {car.Fuel:F2}");
        Console.WriteLine($"Truck: {truck.Fuel:F2}");
    }
}

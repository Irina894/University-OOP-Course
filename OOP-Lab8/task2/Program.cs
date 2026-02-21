using System;
using System.Globalization;
public abstract class Vehicle
{
    protected double fuelQuantity;
    protected double fuelConsumption;
    protected double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            this.fuelQuantity = 0; 
        }
        else
        {
            this.fuelQuantity = fuelQuantity;
        }

        this.fuelConsumption = fuelConsumption;
        this.tankCapacity = tankCapacity;
    }

    public virtual void Drive(double distance)
    {
        double neededFuel = distance * fuelConsumption;
        if (neededFuel <= fuelQuantity)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
            throw new ArgumentException("Fuel must be a positive number");

        if (fuelQuantity + liters > tankCapacity)
            throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");

        fuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {fuelQuantity:F2}";
    }
}

public class Car : Vehicle
{
    private const double AirConditioner = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + AirConditioner, tankCapacity)
    {
    }
}

public class Truck : Vehicle
{
    private const double AirConditioner = 1.6;
    private const double RefuelEfficiency = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption + AirConditioner, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
            throw new ArgumentException("Fuel must be a positive number");

        double effectiveFuel = liters * RefuelEfficiency;

        if (fuelQuantity + effectiveFuel > tankCapacity)
            throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");

        fuelQuantity += effectiveFuel;
    }
}

public class Bus : Vehicle
{
    private const double AirConditioner = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public void DriveWithPeople(double distance)
    {
        double neededFuel = distance * (fuelConsumption + AirConditioner);

        if (neededFuel <= fuelQuantity)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public void DriveEmpty(double distance)
    {
        base.Drive(distance); 
    }
}

public class Program
{
    static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        var truckInfo = Console.ReadLine().Split();
        var busInfo = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var parts = Console.ReadLine().Split();
            var command = parts[0];
            var vehicleType = parts[1];
            try
            {
                if (command == "Drive")
                {
                    double distance = double.Parse(parts[2]);
                    if (vehicleType == "Car")
                        car.Drive(distance);
                    else if (vehicleType == "Truck")
                        truck.Drive(distance);
                    else if (vehicleType == "Bus")
                        bus.DriveWithPeople(distance);
                }
                else if (command == "DriveEmpty" && vehicleType == "Bus")
                {
                    double distance = double.Parse(parts[2]);
                    bus.DriveEmpty(distance);
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(parts[2]);
                    if (vehicleType == "Car")
                        car.Refuel(liters);
                    else if (vehicleType == "Truck")
                        truck.Refuel(liters);
                    else if (vehicleType == "Bus")
                        bus.Refuel(liters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}


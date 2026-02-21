using System;
using System.Collections.Generic;

class Car
{
    public string model;
    public double fuelAmount;
    public double fuelConsumptionPerKm;
    public double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
        this.distanceTraveled = 0;
    }

    public void Drive(double distance)
    {
        double neededFuel = distance * fuelConsumptionPerKm;
        if (neededFuel <= fuelAmount)
        {
            fuelAmount -= neededFuel;
            distanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter number of cars:");
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter data for car {i + 1}:");

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Fuel amount: ");
            double fuelAmount = double.Parse(Console.ReadLine());

            Console.Write("Fuel consumption per km: ");
            double fuelConsumptionPerKm = double.Parse(Console.ReadLine());

            cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKm));
        }

        Console.WriteLine("Enter commands (Drive {carModel} {distance}) or 'End' to finish:");
        while (true)
        {
            string command = Console.ReadLine();
            if (command == "End")
                break;

            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
            {
                Console.WriteLine("Invalid command! Use: Drive <CarModel> <Distance>");
                break;
            }

            if (parts[0] == "Drive")
            {
                string carModel = parts[1];

                double distance = double.Parse(parts[2]);

                Car car = cars.Find(c => c.model == carModel);
                if (car != null)
                {
                    car.Drive(distance);
                }
            }
        }

        Console.WriteLine("Final car states:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model} {car.fuelAmount:F2} {car.distanceTraveled}");
        }
    }
}

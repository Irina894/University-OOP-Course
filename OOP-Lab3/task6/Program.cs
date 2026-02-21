using System;
using System.Collections.Generic;

class Engine
{
    public string model;
    public string  power;
    public string displacement;
    public string efficiency;

    public Engine(string model,string power,string displacement="n/a",string efficiency= "n/a" )
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }
}

class Car
{
    public string model;
    public Engine engine;
    public string weight;
    public string color;
    public Car(string Model, Engine engine, string weight="n/a", string color="n/a")
    {
        this.model = Model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter n of engines:");
        int n = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter data for engine {i + 1}:");
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Power: ");
            string power = Console.ReadLine();
            Console.Write("Displacement (or press Enter to skip): ");
            string displacement = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(displacement))
            {
                displacement = "n/a";
            }
            Console.Write("Efficiency (or press Enter to skip): ");
            string efficiency = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(efficiency))
            {
                efficiency = "n/a";
            }
           engines.Add(new Engine(model, power, displacement, efficiency));
        }

        Console.WriteLine("Enter n of cars:");
        int m = int.Parse(Console.ReadLine());
  List<Car> cars = new List<Car>();

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine($"Enter data for car {i + 1}:");
            Console.Write("Model: ");
            string carModel = Console.ReadLine();
            Console.Write("Engine model: ");
            string engineModel = Console.ReadLine();
            Engine engine = engines.Find(e => e.model == engineModel);
           
            Console.Write("Weight (or press Enter to skip): ");
            string weight = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(weight))
            {
                weight = "n/a";
            }
            Console.Write("Color (or press Enter to skip): ");
            string color = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(color))
            {
                color = "n/a";
            }
           cars.Add(new Car(carModel, engine, weight, color));
        }
        Console.WriteLine("Car Information:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model}:");
            Console.WriteLine($" {car.engine.model}: Power: {car.engine.power} Displacement: {car.engine.displacement} Efficiency: {car.engine.efficiency} Weight: {car.weight} Color: {car.color}");
        }
    }
}
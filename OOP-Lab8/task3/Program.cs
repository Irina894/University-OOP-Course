using System;
using System.Globalization;

abstract class Food
{
    public int Quantity { get; protected set; }
    protected Food(int quantity) => Quantity = quantity;
}

class Vegetable : Food
{
    public Vegetable(int quantity) : base(quantity) { }
}

class Fruit : Food
{
    public Fruit(int quantity) : base(quantity) { }
}

class Meat : Food
{
    public Meat(int quantity) : base(quantity) { }
}

class Seeds : Food
{
    public Seeds(int quantity) : base(quantity) { }
}

abstract class Animal
{
    public string Name { get; protected set; }
    public double Weight { get; protected set; }
    public int FoodEaten { get; protected set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    public abstract string MakeSound();
    public abstract void Eat(Food food);
}

abstract class Bird : Animal
{
    public double WingSize { get; protected set; }
    protected Bird(string name, double weight, double wingSize)
        : base(name, weight)
    {
        WingSize = wingSize;
    }

    public override string ToString() =>
        $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
}

class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

    public override string MakeSound() => "Hoot Hoot";

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.25 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
        {
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

    public override string MakeSound() => "Cluck";

    public override void Eat(Food food)
    {
        Weight += 0.35 * food.Quantity;
        FoodEaten += food.Quantity;
    }
}

abstract class Mammal : Animal
{
    public string LivingRegion { get; protected set; }
    protected Mammal(string name, double weight, string livingRegion)
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public override string ToString() => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
}

abstract class Feline : Mammal
{
    public string Breed { get; protected set; }
    protected Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public override string ToString() =>
        $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
}

class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    public override string MakeSound() => "Squeak";

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Fruit)
        {
            Weight += 0.10 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
    }
}

class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    public override string MakeSound() => "Woof!";

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 0.40 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
    }
}

class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override string MakeSound() => "Meow";

    public override void Eat(Food food)
    {
        if (food is Vegetable || food is Meat)
        {
            Weight += 0.30 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
    }
}

class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    public override string MakeSound() => "ROAR!!!";

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            Weight += 1.0 * food.Quantity;
            FoodEaten += food.Quantity;
        }
        else
            Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        CultureInfo ci = CultureInfo.InvariantCulture;

        while (true)
        {
            string line = Console.ReadLine();
            if (line == "End") break;

            string[] animalInfo = line.Split();
            string animalType = animalInfo[0];

            Animal animal = null;

            if (animalType == "Cat")
                animal = new Cat(animalInfo[1], double.Parse(animalInfo[2], ci), animalInfo[3], animalInfo[4]);
            else if (animalType == "Tiger")
                animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2], ci), animalInfo[3], animalInfo[4]);
            else if (animalType == "Dog")
                animal = new Dog(animalInfo[1], double.Parse(animalInfo[2], ci), animalInfo[3]);
            else if (animalType == "Mouse")
                animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2], ci), animalInfo[3]);
            else if (animalType == "Owl")
                animal = new Owl(animalInfo[1], double.Parse(animalInfo[2], ci), double.Parse(animalInfo[3], ci));
            else if (animalType == "Hen")
                animal = new Hen(animalInfo[1], double.Parse(animalInfo[2], ci), double.Parse(animalInfo[3], ci));

            animals.Add(animal);


            string[] foodInfo = Console.ReadLine().Split();
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            Food food = null;
            if (foodType == "Vegetable")
                food = new Vegetable(quantity);
            else if (foodType == "Fruit")
                food = new Fruit(quantity);
            else if (foodType == "Meat")
                food = new Meat(quantity);
            else if (foodType == "Seeds")
                food = new Seeds(quantity);


            Console.WriteLine(animal.MakeSound());
            if (food != null)
                animal.Eat(food);
        }

        foreach (var a in animals)
            Console.WriteLine(a);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Food
{
    public int Happiness { get; protected set; } 
}

public class Cram : Food { public Cram() { Happiness = 2; } }
public class Lembas : Food { public Lembas() { Happiness = 3; } }
public class Apple : Food { public Apple() { Happiness = 1; } }
public class Melon : Food { public Melon() { Happiness = 1; } }
public class HoneyCake : Food { public HoneyCake() { Happiness = 5; } }
public class Mushrooms : Food { public Mushrooms() { Happiness = -10; } }
public class OtherFood : Food { public OtherFood() { Happiness = -1; } }

public class FoodFactory
{
    public Food CreateFood(string name)
    {
        switch (name.ToLower())
        {
            case "cram": return new Cram();
            case "lembas": return new Lembas();
            case "apple": return new Apple();
            case "melon": return new Melon();
            case "honeycake": return new HoneyCake();
            case "mushrooms": return new Mushrooms();
            default: return new OtherFood();
        }
    }
}

public abstract class Mood
{
    public string Name { get; protected set; }
}

public class Angry : Mood { public Angry() { Name = "Angry"; } }
public class Sad : Mood { public Sad() { Name = "Sad"; } }
public class Happy : Mood { public Happy() { Name = "Happy"; } }
public class JavaScriptBliss : Mood { public JavaScriptBliss() { Name = "JavaScriptBliss"; } }

public class MoodFactory
{
    public Mood CreateMood(int happiness)
    {
        if (happiness < -5) return new Angry();
        if (happiness <= 0) return new Sad();
        if (happiness <= 15) return new Happy();
        return new JavaScriptBliss();
    }
}

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] foods = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        FoodFactory foodFactory = new FoodFactory();
        int totalHappiness = 0;

        foreach (string foodName in foods)
        {
            Food food = foodFactory.CreateFood(foodName);
            totalHappiness += food.Happiness;
        }

        MoodFactory moodFactory = new MoodFactory();
        Mood mood = moodFactory.CreateMood(totalHappiness);

        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.Name);
    }
}

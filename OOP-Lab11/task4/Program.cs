using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public class WeaponTypeAttribute : Attribute
{
    public int MinDamage { get; }
    public int MaxDamage { get; }
    public int SocketCount { get; }

    public WeaponTypeAttribute(int min, int max, int sockets)
    {
        MinDamage = min;
        MaxDamage = max;
        SocketCount = sockets;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class GemStatsAttribute : Attribute
{
    public int Strength { get; }
    public int Agility { get; }
    public int Vitality { get; }

    public GemStatsAttribute(int strength, int agility, int vitality)
    {
        Strength = strength;
        Agility = agility;
        Vitality = vitality;
    }
}

public enum Rarity
{
    Common = 1,
    Uncommon = 2,
    Rare = 3,
    Epic = 5
}

public enum Clarity
{
    Chipped = 1,
    Regular = 2,
    Perfect = 5,
    Flawless = 10
}

public abstract class Gem
{
    public int Strength { get; protected set; }
    public int Agility { get; protected set; }
    public int Vitality { get; protected set; }

    public Gem(Clarity clarity)
    {
        var attr = GetType().GetCustomAttribute<GemStatsAttribute>();
        if (attr != null)
        {
            Strength = attr.Strength + (int)clarity;
            Agility = attr.Agility + (int)clarity;
            Vitality = attr.Vitality + (int)clarity;
        }
    }
}

public abstract class Weapon
{
    public string Name { get; }
    public int BaseMin { get; }
    public int BaseMax { get; }
    public Gem[] Sockets { get; }
    public Rarity Rarity { get; }

    public Weapon(string name, Rarity rarity)
    {
        Name = name;
        Rarity = rarity;

        var attr = GetType().GetCustomAttribute<WeaponTypeAttribute>();
        if (attr != null)
        {
            BaseMin = attr.MinDamage * (int)rarity;
            BaseMax = attr.MaxDamage * (int)rarity;
            Sockets = new Gem[attr.SocketCount];
        }
    }

    public void AddGem(int index, Gem gem)
    {
        if (index >= 0 && index < Sockets.Length)
            Sockets[index] = gem;
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < Sockets.Length)
            Sockets[index] = null;
    }

    public override string ToString()
    {
        int totalStr = 0, totalAgi = 0, totalVit = 0;
        foreach (var gem in Sockets)
        {
            if (gem != null)
            {
                totalStr += gem.Strength;
                totalAgi += gem.Agility;
                totalVit += gem.Vitality;
            }
        }

        int min = BaseMin + totalStr * 2 + totalAgi * 1;
        int max = BaseMax + totalStr * 3 + totalAgi * 4;

        return $"{Name}: {min}-{max} Damage, +{totalStr} Strength, +{totalAgi} Agility, +{totalVit} Vitality";
    }
}

[WeaponType(5, 10, 4)]
public class Axe : Weapon
{
    public Axe(string name, Rarity rarity) : base(name, rarity) { }
}

[WeaponType(4, 6, 3)]
public class Sword : Weapon
{
    public Sword(string name, Rarity rarity) : base(name, rarity) { }
}

[WeaponType(3, 4, 2)]
public class Knife : Weapon
{
    public Knife(string name, Rarity rarity) : base(name, rarity) { }
}

[GemStats(7, 2, 5)]
public class Ruby : Gem
{
    public Ruby(Clarity clarity) : base(clarity) { }
}

[GemStats(1, 4, 9)]
public class Emerald : Gem
{
    public Emerald(Clarity clarity) : base(clarity) { }
}

[GemStats(2, 8, 4)]
public class Amethyst : Gem
{
    public Amethyst(Clarity clarity) : base(clarity) { }
}

class Program
{
    static void Main()
    {
        var weapons = new List<Weapon>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split(';');
            string command = parts[0];

            if (command == "Create")
            {
                string[] typeInfo = parts[1].Split(' ');
                string rarityName = typeInfo[0];
                string weaponType = typeInfo[1];
                string name = parts[2];

                Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), rarityName);

                Type type = Assembly.GetExecutingAssembly().GetType(weaponType);
                var weapon = (Weapon)Activator.CreateInstance(type, name, rarity);
                weapons.Add(weapon);
            }
            else if (command == "Add")
            {
                string name = parts[1];
                int index = int.Parse(parts[2]);
                string[] gemParts = parts[3].Split(' ');
                Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemParts[0]);
                string gemType = gemParts[1];

                Type type = Assembly.GetExecutingAssembly().GetType(gemType);
                Gem gem = (Gem)Activator.CreateInstance(type, clarity);

                weapons.Find(w => w.Name == name).AddGem(index, gem);
            }
            else if (command == "Remove")
            {
                string name = parts[1];
                int index = int.Parse(parts[2]);
                weapons.Find(w => w.Name == name).RemoveGem(index);
            }
            else if (command == "Print")
            {
                string name = parts[1];
                Console.WriteLine(weapons.Find(w => w.Name == name));
            }
        }
    }
}

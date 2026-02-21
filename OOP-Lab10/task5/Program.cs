using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pet
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Kind { get; private set; }

    public Pet(string name, int age, string kind)
    {
        Name = name;
        Age = age;
        Kind = kind;
    }

    public override string ToString()
    {
        return $"{Name} {Age} {Kind}";
    }
}

public class Clinic
{
    private Pet[] rooms;
    private string name;
    private int roomsCount;
    private int centerRoomIndex;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public Clinic(string name, int rooms)
    {
        if (rooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.name = name;
        this.roomsCount = rooms;
        this.rooms = new Pet[rooms];
        this.centerRoomIndex = rooms / 2;
    }

    public bool Add(Pet pet)
    {
        if (pet == null) return false;
        if (!HasEmptyRooms()) return false;

        for (int i = 0; i < roomsCount; i++)
        {
            int offset;
            int magnitude = i / 2;

            if (i % 2 == 0)
            {
                offset = magnitude;
            }
            else
            {
                offset = -magnitude - 1;
            }

            int roomIndex = centerRoomIndex + offset;

            if (roomIndex < 0 || roomIndex >= roomsCount)
            {
                continue;
            }

            if (rooms[roomIndex] == null)
            {
                rooms[roomIndex] = pet;
                return true;
            }
        }
        return false;
    }

    public bool Release()
    {
        int startIndex = centerRoomIndex;

        for (int i = startIndex; i < roomsCount; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < startIndex; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        foreach (Pet p in rooms)
        {
            if (p == null)
            {
                return true; 
            }
        }
        return false;
    }

    public void PrintRoom(int roomNumber)
    {
        int roomIndex = roomNumber - 1;

        if (rooms[roomIndex] != null)
        {
            Console.WriteLine(rooms[roomIndex]);
        }
        else
        {
            Console.WriteLine("Room empty");
        }
    }

    public void PrintAll()
    {
        for (int i = 0; i < roomsCount; i++)
        {
            if (rooms[i] != null)
            {
                Console.WriteLine(rooms[i]);
            }
            else
            {
                Console.WriteLine("Room empty");
            }
        }
    }
}

public class Program
{
    private static List<Pet> pets = new List<Pet>();
    private static List<Clinic> clinics = new List<Clinic>();

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = line[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        HandleCreateCommand(line);
                        break;
                    case "Add":
                        HandleAddCommand(line);
                        break;
                    case "Release":
                        HandleReleaseCommand(line);
                        break;
                    case "HasEmptyRooms":
                        HandleHasEmptyRoomsCommand(line);
                        break;
                    case "Print":
                        HandlePrintCommand(line);
                        break;
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
    private static Pet FindPet(string name)
    {
        foreach (Pet p in pets)
        {
            if (p.Name == name)
            {
                return p;
            }
        }
        return null;
    }

    private static Clinic FindClinic(string name)
    {
        foreach (Clinic c in clinics)
        {
            if (c.Name == name)
            {
                return c;
            }
        }
        return null;
    }

    private static void HandleCreateCommand(string[] line)
    {
        string entityType = line[1];

        if (entityType == "Pet")
        {
            string name = line[2];
            int age = int.Parse(line[3]);
            string kind = line[4];

            if (FindPet(name) == null)
            {
                pets.Add(new Pet(name, age, kind));
            }
        }
        else if (entityType == "Clinic")
        {
            string name = line[2];
            int rooms = int.Parse(line[3]);

            if (FindClinic(name) == null)
            {
                clinics.Add(new Clinic(name, rooms));
            }
        }
    }

    private static void HandleAddCommand(string[] line)
    {
        string petName = line[1];
        string clinicName = line[2];

        Pet pet = FindPet(petName);
        Clinic clinic = FindClinic(clinicName);

        bool result = clinic.Add(pet);
        Console.WriteLine(result);
    }

    private static void HandleReleaseCommand(string[] line)
    {
        string clinicName = line[1];
        Clinic clinic = FindClinic(clinicName);

        bool result = clinic.Release();
        Console.WriteLine(result);
    }

    private static void HandleHasEmptyRoomsCommand(string[] line)
    {
        string clinicName = line[1];
        Clinic clinic = FindClinic(clinicName);

        bool result = clinic.HasEmptyRooms();
        Console.WriteLine(result);
    }

    private static void HandlePrintCommand(string[] line)
    {
        string clinicName = line[1];
        Clinic clinic = FindClinic(clinicName);

        if (line.Length == 2)
        {
            clinic.PrintAll();
        }
        else if (line.Length == 3)
        {
            int roomNumber = int.Parse(line[2]);
            clinic.PrintRoom(roomNumber);
        }
    }
}
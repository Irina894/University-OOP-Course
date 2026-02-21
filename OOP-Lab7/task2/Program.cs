using System;
using System.Collections.Generic;


    interface IIdentifiable
    {
        string Id { get; }
    }

    class Citizen : IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }

        public Citizen(string name, int age, string id)
        {
            Name = name; Age = age; Id = id;
        }
    }

    class Robot : IIdentifiable
    {
        public string Model { get; }
        public string Id { get; }

        public Robot(string model, string id)
        {
            Model = model; Id = id;
        }
    }

    class Program
    {
        static void Main()
        {
            var list = new List<IIdentifiable>();
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                var parts = line.Split();
                if (parts.Length == 3) 
                {
                    list.Add(new Citizen(parts[0], int.Parse(parts[1]), parts[2]));
                }
                else if (parts.Length == 2) 
                {
                    list.Add(new Robot(parts[0], parts[1]));
                }
            }

            string fakeIdEnding = Console.ReadLine();

            foreach (var obj in list)
            {
                if (obj.Id.EndsWith(fakeIdEnding))
                {
                    Console.WriteLine(obj.Id);
                }
            }
        }
    }


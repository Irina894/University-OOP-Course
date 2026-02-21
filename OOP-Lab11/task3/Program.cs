using System;
using System.Collections.Generic;

namespace P03_TrafficLights
{
    public enum Light
    {
        Red,
        Green,
        Yellow
    }

    public class TrafficLight
    {
        public Light CurrentLight { get; private set; }

        public TrafficLight(string color)
        {
            this.CurrentLight = Enum.Parse<Light>(color);
        }

        public void Change()
        {
            if (CurrentLight == Light.Red)
                CurrentLight = Light.Green;
            else if (CurrentLight == Light.Green)
                CurrentLight = Light.Yellow;
            else
                CurrentLight = Light.Red;
        }
    }

    public class Program
    {
        public static void Main()
        {
            string[] colors = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            List<TrafficLight> lights = new List<TrafficLight>();

            foreach (string color in colors)
            {
                lights.Add(new TrafficLight(color));
            }

            for (int i = 0; i < n; i++)
            {
                foreach (TrafficLight light in lights)
                {
                    light.Change();
                }

                Console.WriteLine(string.Join(" ", lights.ConvertAll(l => l.CurrentLight.ToString())));
            }
        }
    }
}

using System;   
public class Box<T>
{
    private T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
    }
    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value.ToString()}";
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int inputInt = int.Parse(Console.ReadLine());
            Box<int> intBox = new Box<int>(inputInt);

            Console.WriteLine(intBox.ToString());
        }
    }
}
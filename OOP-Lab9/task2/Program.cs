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
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            return;
        }

        for (int i = 0; i < n; i++)
        {
            string inputString = Console.ReadLine();

            Box<string> stringBox = new Box<string>(inputString);

            Console.WriteLine(stringBox.ToString());
        }
    }
}
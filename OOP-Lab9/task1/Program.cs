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
        string fullTypeName = this.Value.GetType().FullName;
        string stringValue = this.Value.ToString();

        return $"{fullTypeName}: {stringValue}";
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int intValue = 123123;
        Box<int> intBox = new Box<int>(intValue);

        Console.WriteLine(intBox);
        string stringValue = "life in a box";
        Box<string> stringBox = new Box<string>(stringValue);

        Console.WriteLine(stringBox);
    }
}
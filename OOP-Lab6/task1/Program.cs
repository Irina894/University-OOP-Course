using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private  string title;
    private  string author;
    private decimal price;

    public Book(string title, string author, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }
    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");
            this.title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            var names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 1 && char.IsDigit(names[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");
            this.price = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result
            .AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        return result.ToString().TrimEnd();
    }
}


public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, decimal price)
        : base(title, author, price)
    {
    }
    public override decimal Price
    {
        get { return base.Price * 1.3m; }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            Book book = new Book(title, author, price);
            GoldenEditionBook goldenBook = new GoldenEditionBook(title, author, price);
        Console.WriteLine(book+Environment.NewLine);
            Console.WriteLine(goldenBook);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
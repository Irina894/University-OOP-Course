using System;
using System.Collections.Generic;
using System.Linq;

class ProductInfo
{
    public string Product { get; set; }
    public int Amount { get; set; }
}

class Company
{
    public string Name { get; set; }
    public List<ProductInfo> Products { get; set; } = new List<ProductInfo>();
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Company> companies = new List<Company>();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine().Trim('|');
            string[] parts = line.Split(" - ");

            string companyName = parts[0];
            int amount = int.Parse(parts[1]);
            string product = parts[2];

            Company company = companies
                .FirstOrDefault(c => c.Name == companyName);

            if (company == null)
            {
                company = new Company { Name = companyName };
                companies.Add(company);
            }

            ProductInfo prod = company.Products
                .FirstOrDefault(p => p.Product == product);

            if (prod == null)
            {
                prod = new ProductInfo { Product = product, Amount = 0 };
                company.Products.Add(prod);
            }

            prod.Amount += amount;
        }

        foreach (var company in companies.OrderBy(c => c.Name))
        {
            string productsOutput = string.Join(", ",
                company.Products.Select(p => $"{p.Product}-{p.Amount}")
            );

            Console.WriteLine($"{company.Name}: {productsOutput}");
        }
    }
}

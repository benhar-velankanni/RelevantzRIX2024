// Ex : 4	Product Class - Constructor Overloading & this
// Objective: Understand constructor overloading and the this keyword.
// Instructions:
// Create a Product class with the following constructors:
// Product() (default constructor)
// Product(string name)
// Product(string name, double price)

using System;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    // Default constructor
    public Product()
    {
        Name = "Unknown";
        Price = 0.0;
        Console.WriteLine("\nDefault constructor called!");
    }

    // Constructor with name parameter
    public Product(string name) : this()
    {
        Name = name;
        Console.WriteLine($"\nConstructor with name parameter called: \nName = {name}");
    }

    // Constructor with name and price parameters
    public Product(string name, double price) : this(name)
    {
        Price = price;
        Console.WriteLine($"\nConstructor with name and price parameters called: \nName = {name}, \nPrice = {price}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating Product objects using different constructors
        Product defaultProduct = new Product();
        Product namedProduct = new Product("Laptop");
        Product fullProduct = new Product("Smartphone", 599.99);

        Console.WriteLine($"\nDefault Product - \nName: {defaultProduct.Name}, \nPrice: {defaultProduct.Price}");
        Console.WriteLine($"\nNamed Product - \nName: {namedProduct.Name}, \nPrice: {namedProduct.Price}");
        Console.WriteLine($"\nFull Product - \nName: {fullProduct.Name}, \nPrice: {fullProduct.Price}");
    }
}

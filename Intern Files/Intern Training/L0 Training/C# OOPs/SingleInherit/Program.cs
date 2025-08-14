using System;
 
class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
 
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
 
    public void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}
 
class Dog : Animal
{
    public string Breed { get; set; }
 
    public void DisplayDogDetails()
    {
        DisplayDetails();
        Console.WriteLine($"Breed: {Breed}");
    }
 
    public void Bark()
    {
        Console.WriteLine("Dog barks: Woof! Woof!");
    }
}
 
class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
 
        Console.WriteLine("Enter Dog Details:");
 
        Console.Write("Name: ");
        dog.Name = Console.ReadLine();
 
        Console.Write("Age: ");
        dog.Age = int.Parse(Console.ReadLine());
 
        Console.Write("Breed: ");
        dog.Breed = Console.ReadLine();
 
        dog.DisplayDogDetails();
        dog.MakeSound();
        dog.Bark();
    }
}
// Ex : 6	Animal/Dog Classes - Method Overriding
// Objective: Understand method overriding and access specifiers.
// Instructions:
// Create an Animal class with a virtual MakeSound() method and a protected Sleep() method.
// Create a Dog class that inherits from Animal and overrides the MakeSound() method.
// In Dog's MakeSound(), call the Sleep() method (demonstrating access to a protected method).
// In Main, create Animal and Dog objects and call MakeSound() on both to see polymorphism in action

using System;

public class Animal
{
    // Virtual MakeSound method
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }

    // Protected Sleep method
    protected void Sleep()
    {
        Console.WriteLine("Animal is sleeping");
    }
}

public class Dog : Animal
{
    // Overriding MakeSound method
    public override void MakeSound()
    {
        base.MakeSound(); // Optional: call the base class method
        Console.WriteLine("Dog barks");
        Sleep(); // Call the protected Sleep method
    }
}

public class Program
{
    public static void Main()
    {
        // Create Animal and Dog objects
        Animal genericAnimal = new Animal();
        Dog myDog = new Dog();

        // Call MakeSound method on both objects
        Console.WriteLine("\nCalling MakeSound on generic Animal:");
        genericAnimal.MakeSound();

        Console.WriteLine("\nCalling MakeSound on myDog:");
        myDog.MakeSound();

        Console.WriteLine("\nDemonstration complete.");
    }
}

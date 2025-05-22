abstract class Animal
{
    public abstract void MakeSound();

    public void Eat()
    {
        Console.WriteLine("The animal is eating.");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("The dog barks.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dog myDog = new Dog();
        myDog.MakeSound();
        myDog.Eat();
    }
}   
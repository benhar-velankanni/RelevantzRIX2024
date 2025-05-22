abstract class Animal
{
    //abstract method(does not have a body)
    public abstract void animalSound();
    //regular method
    public void sleep()
    {
        Console.WriteLine("Zzz..............");
    }
}

class Pig : Animal
{
    //override the abstract method
    public override void animalSound()
    {
        //The body of animalSound() is provided here
        Console.WriteLine("The pig says: wee wee");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pig myPig = new Pig(); //create a Pig object
        myPig.animalSound(); //call the animalSound() on myPig object
        myPig.sleep(); //call the sleep() on myPig object
    }
}
//4	Write a C# program to create a Animal interface with a method called bark()
//that takes no arguments and returns void.
//Create a Dog class that implements Animal and overrides speak() to print "Dog is barking".

class Program
{
    public static void Main()
    {
        Dog dog= new Dog();
        dog.Bark();
    }
}
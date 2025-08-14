// 1	Write a C# program to create an abstract class Animal with an abstract method called sound(). 
//Create subclasses Lion and Tiger that extend the Animal class and implement the sound() method to 
//make a specific sound for each animal.

class Program
{
    public static void Main()
    {
        Lion lion = new Lion();
        Tiger tiger = new Tiger();

        lion.Sound();
        tiger.Sound();
    }
}
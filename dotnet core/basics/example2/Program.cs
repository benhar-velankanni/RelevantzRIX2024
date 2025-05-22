using System;

class TrafficLightSystem
{
    static void Main()
    {
        Console.Write("Enter light color (Red, Yellow, Green): ");
        string lightColor = Console.ReadLine();

        switch (lightColor)
        {
            case "Red":
                Console.WriteLine("Stop");
                break;
            case "Yellow":
                Console.WriteLine("Ready");
                break;
            case "Green":
                Console.WriteLine("Go");
                break;
            default:
                Console.WriteLine("Invalid light color");
                break;
        }
    }
}
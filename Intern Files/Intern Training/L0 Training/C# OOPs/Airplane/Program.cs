//Ex: 3	Write a C# program to create a class called "Airplane" with a flight number, destination, and departure time attributes, and methods to check flight status and delay.

using System;

class Airplane
{
    public string FlightNumber { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }

    public Airplane(string flightNumber, string destination, TimeSpan departureTime)
    {
        FlightNumber = flightNumber;
        Destination = destination;
        DepartureTime = DateTime.Today.Add(departureTime); // Set today's date with given time
    }

    public void CheckStatus()
    {
        Console.WriteLine($"\nFlight {FlightNumber} to {Destination} departs at {DepartureTime:hh:mm}");
    }

    public void ApplyDelay(TimeSpan newDepartureTime)
    {
        DateTime newTime = DateTime.Today.Add(newDepartureTime);
        int delayMinutes = (int)(newTime - DepartureTime).TotalMinutes;

        if (delayMinutes > 0)
        {
            DepartureTime = newTime;
            Console.WriteLine($"Flight {FlightNumber} delayed by {delayMinutes} minutes.");
        }
        else
        {
            Console.WriteLine("No delay applied. New time is earlier or the same.");
        }
    }

    static void Main()
    {
        List<Airplane> airplaneList = new List<Airplane>();

    start:
        Console.WriteLine("\nFlight Management System: ");
        Console.WriteLine("============================");
        Console.WriteLine("1.Enter Flight Details.");
        Console.WriteLine("2.Check Status.");
        Console.WriteLine("3.Add new delay.");
        Console.WriteLine("0.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 0:
                {
                    Console.WriteLine("\n======================");
                    Console.WriteLine("Logging Out...");
                    Console.WriteLine("======================");
                    return;
                }

            case 1:
                {
                    // Get user input
                    Console.WriteLine("\nEnter Flight Number: ");
                    string flightNumber = Console.ReadLine();

                    Console.WriteLine("Enter Destination: ");
                    string destination = Console.ReadLine();

                    Console.WriteLine("Enter Original Departure Time (HH:mm): ");
                    TimeSpan originalTime = TimeSpan.Parse(Console.ReadLine());

                    // Create Airplane object
                    Airplane flight = new Airplane(flightNumber, destination, originalTime);
                    airplaneList.Add(flight);

                    goto start;
                }

            case 2:
                {
                    // Show flight details
                    Console.WriteLine("\nEnter the flight number to check status for: ");
                    string target = Console.ReadLine();
                    Airplane flight = airplaneList.Find(x => x.FlightNumber == target);
                    flight.CheckStatus();
                    goto start;
                }

            case 3:
                {

                    Console.WriteLine("\nEnter the flight number to add a delay: ");
                    string target = Console.ReadLine();
                    Airplane flight = airplaneList.Find(x => x.FlightNumber == target);

                    // Get new delayed departure time from the user
                    Console.Write("\nEnter New Delayed Departure Time (HH:mm): ");
                    TimeSpan newTime = TimeSpan.Parse(Console.ReadLine());

                    // Apply delay
                    flight.ApplyDelay(newTime);

                    goto start;
                }

            default:
                {
                    Console.WriteLine("\nInvalid Choice!! Try Again!!");
                    goto start;
                }
        }
    }
}

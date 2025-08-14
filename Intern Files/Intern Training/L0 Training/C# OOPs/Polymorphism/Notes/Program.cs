// Ex : 3	NoteTaker Class - Method Overloading
// Objective: Practice method overloading in a real-world scenario.
// Instructions:
// Create a NoteTaker class with overloaded AddNote methods:
// AddNote(string note)
// AddNote(string subject, string note)
// AddNote(string subject, string note, DateTime date)

using System;

public class NoteTaker
{
    // Overloaded AddNote methods
    public void AddNote(string note)
    {
        Console.WriteLine($"\nNote added: \n{note}");
    }

    public void AddNote(string subject, string note)
    {
        Console.WriteLine($"\nNote added: \nSubject: {subject}, \nNote: {note}");
    }

    public void AddNote(string subject, string note, DateTime date)
    {
        Console.WriteLine($"\nNote added: \nSubject: {subject}, \nNote: {note}, \nDate: {date.ToString("yyyy-MM-dd")}");
    }
}

public class Program
{
    public static void Main()
    {
        NoteTaker myNoteTaker = new NoteTaker();

        // Calling AddNote methods
        myNoteTaker.AddNote("This is a simple note.");
        myNoteTaker.AddNote("Meeting", "Discuss project status.");
        myNoteTaker.AddNote("Appointment", "Doctor's visit", DateTime.Now);

        Console.WriteLine("\nAll methods have been called.");
    }
}


//Ex: 1	Write a C# program to create a class called "Student" with a name, grade, and courses attributes, and methods to add and remove courses.

using System.Security.Cryptography.X509Certificates;

class School
{
    public static void Main()
    {
        List<Student> students = new List<Student>();
        InsertRecords insertRecords = new InsertRecords();
        DisplayRecords displayRecords = new DisplayRecords();
        DeleteRecords deleteRecords = new DeleteRecords();

    checkpoint1:
        Console.WriteLine("\nStudent Record System:");
        Console.WriteLine("1.Insert Records.");
        Console.WriteLine("2.Delete Records.");
        Console.WriteLine("3.Display Records");
        Console.WriteLine("0.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice1 = Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
                {
                    insertRecords.Insertions(students);
                    goto checkpoint1;
                }

            case 2:
                {
                    deleteRecords.deletions(students);
                    goto checkpoint1;
                }

            case 3:
                {

                    displayRecords.dispayRecords(students);
                    goto checkpoint1;
                }

            case 0:
                {
                    Console.WriteLine("\n======================");
                    Console.WriteLine("Logging Out...");
                    Console.WriteLine("======================");
                    return;
                }

            default:
                {
                    Console.WriteLine("\nInvalid Choice!! Try Again!!");
                    goto checkpoint1;
                }

        }
    }
}
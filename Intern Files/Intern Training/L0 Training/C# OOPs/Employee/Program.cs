using System.Security.Cryptography.X509Certificates;

class Company
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>();
        InsertRecords insertRecords= new InsertRecords();
        DisplayRecords displayRecords= new DisplayRecords();

    checkpoint1:
        Console.WriteLine("\nEmployee Record System:");
        Console.WriteLine("1.Insert Records.");
        Console.WriteLine("2.Display Records");
        Console.WriteLine("3.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice1 = Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
                {
                    insertRecords.Insertions(employees);
                    goto checkpoint1;
                }

            case 2:
                {

                    displayRecords.dispayRecords(employees);
                    goto checkpoint1;
                }

            case 3:
                {
                    Console.WriteLine("Logging Out...");
                    return;
                }

            default:
                {
                    Console.WriteLine("Invalid Choice!! Try Again!!");
                    goto checkpoint1;
                }

        }
    }
}
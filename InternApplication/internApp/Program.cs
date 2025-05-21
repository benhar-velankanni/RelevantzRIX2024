using internApp;
using MySql.Data.MySqlClient.Interceptors;

class Program
{
    public static void Main(string[] args)
    {
        InternApp internApp = new InternApp();
        while (true)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine(">>>>>>>>> Intern Application <<<<<<<<<<<<<");
            Console.WriteLine("Enter Options : ");
            Console.WriteLine("1. Add Intern");
            Console.WriteLine("2. Update Intern");
            Console.WriteLine("3. Delete Intern");
            Console.WriteLine("4. Search Intern");
            Console.WriteLine("5. Show All Intern");
            Console.WriteLine("5. Exit");
            Console.WriteLine("=============================================");
            Console.WriteLine("Enter Option : ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=============================================");
            switch (option)
            {
                case 1:
                    internApp.addIntern();
                    break;
                case 2:
                    internApp.updateIntern();
                    break;
                case 3:
                    internApp.deleteIntern();
                    break;
                case 4:
                    internApp.searchIntern();
                    break;
                case 5:
                    internApp.showAllIntern();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}


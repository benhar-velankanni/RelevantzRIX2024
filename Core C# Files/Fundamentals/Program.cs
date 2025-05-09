

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=========================================== \nMAIN MENU \n===========================================\n1. Greet Based on Time \n2. Student Grading System \n3. Traffic Light System \n4. Discount Calculator \n5. ATM Withdrawal \n6. Leap Year Checker \n7. Patterns \n8. Duplicate Finder \n0. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Greet.Program.Run();
                        break;
                    case 2:
                        StudentGradingSystem.Program.Run();
                        break;
                    case 3:
                        TrafficLightSystem.Program.Run();
                        break;
                    case 4:
                        Discount.Program.Run();
                        break;
                    case 5:
                        ATM.Program.Run();
                        break;
                    case 6:
                        LeapYearChecker.Program.Run();
                        break;
                    case 7:
                        Patterns.Program.Run();
                        break;
                    case 8:
                        DuplicateFinder.Program.Run();
                        break;
                    case 0:
                        Console.WriteLine("Exiting program...\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.\n");
                        break;
                }
            }
        }
    }
}

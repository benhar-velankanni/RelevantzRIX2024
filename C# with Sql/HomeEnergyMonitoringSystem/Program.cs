using System;
using HomeEnergyMonitoringSystem;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Home Energy Monitoring System");
            Console.WriteLine("1. Add Energy Details");
            Console.WriteLine("2. Search Energy Details");
            Console.WriteLine("3. Update Energy Details");
            Console.WriteLine("4. Delete Energy Details");
            Console.WriteLine("5. View All Energy Details");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===================================================================================");
            switch (choice)
            {
                case 1:
                    HomeEnergy.AddData();
                    break;
                case 5:
                    HomeEnergy.DisplayAllData();
                    break;
                case 4:
                    HomeEnergy.DeleteData();
                    break;
                case 3:
                    HomeEnergy.UpdateData();
                    break;
                case 2:
                    HomeEnergy.SearchData();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

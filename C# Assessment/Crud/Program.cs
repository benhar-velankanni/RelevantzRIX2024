using System;
namespace Crud
{
    class Operation
    {
        public static void Main(string[] args)
        {
             while (true) {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("DIGITAL BILL SPLITTER FOR GROUPS");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("1.Add Bill");
            Console.WriteLine("2.View Bills");
            Console.WriteLine("3.Update Bill");
            Console.WriteLine("4.Delete Bill");
            Console.WriteLine("5.Search Bill");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine());
          
            switch (choice)
            {

                case 1:
                    Crud.Program.AddBill();
                    break;
                case 2:
                    Crud.Program.ViewAllBills();
                    break;
                case 3:
                    Crud.Program.UpdateBill();
                    break;
                case 4:
                    Crud.Program.DeleteBill();
                    break;
                case 5:
                    Crud.Program.SearchBill();
                    break;
                case 6:
                    Console.WriteLine("Exiting BILL_SPLITTER App");
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            }
        }
    }
}
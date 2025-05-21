namespace DigiReceiptApp
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("\n====================================================\nWELCOME TO OUR APPLICATION.\n====================================================");

            //SQL INSIDE WSL:
            string connectionString = "Server=localhost;User=root;Password=Reset@123;Database=RELEVANTZ;Port=3306;";

            IDigiReceiptService digiReceiptService = new DigiReceiptService(connectionString);
            DigiReceiptUI digiReceiptUI = new DigiReceiptUI(digiReceiptService);

            while (true)
            {
                Console.WriteLine("\n====================================================\nMENU:\n====================================================");
                Console.WriteLine("1. ADD RECEIPT.");
                Console.WriteLine("2. GET RECEIPT BY ID.");
                Console.WriteLine("3. GET ALL RECEIPTS.");
                Console.WriteLine("4. UPDATE RECEIPT.");
                Console.WriteLine("5. DELETE RECEIPT.");
                Console.WriteLine("6. TRUNCATE RECEIPTS.");
                Console.WriteLine("0. EXIT.");
                Console.WriteLine("====================================================");
                Console.WriteLine("ENTER YOUR CHOICE:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DigiReceiptUI.AddReceiptUI();
                            break;
                        case 2:
                            DigiReceiptUI.GetReceiptByIdUI();
                            break;
                        case 3:
                            DigiReceiptUI.GetAllReceiptsUI();
                            break;
                        case 4:
                            DigiReceiptUI.UpdateDigiReceiptUI();
                            break;
                        case 5:
                            DigiReceiptUI.DeleteDigiReceiptUI();
                            break;
                        case 6:
                            DigiReceiptUI.TruncateDigiReceiptUI();
                            break;
                        case 0:
                            Console.WriteLine("\n====================================================\nTHANK YOU FOR USING OUR APPLICATION.\n====================================================");
                            return;
                        default:
                            Console.WriteLine("\n====================================================\nINVALID CHOICE. PLEASE TRY AGAIN.\n====================================================");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n====================================================\nINVALID INPUT. PLEASE TRY AGAIN.\n====================================================");
                }
            }
        }
    }
}
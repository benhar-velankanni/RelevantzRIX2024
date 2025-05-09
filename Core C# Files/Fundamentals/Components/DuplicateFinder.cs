namespace DuplicateFinder
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nDUPLICATE FINDER \n===========================================\n1. Find duplicates \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter elements of the array separated by spaces: ");
                        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                        Console.WriteLine("Duplicate elements are: ");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = i + 1; j < arr.Length; j++)
                            {
                                if (arr[i] == arr[j])
                                {
                                    Console.WriteLine(arr[i]);
                                }
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting Duplicate Finder...\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}


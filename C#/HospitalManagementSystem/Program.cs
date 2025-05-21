public class Tasks
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter Task Number: 1)Add 2)Display 3)Search 4)Update 5)Delete 6)Exit");
            int task = int.Parse(Console.ReadLine());
            switch (task)
            {
                case 1:
                    HospitalInfo.adddetails();
                    break;
                case 2:
                    HospitalInfo.DisplayDetails();
                    break;
                case 3:
                    HospitalInfo.SearchId(null);
                    break;
                case 4:
                    HospitalInfo.UpdateDetails();
                    break;
                case 5:
                    HospitalInfo.DeleteDetails();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid Task Number");
                    break;
            }
        }
    }
}
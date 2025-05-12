namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] studentMarks = { };
            int index = 0;

            while (true)
            {
                Console.WriteLine("\n===========================================\nMenu: \n===========================================");
                Console.WriteLine("1. Insert marks for a student.");
                Console.WriteLine("2. Delete marks for a student.");
                Console.WriteLine("3. Display marks for a student.");
                Console.WriteLine("4. Calculate average marks for a student.");
                Console.WriteLine("0. Exit.");
                Console.WriteLine("===========================================");
                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        InsertMarks(ref studentMarks, ref index);
                        break;
                    case 2:
                        DeleteMarks(ref studentMarks, ref index);
                        break;
                    case 3:
                        DisplayMarks(studentMarks);
                        break;
                    case 4:
                        CalculateAverageMarks(studentMarks);
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option, please try again.");
                        break;
                }
            }
        }

        static void InsertMarks(ref int[][] studentMarks, ref int index)
        {
            Console.Write("\n===========================================\nEnter number of marks for the student: ");
            int numMarks = Convert.ToInt32(Console.ReadLine());

            int[] marks = new int[numMarks];

            for (int i = 0; i < numMarks; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Resize(ref studentMarks, studentMarks.Length + 1);
            studentMarks[index] = marks;
            index++;

            Console.WriteLine("\nMarks inserted successfully. \n===========================================");
        }

        static void DeleteMarks(ref int[][] studentMarks, ref int index)
        {
            Console.Write("\n===========================================\nEnter the student number: ");
            int studentNum = Convert.ToInt32(Console.ReadLine());

            if (studentNum > studentMarks.Length)
            {
                Console.WriteLine("\nInvalid student number or No records found. Please try again. \n===========================================");
                return;
            }

            Array.Resize(ref studentMarks, studentMarks.Length - 1);
            index--;
            Console.WriteLine("\nMarks deleted successfully. \n===========================================");
        }

        static void DisplayMarks(int[][] studentMarks)
        {
            Console.Write("\n===========================================\nEnter the student number: ");
            int studentNum = Convert.ToInt32(Console.ReadLine());

            if (studentNum > studentMarks.Length)
            {
                Console.WriteLine("\nInvalid student number or No records found. Please try again. \n===========================================");
                return;
            }

            Console.WriteLine("\nMarks for student " + studentNum + ":");
            foreach (int mark in studentMarks[studentNum - 1])
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine("\n===========================================");
        }

        static void CalculateAverageMarks(int[][] studentMarks)
        {
            Console.Write("\n===========================================\nEnter the student number: ");
            int studentNum = Convert.ToInt32(Console.ReadLine());

            double sum = 0;

            foreach (int mark in studentMarks[studentNum - 1])
            {
                sum += mark;
            }

            double average = sum / studentMarks[studentNum - 1].Length;

            Console.WriteLine($"\nStudent {studentNum} average marks: {average:F2}. \n===========================================");
        }
    }
}
public class InsertRecords{
    public void Insertions(List<Student> students){
        Console.WriteLine("\nEnter the number of students: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the Students: ");
        Console.WriteLine("====================================");
        for (int i = 0; i < n; i++)
        {
            Student student = new Student();

            Console.Write("\nName: ");
            student.Name = Console.ReadLine();

            Console.Write("Major: ");
            student.Major = Console.ReadLine();

            Console.Write("GPA: ");
            student.GPA = double.Parse(Console.ReadLine());

            students.Add(student);
        }
    }
}
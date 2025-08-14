public class DisplayRecords{
    public void dispayRecords(List<Student> students){
        Console.WriteLine("\n======================");
        Console.WriteLine("The Student Record: ");
        Console.WriteLine("======================");

        foreach (Student student in students)
        {
            Console.WriteLine($"\nName: {student.Name} \nMajor: ${student.Major} \nGPA: {student.GPA}");
        }
    }
}
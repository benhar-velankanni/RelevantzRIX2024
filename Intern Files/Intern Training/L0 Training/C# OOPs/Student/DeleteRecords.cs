public class DeleteRecords
{
    public void deletions(List<Student> students)
    {
        Console.WriteLine("\nEnter the name of the student to delete: ");
        string target = Console.ReadLine();

        Student studentToRemove = students.Find(x => x.Name == target);

        if (studentToRemove != null){
            students.Remove(studentToRemove);
            Console.WriteLine("\nStudent Record Deleted Sussessfully!");
        }
        else{
            Console.WriteLine("\nThe student you are searching for, does not exist!");
        }
    }
}
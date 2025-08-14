public class DeleteRecords
{
    public void deletions(List<Book> books)
    {
        Console.WriteLine("\nEnter the name of the student to delete: ");
        string target = Console.ReadLine();

        Book bookToRemove = books.Find(x => x.Name == target);

        if (bookToRemove != null){
            books.Remove(bookToRemove);
            Console.WriteLine("\nBook Record Deleted Sussessfully!");
        }
        else{
            Console.WriteLine("\nThe book you are searching for, does not exist!");
        }
    }
}
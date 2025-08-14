public class DeleteRecords
{
    public void deletions(List<Movie> movies)
    {
        Console.WriteLine("\nEnter the name of the movie to delete: ");
        string target = Console.ReadLine();

        Movie movieToRemove = movies.Find(x => x.Title == target);

        if (movieToRemove != null){
            movies.Remove(movieToRemove);
            Console.WriteLine("\nMovie Record Deleted Sussessfully!");
        }
        else{
            Console.WriteLine("\nThe movie you are searching for, does not exist!");
        }
    }
}
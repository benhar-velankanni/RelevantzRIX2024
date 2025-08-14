class InsertReviews
{
    public void insertReview(List<Movie> movies)
    {
        Console.WriteLine("\nEnter the name of the movie to add a review: ");
        string target = Console.ReadLine();

        Movie movieToFind = movies.Find(x => x.Title == target);

        if (movieToFind != null)
        {
            Console.WriteLine("\nEnter your review: ");
            movieToFind.Reviews.Add(Console.ReadLine());
            Console.WriteLine("\nMovie Record Deleted Sussessfully!");
        }
        else
        {
            Console.WriteLine("\nThe movie you are searching for, does not exist!");
        }
    }
}
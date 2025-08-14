class DeleteReviews
{
    public void deleteReview(List<Movie> movies)
    {
        Console.WriteLine("\nEnter the name of the movie to delete a review: ");
        string target = Console.ReadLine();

        Movie movieToFind = movies.Find(x => x.Title == target);

        if (movieToFind != null)
        {
            Console.WriteLine("\nReviews available for deletion: ");
            int i = 1;
            foreach (string review in movieToFind.Reviews)
            {
                Console.WriteLine(i + ". " + review);
                i++;
            }

            Console.WriteLine("\nEnter the name of the movie to delete a review: ");
            int targetReview = int.Parse(Console.ReadLine());

            movieToFind.Reviews.Remove(movieToFind.Reviews[targetReview-1]);


            Console.WriteLine("\nMovie Review Deleted Sussessfully!");
        }
        else
        {
            Console.WriteLine("\nThe movie you are searching for, does not exist!");
        }
    }
}
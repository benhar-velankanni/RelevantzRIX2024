public class DisplayRecords
{
    public void dispayRecords(List<Movie> movies)
    {
        Console.WriteLine("\n======================");
        Console.WriteLine("The Movie Catalog: ");
        Console.WriteLine("======================");

        foreach (Movie movie in movies)
        {
            Console.WriteLine($"\nTitle: {movie.Title} \nDirector: {movie.Director}");

            int i = 1;
            Console.WriteLine("Actors: ");
            foreach (string actor in movie.Actors)
            {
                Console.WriteLine(i + ". " + actor);
                i++;
            }

            i = 1;
            Console.WriteLine("Reviews: ");
            foreach (string review in movie.Reviews)
            {
                Console.WriteLine(i + ". " + review);
                i++;
            }


            Console.WriteLine("======================");
        }
    }
}
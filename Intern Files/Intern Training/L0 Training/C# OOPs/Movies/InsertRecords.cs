public class InsertRecords
{
    public void Insertions(List<Movie> movies)
    {
        Console.WriteLine("\nEnter the number of movies: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the movies: ");
        Console.WriteLine("====================================");
        for (int i = 0; i < n; i++)
        {
            Console.Write("\nTitle: ");
            string title = Console.ReadLine();

            Console.Write("Director: ");
            string dir = Console.ReadLine();

            Console.Write("Enter the number of actors: ");
            int n1 = int.Parse(Console.ReadLine());

            List<string> actorlist = new List<string>();

            Console.Write("Enter the details of actors: ");
            for (int j = 0; j < n1; j++)
            {
                actorlist.Add(Console.ReadLine());
            }

            Console.Write("Enter the number of reviews: ");
            int n2 = int.Parse(Console.ReadLine());

            List<string> reviewlist = new List<string>();

            Console.Write("Enter the reviews: ");
            for (int j = 0; j < n1; j++)
            {
                reviewlist.Add(Console.ReadLine());
            }

            Console.WriteLine("====================================");

            Movie movie = new Movie(title, dir, actorlist, reviewlist);
            movies.Add(movie);
        }
    }
}
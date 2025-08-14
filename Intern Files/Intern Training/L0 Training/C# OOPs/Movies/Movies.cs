public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public List<string> Actors  { get; set; }
    public List<string> Reviews { get; set; }

    public Movie(string title, string dir, List<string> actors, List<string> reviews)
    {
        Title = title;
        Director = dir;
        Actors = actors;
        Reviews = reviews;
    }
}
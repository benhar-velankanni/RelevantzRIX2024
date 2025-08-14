class Podcast : Media
{
    public override void PlayMedia()
    {
        Console.WriteLine("\nPlaying Podcast...");
    }

    public override void PauseMedia()
    {
        Console.WriteLine("Pausing Podcast...");
    }

    public override void StopMedia()
    {
        Console.WriteLine("Stopping Podcast...");
    }
}
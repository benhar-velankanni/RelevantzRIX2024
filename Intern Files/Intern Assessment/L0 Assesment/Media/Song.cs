class Song : Media
{
    public override void PlayMedia()
    {
        Console.WriteLine("\nPlaying Song...");
    }

    public override void PauseMedia()
    {
        Console.WriteLine("Pausing Song...");
    }

    public override void StopMedia()
    {
        Console.WriteLine("Stopping Song...");
    }
}
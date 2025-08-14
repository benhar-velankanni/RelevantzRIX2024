class Movie : Media
{
    public override void PlayMedia()
    {
        Console.WriteLine("\nPlaying Movie...");
    }

    public override void PauseMedia()
    {
        Console.WriteLine("Pausing Movie...");
    }

    public override void StopMedia()
    {
        Console.WriteLine("Stopping Movie...");
    }
}
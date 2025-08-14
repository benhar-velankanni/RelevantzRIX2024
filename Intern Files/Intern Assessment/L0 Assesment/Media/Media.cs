abstract class Media
{
    public abstract void PlayMedia();
    public abstract void StopMedia();
    public abstract void PauseMedia();

    public void IncreaseVolume()
    {
        Console.WriteLine("\nIncreasing Volume...");
    }

    public void DecreaseVolume()
    {
        Console.WriteLine("Decreasing Volume...");
    }

}
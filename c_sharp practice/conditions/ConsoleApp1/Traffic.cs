public class Traffic
{
    public void CalTraffic()
    {
        Console.WriteLine("Enter the color");
        string col=Console.ReadLine();
      
        switch(col)
        {
            case "red":
            {
                Console.WriteLine($"{col} -> Stop");
                break;
            }
            case "yellow":
            {
                Console.WriteLine($"{col} -> Stop");
                break ;
            }
            case "green":
            {
                Console.WriteLine($"{col} -> Go");
                break;
            }
        }
    }
}
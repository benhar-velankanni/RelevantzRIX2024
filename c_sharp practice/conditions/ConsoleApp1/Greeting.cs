public class Greeting
{
    public void greet()
    {
        Console.WriteLine("Enter the time");
        int hour=Convert.ToInt32(Console.ReadLine());
        if(hour>=0 && hour<=11)
        {
            Console.WriteLine("Good Morning");
        }
        else if(hour>=12 && hour<=17)
        {
            Console.WriteLine("Good Afternoon");
        }
        else if(hour>=18 && hour<=23)
        {
            Console.WriteLine("Good Evening");
        }
    }

}

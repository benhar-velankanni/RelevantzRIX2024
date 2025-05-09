public class Leap

{
    public void lyear()
    {
        Console.WriteLine("Enter a year");
        int y=Convert.ToInt32(Console.ReadLine());
        if(y%4 ==0  && y%100 != 0)
        {
            Console.WriteLine($"{y} is a Leap Year");
        }
        else  if(y%400 == 0 )
        {
            Console.WriteLine($"{y} is a Leap Year");

        }  
        else
        {
            Console.WriteLine($"{y} is not a leap year");
        }


    }
    
}
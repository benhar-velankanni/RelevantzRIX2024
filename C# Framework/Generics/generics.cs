public class Mygenerics<T>
 
 
{
    private T a;
    private T b;
 
    public Mygenerics(T x, T y)
    {
        this.a = x;
        this.b = y;
    }
    public bool Compare()
    {
        if (a.Equals(b))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
}
class Program
{
    public static void Main(string[] args)
    {
        Mygenerics<string> mygenerics= new Mygenerics<string>("Vicky","Vicky");
        Mygenerics<int> mygenerics1= new Mygenerics<int>(1,1);
 
       
        Console.WriteLine("Whether the two names are same?  "+  mygenerics.Compare());
        Console.WriteLine("Whether the two numbers are same?  "+ mygenerics1.Compare());
    }
}
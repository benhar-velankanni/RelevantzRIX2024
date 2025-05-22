public class Tasks{
    public delegate int MyDelegate(int x,int y);
    public static int Addition(int x,int y){
        return x+y;
    }
    public static int Subtraction(int x,int y){
        return x-y;
    }
    public static int Multiplication(int x,int y){
        return x*y;
    }
    public static int Division(int x,int y){
        return x/y;
    }
    public static void Main(){
        MyDelegate del=new MyDelegate(Addition);
        Console.WriteLine("Addition is "+del(5,5));
        del=new MyDelegate(Subtraction);
        Console.WriteLine("Subtraction is "+del(5,5));
        del=new MyDelegate(Multiplication);
        Console.WriteLine("Multiplication is "+del(5,5));
        del=new MyDelegate(Division);
        Console.WriteLine("Division is "+del(5,5)); 
    }
   
}
 
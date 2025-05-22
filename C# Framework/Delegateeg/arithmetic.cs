public class Task{
    public delegate void MyDelegate(int x,int y);
    public static void Addition(int x,int y){
        Console.WriteLine(x+y);
    }
    public static void Subtraction(int x,int y){
        Console.WriteLine(x-y);
    }
    public static void Multiplication(int x,int y){
        Console.WriteLine(x*y);
    }
    public static void Division(int x,int y){
        Console.WriteLine(x/y);
    }
    public static void Main(){
        MyDelegate del = new MyDelegate(Addition);
        del(10,20);
        del+=Subtraction;
        del(10,20);
        del+=Subtraction;
        del(10,20);
        del+=Division;
        del(10,20);
        del-=Multiplication;
        del(10,20);
    }
}
 
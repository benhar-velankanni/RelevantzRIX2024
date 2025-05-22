using System;
 
public class Task
{
    public void Function1()
    {
        Console.WriteLine("Function 1");
    }
 
    private void function2()
    {
        Console.WriteLine("Function 2");
    }
 
    protected void function3()
    {
        Console.WriteLine("Function 3");
    }
 
    internal void function4()
    {
        Console.WriteLine("Function 4");
    }
 
    protected internal void function5()
    {
        Console.WriteLine("Function 5");
    }
}
 
public class prot:Task{
    public void inheritance()
    {
        Function1();
        // function2();// This line will cause a compile error due to private access
        function3();
        function4();
        function5();
    }
}
 
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        Task task = new Task();
        task.Function1();
        // task.function2(); // This line will cause a compile error due to private access
        // task.function3(); // This line will cause a compile error due to protected access
        task.function4();
        task.function5();
    }
}
 
 
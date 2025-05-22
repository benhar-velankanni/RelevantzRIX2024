class Program{
    static int calculatesum(int a,int b)
    {
        return a+b;
    }
    //define a delegate
    public delegate int MyDelegate(int x,int y);
    static void Main(string[] args)
    {
        //create an instance of the delegate by passing method name
        MyDelegate del = new MyDelegate(calculatesum);
        //calling calculating sum using delegate
        int result = del(10,20);
        Console.WriteLine("The result is {0}",result);
    }
}
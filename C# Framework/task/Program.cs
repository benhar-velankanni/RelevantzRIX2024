using System;
class Program
{
    static void Main(string[] args)
    {
        Grade g=new Grade();
        g.Gradescal();
        Console.WriteLine("------------------");
        Traffic traffic= new Traffic();
        traffic.CalTraffic();
        Console.WriteLine("------------------");
        Greeting gr=new Greeting();
        gr.greet();
        Console.WriteLine("------------------");
        Leap l=new Leap();
        l.lyear();
        Console.WriteLine("------------------");
        ATM a=new ATM();
        a.withdraw();
        Console.WriteLine("------------------");
        Shopping shopping =new Shopping();  
        shopping.Buy();
        Console.WriteLine("------------------");
        Reverse r=new Reverse();
        r.revDigit();
        Console.WriteLine("------------------");

        Pattern p=new Pattern();    
        p.pattern();
        Console.WriteLine("------------------");
        Diamond d1=new Diamond();
        d1.pattern(7);
        Console.WriteLine("------------------");
        Duplicate d=new Duplicate();
        d.duplicate();
    }
}  
 
 
 
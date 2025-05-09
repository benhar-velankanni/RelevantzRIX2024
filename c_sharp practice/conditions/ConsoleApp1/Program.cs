using System;
class Program
{
    static void Main(string[] args)
    {
        Grade g=new Grade();
        g.Gradescal();
        Traffic traffic= new Traffic();
        traffic.CalTraffic();
        Greeting gr=new Greeting();
        gr.greet();
        Leap l=new Leap();
        l.lyear();
        ATM a=new ATM();
        a.withdraw();
        Shopping shopping=new Shopping();   
        shopping.calculateDiscount();
        Reverse r=new Reverse();
        r.revDigit();

        Pattern p=new Pattern();    
        p.pattern();
        p.duplicate();
    }
}   


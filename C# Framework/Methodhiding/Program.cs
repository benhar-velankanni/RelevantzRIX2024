using System;
using Methodhidingdemo;
namespace Methodhidingdemo{
    class GroupAgent{
        public virtual void Getdata(){
            Console.WriteLine("Enter your id");
        }
    }

    class Busagent:GroupAgent{
        public override void Getdata(){
            //new is the keword used to hide the base class method,new is similar to instance of a creating an object of a class
            //we can also use override instad of new
            Console.WriteLine("Booking created !!!");
        }
    }

       
}
class Program{
    static void Main(string[] args) {
        GroupAgent ga = new GroupAgent();
        ga.Getdata();
        Busagent ba = new Busagent();
        ba.Getdata();
        GroupAgent ga1 = new Busagent();
        ga1.Getdata();

    }

}
using Methodhidingdemo;
namespace Methodhidingdemo
{
    class GroupAgent
    {
        public virtual void Getdata()
        {
            Console.WriteLine("Getting Data.");
        }
    }

    class Busagent : GroupAgent
    {
        public override void Getdata()
        {
            //new is the keword used to hide the base class method,new is similar to instance of a creating an object of a class
            //we can also use override instad of new
            Console.WriteLine("Booking created !!!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GroupAgent groupAgent = new GroupAgent();
        groupAgent.Getdata();
        Busagent ba = new Busagent();
        ba.Getdata();
        GroupAgent groupAgent1 = new Busagent();
        groupAgent1.Getdata();
    }
}
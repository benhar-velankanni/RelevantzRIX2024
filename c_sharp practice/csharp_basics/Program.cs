using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int myInt=8;
        double myDouble=myInt;
        double myDouble2=8.9999;
        int int2=(int)myDouble2;
        Console.WriteLine(int2);
        Console.WriteLine(myDouble);
        bool myBool=true;
        Console.WriteLine(Convert.ToString(myBool));

      Console.WriteLine("The value 99999 in various formats");
      Console.WriteLine("c format:{0:c}",999999);
      Console.WriteLine("d9 format:{0:d9}",99999);
      Console.WriteLine("f3 format:{0:f3}",999);
      Console.WriteLine("n format :{0:n}",0);
      Console.WriteLine("E format:{0:E}",99999);
      Console.WriteLine("e format:{0:e}",99999);
      Console.WriteLine("X format:{0:x}",99999);

      int maxint=int.MaxValue;
      int maxchar=char.MaxValue;
    
      Console.WriteLine(""+maxint);

      Console.WriteLine(""+maxchar);
      short maxshort=short.MaxValue;
      Console.WriteLine(""+maxshort);
      long maxlong=long.MaxValue;
      Console.WriteLine(""+maxlong);
      
      
    
    


      




    }

 
}

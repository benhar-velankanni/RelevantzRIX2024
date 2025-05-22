using MyAnonymousMethod;
 
class Program{
 
    public static void Main(){
 
       UsingAnonymous.MyDelegate delarevalue=null;
 
       for(int i=1;i<=5;i++){
           int k=i;
           UsingAnonymous.MyDelegate tempdata=delegate{Console.WriteLine(k);};
           delarevalue+=tempdata;
       }
 
       delarevalue();
 
       Console.ReadLine();
 
    }
}
 
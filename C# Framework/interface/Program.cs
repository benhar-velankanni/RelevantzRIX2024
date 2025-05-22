//BBaseIO
//Interface Ipict
//Methods : deleteImage(), displayImage()
//New requirement : Interface Ipictmanpic
 
class Baseio{
    public void baseio(){
        Console.WriteLine("Basic input output");
    }
}
 
interface Ipictmanpic{
    void applyAlpha();
    void displayImage();
   
}
interface IPict
{
    void deleteImage();
    void displayImage();
}
 
class MyImage : Baseio,IPict,Ipictmanpic
{
    public void applyAlpha()
    {
        Console.WriteLine("Alpha applied");
    }
 
    public void deleteImage()
    {
        Console.WriteLine("Image deleted");
    }
    void IPict.displayImage()
    {
        Console.WriteLine("Image displayed");
    }
 
    void Ipictmanpic.displayImage()
    {
        Console.WriteLine("Alpha Image displayed");
    }
 
}
 
class Program
{
    static void Main(string[] args)
    {
        MyImage img = new MyImage();
        img.applyAlpha();
        img.baseio();
        img.deleteImage();
       
       
       
    }
}
 
using System.Text;

class Training
{
    public string topic;
    public Training(){
        topic="dotnet";
        Console.WriteLine(topic);
    }

}
class Excercise{
    static void Main(){
        Training t1=new Training();
        Console.WriteLine(t1.topic);
    }
}
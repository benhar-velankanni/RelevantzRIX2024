public class Grade
{
    public void Gradescal()
    {
        int mark;

        Console.WriteLine("Enter the marks");
        mark=Convert.ToInt32(Console.ReadLine());
        if(mark>=90 && mark<=100)
        {
            Console.WriteLine("Grade A");
        }
        else if(mark>=75 && mark<=89)
        {
            Console.WriteLine("Grade B");
        }
        else if(mark>=50 && mark<=74)
        {
            Console.WriteLine("Grade C");
        }
        else
        {
            Console.WriteLine("Fail");
        }
    }
}
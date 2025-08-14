// - Create a class name "Person", use the properties:
// 	Name,
// 	Age,
// 	Contact,
// 	Mail.
// Create behaviours within person to get details and display details.
// Create another class called Student, it inherits person. Student class has properties:
// 	CollegeName,
// 	Sem I, II, III Marks.
// Create a behaviour to find average mark of the said student.
// Create another class called PG, it inherits student and check the behaviour to find eligibility for student to be PG.

class Collge
{
    public static void Main()
    {
        PG pg = new PG();
        Console.WriteLine("\nEnter the details of the student: ");
        Console.WriteLine("====================================");
        Console.Write("Name: ");
        pg.Name = Console.ReadLine();
        Console.Write("Age: ");
        pg.Age = int.Parse(Console.ReadLine());
        Console.Write("Mobile Number: ");
        pg.Contact = int.Parse(Console.ReadLine());
        Console.Write("Mail ID: ");
        pg.MailID = Console.ReadLine();
        Console.Write("College Name: ");
        pg.CollegeName = Console.ReadLine();
        Console.Write("Semster Marks: ");
        Console.Write("\nI: ");
        pg.Sem1Marks = int.Parse(Console.ReadLine());
        Console.Write("II: ");
        pg.Sem2Marks = int.Parse(Console.ReadLine());
        Console.Write("III: ");
        pg.Sem3Marks = int.Parse(Console.ReadLine());
        Console.WriteLine("====================================");

        pg.display();

        if (pg.isEligible())
        {

            Console.WriteLine("====================================");
            Console.WriteLine("This candidate is eligible for PG.");
            Console.WriteLine("====================================");
        }
        else
        {

            Console.WriteLine("====================================");
            Console.WriteLine("This candidate is NOT eligible for PG.");
            Console.WriteLine("====================================");
        }
    }
}
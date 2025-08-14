// Case Study: Personal Task Manager 

// This C# program simulates a simple to-do list application, demonstrating core object-oriented programming
//(OOP) principles. The application utilizes a Task struct to represent individual tasks, each containing a
//description and completion status. An abstract class, TaskPersistence, defines the contract for saving and
//loading tasks, enabling flexibility in data storage mechanisms. FileTaskPersistence, a concrete implementation,
//handles file-based persistence. The TodoList class encapsulates the logic for managing a list of tasks, using a
//vector to store them and employing dependency injection to accept a TaskPersistence object.
//This allows the TodoList to work with different persistence strategies.  
// The program features a menu-driven interface, 
// 1. Add Task  
// 2. Display Tasks  
// 3. Mark Task Complete  
// 4. Save Tasks  
// 5. Load Tasks 
// 6. Exit  
// The code demonstrates abstraction, inheritance, encapsulation, and polymorphism,
//showcasing a well-structured OOP approach to a basic to-do list application. 

using System.Security.Cryptography.X509Certificates;

//AN ENCAPSULATION CLASS THAT WITHHOLDS THE MAIN/CORE LOGIC OF THE TASK MANAGER APPLICATION.
class TodoList
{
    public static void Main()
    {
        List<Task> myTasks = new List<Task>();
        FileTaskPersistence fileTaskPersistence = new FileTaskPersistence();
        Update update = new Update();

    //USING A LABEL-GOTO MECHANISM FOR FLOW CONTROL IN PROGRAM:
    checkpoint1:
        Console.WriteLine("\n=========================");
        Console.WriteLine("TASK MANAGER:");
        Console.WriteLine("=========================");
        Console.WriteLine("1. Add Task.");
        Console.WriteLine("2. Display Tasks.");
        Console.WriteLine("3. Display Incomplete Tasks.");
        Console.WriteLine("4. Mark Task Complete.");
        Console.WriteLine("5. Remove Tasks");
        Console.WriteLine("6. Search Tasks");
        Console.WriteLine("0. Exit");

        Console.Write("\nENTER YOUR CHOICE: ");
        int choice1 = int.Parse(Console.ReadLine());

        //BASIC SWITCH CASE:
        switch (choice1)
        {
            default:
                {
                    Console.WriteLine("\n=========================");
                    Console.WriteLine("INVALID INPUT, TRY AGAIN!");
                    Console.WriteLine("=========================");
                    goto checkpoint1; //RETURNS TO THE MENU, AWAITING FOR A VALID INPUT.
                }

            case 0:
                {
                    Console.WriteLine("\n=========================");
                    Console.WriteLine("      LOGGING OUT!");
                    Console.WriteLine("=========================");
                    return; //EXITS PROGRAM
                }

            case 1:
                {
                    fileTaskPersistence.AddTasks(myTasks); //FUNCTION CALL TO ADD A TASK.
                    goto checkpoint1;
                }

            case 2:
                {
                    fileTaskPersistence.DisplayTasks(myTasks); //FUNCTION CALL TO DISPLAY ALL TASKS.
                    goto checkpoint1;
                }

            case 3:
                {
                    fileTaskPersistence.DisplayTasks(myTasks, false); //FUNCTION CALL TO DISPLAY INCOMLETE TASKS ONLY.
                    goto checkpoint1;
                }

            case 4:
                {
                    update.MarkAsComplete(myTasks); //FUNCTION CALL TO MARK A SPECIFIC TASK AS COMPLETE.
                    goto checkpoint1;
                }

            case 5:
                {
                    fileTaskPersistence.RemoveTasks(myTasks); //FUNCTION CALL TO REMOVE A SPECIFIC CLASS.
                    goto checkpoint1;
                }

            case 6:
                {
                    fileTaskPersistence.SearchTasks(myTasks); //FUNCTION CALL TO SEARCH AND DISPLA ANY TASK IN PARTICULAR.
                    goto checkpoint1;
                }
        }
    }
}

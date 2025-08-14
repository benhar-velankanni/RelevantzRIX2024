//A CONCRETE CLASS THAT IMPLEMENTS AN ABSTRACT CLASS, AND PROVIDES DEFINITION TO THE FUNCTIONS DELARED WITHIN THE ABSTRACT CLASS.
class FileTaskPersistence : TaskPersistence
{
    //SHOWCASING METHOD OVERRIDING.
    public override void AddTasks(List<Task> myTasks)
    {
        Console.Write("\nENTER THE ID OF THE TASK: ");
        int ID = int.Parse(Console.ReadLine());
        Console.Write("ENTER THE TASK DESCRIPTION:");
        string description = Console.ReadLine();

        //ADDING THE TASK TO THE LIST USING THE .ADD() AND A STRUCT CONSTRUCTOR. 
        myTasks.Add(new Task(ID, description));
        Console.WriteLine($"THE NEW TASK OF ID: {ID}, HAS BEEN ADDED!");
    }

    //SHOWCASING METHOD OVERRIDING.
    public override void DisplayTasks(List<Task> myTasks)
    {
        Console.WriteLine("\n=========================");
        Console.WriteLine("ALL TASKS:");
        Console.WriteLine("=========================");
        foreach (Task task in myTasks)
        {
            Console.WriteLine($"\n{task.ID}: {task.Description},    Completed?: {task.Status}");
        }
    }

    //SHOWCASING METHOD OVERLOADING.
    public override void DisplayTasks(List<Task> myTasks, bool status)
    {
        Console.WriteLine("\n=========================");
        Console.WriteLine("INCOMPLETE TASKS:");
        Console.WriteLine("=========================");
        foreach (Task task in myTasks)
        {
            if (task.Status == status)
            {
                Console.WriteLine($"\n{task.ID}: {task.Description}"); //PRINTS ONLY IS THE STATUS IS SET TO FALSE.
            }
        }
    }

    //SHOWCASING METHOD OVERRIDING.
    public override void RemoveTasks(List<Task> myTasks)
    {
        Console.Write("\nENTER THE ID OF THE TASK TO REMOVE: ");
        int id = int.Parse(Console.ReadLine());

        //CHECKING IF SUCH A TASK IS PRESENT.
        bool found = false;
        foreach (Task task in myTasks)
        {
            if (task.ID == id)
            {
                found = true;
                break;
            }
        }

        //IF FOUND:
        if (found)
        {
            Task TaskToRemove = myTasks.Find(task => task.ID == id); //FINDING THE TASK AND PLACING IT IN A TASK VARIABLE.
            myTasks.Remove(TaskToRemove); //USING .REMOVE() TO DELETE THE SAID TASK FROM ITS INDEX INT THE ARRAY.
            Console.Write("THE SAID TASK HAS BEEN REMOVED SUCCESSFULLY!");
        }
        //IF NOT FOUND:
        else
        {
            Console.Write("THE SAID TASK IS NOWHERE TO BE FOUND!");
        }
    }

    //SHOWCASING METHOD OVERRIDING.
    public override void SearchTasks(List<Task> myTasks)
    {
        Console.Write("\nENTER THE ID OF THE TASK TO FIND: ");
        int id = int.Parse(Console.ReadLine());

        //CHECKING IF SUCH A TASK IS PRESENT.
        bool found = false;
        foreach (Task task in myTasks)
        {
            if (task.ID == id)
            {
                found = true;
                break;
            }
        }

        //IF FOUND:
        if (found)
        {
            Task TaskToDisplay = myTasks.Find(task => task.ID == id); //FINDING THE TASK AND PLACING IT IN A TASK VARIABLE.
            DisplayTask(TaskToDisplay); //FUNCION CALL TO A DISPLAY FUNTION FOR A STANDALONE TASK.
        }
        //IF NOT FOUND:
        else
        {
            Console.WriteLine("THE SAID TASK IS NOWHERE TO BE FOUND!");
        }
    }

    //SHOWCASING THE USE OF STATIC KEYWORD.
    static void DisplayTask(Task task)
    {
        Console.WriteLine("\n=========================");
        Console.WriteLine("RESULT:");
        Console.WriteLine("=========================");
        Console.WriteLine($"\n{task.ID}: {task.Description},    Completed?: {task.Status}");
    }
}
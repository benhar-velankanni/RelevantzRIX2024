//A CONCRETE CLASS DECLARED AND DEFINED WITH THE SOLE PURPOSE OF MARKING TASKS'S STATUS AS TRUE i.e COMPLETED.
class Update
{
    public void MarkAsComplete(List<Task> myTasks)
    {
        Console.Write("\nENTER THE ID OF THE TASK TO MARK AS COMPLETED: ");
        int id = int.Parse(Console.ReadLine());

        //CHECKING IF SUCH A TASK IS PRESENT
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
            Task TaskToComplete = myTasks.Find(task => task.ID == id); //FINDING THE TASK AND PLACING IT IN A TASK VARIABLE.
            myTasks.Remove(TaskToComplete); //DELETES THE SAID TASK, THUS REMOVING IT FROM CURRENT INDEX.
            TaskToComplete.Status = true; //UPDATING STATUS TO TRUE i.e COMPLETED.
            myTasks.Add(TaskToComplete); //RE-ADDING THE TASK TO THE END OF THE LIST.
            Console.WriteLine("THE SAID TASK HAS BEEN MARKED AS COMPLETE!");
        }
        //IF NOT FOUND:
        else
        {
            Console.WriteLine("THE SAID TASK IS NOWHERE TO BE FOUND!");
        }
    }
}
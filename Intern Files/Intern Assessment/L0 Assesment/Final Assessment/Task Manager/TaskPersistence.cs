//A SIMPLE ABSTRACT CLASS THAT DEFINES CONTRACT FOR VARIOUS OPERATIONS SUCH AS ADDING, DISPLAYING, REMOVING AND SEARCHING.
abstract class TaskPersistence()
{
    public abstract void AddTasks(List<Task> myTasks); //SHOWCASING METHOD OVERRIDING.
    public abstract void DisplayTasks(List<Task> myTasks); //SHOWCASING METHOD OVERLOADING.
    public abstract void DisplayTasks(List<Task> myTasks, bool status); //SHOWCASING METHOD OVERLOADING.
    public abstract void RemoveTasks(List<Task> myTasks); //SHOWCASING METHOD OVERRIDING.
    public abstract void SearchTasks(List<Task> myTasks); //SHOWCASING METHOD OVERRIDING.
}
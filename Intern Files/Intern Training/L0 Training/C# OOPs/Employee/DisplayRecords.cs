public class DisplayRecords{
    public void dispayRecords(List<Employee> employees){
        Console.WriteLine("\n======================");
        Console.WriteLine("The Employee Records: ");
        Console.WriteLine("======================");

        foreach (Employee emp in employees)
        {
            Console.WriteLine($"\nID: {emp.EmpId} \nName: {emp.Name} \nDepartment: {emp.Dept} \nSalary: ${emp.Salary}");
        }
    }
}
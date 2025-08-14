public class InsertRecords{
    public void Insertions(List<Employee> employees){
        Console.WriteLine("\nEnter the number of records: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the employee: ");
        Console.WriteLine("=====================================");
        for (int i = 0; i < n; i++)
        {
            Employee employee = new Employee();

            Console.Write("\nEmployee ID: ");
            employee.EmpId = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Department Name: ");
            employee.Dept = Console.ReadLine();

            Console.Write("Salary (in dollars): ");
            employee.Salary = double.Parse(Console.ReadLine());

            employees.Add(employee);
        }
    }
}
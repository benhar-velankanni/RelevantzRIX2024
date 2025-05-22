using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
class Employee{
    public string name;
    public double salary;
    public string designation;
    public Employee(string name,double salary,string designation){
        this.name=name;
        this.salary=salary;
        this.designation=designation;
    }
    public virtual void CalculateBonus(){
        double bonus=salary*0.1;
        Console.WriteLine("Bonus amount: "+bonus);
    }
       }
class Manager:Employee{
    public int NoofDirectReports;
    public Manager(string name,double salary,string designation,int NoofDirectReports):base(name,salary,designation){
        this.NoofDirectReports=NoofDirectReports;
    }
    public override void CalculateBonus(){
        double bonus=salary*0.1+NoofDirectReports*100;
        Console.WriteLine("Bonus amount: "+bonus);
    }
    }
class Contractor:Employee{
    public int hourlyrate;
    public int hoursWorked;
    public Contractor(string name,double salary,string designation,int hourlyrate,int hoursWorked):base(name,salary,designation){
        this.hourlyrate=hourlyrate;
        this.hoursWorked=hoursWorked;
    }
    public override void CalculateBonus(){
        double bouns=hourlyrate*hoursWorked*0.05;
        Console.WriteLine("Bonus amount: "+bouns);
    }
}
class Program{
    static void Main()
    {while(true){
        Console.WriteLine("Enter name");
        string name=Console.ReadLine();
        Console.WriteLine("Enter designation");
        string designation=Console.ReadLine();
        Console.WriteLine("Enter salary");
        double salary=double.Parse(Console.ReadLine());
        if(designation=="Manager")
        {
            Console.WriteLine("Enter number of direct reports");
            int NoofDirectReports=int.Parse(Console.ReadLine());
            Manager manager=new Manager(name,salary,designation,NoofDirectReports);
            Console.WriteLine("Name"+manager.name);
            Console.WriteLine("Salary"+manager.salary);
            Console.WriteLine("Designation"+manager.designation);
            manager.CalculateBonus();
        }
        else if(designation=="Contractor")
        {
            Console.WriteLine("Enter hourly rate");
            int hourlyrate=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter hours worked");
            int hoursWorked=int.Parse(Console.ReadLine());
            Contractor contractor=new Contractor(name,salary,designation,hourlyrate,hoursWorked);
            Console.WriteLine("Name"+contractor.name);
            Console.WriteLine("Salary"+contractor.salary);
            Console.WriteLine("Designation"+contractor.designation);
            contractor.CalculateBonus();
        }
        else
        {
            Employee employee=new Employee(name,salary,designation);
            employee.CalculateBonus();
        }
    }
}
}
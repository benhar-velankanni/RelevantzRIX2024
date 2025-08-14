//Ex: 5	Write a C# program to create a class called "School" with attributes for students, teachers, and classes, and methods to add and remove students and teachers, and to create classes.

using System;
using System.Collections.Generic;

class School
{
    private List<string> students = new List<string>();
    private List<string> teachers = new List<string>();
    private List<string> classes = new List<string>();

    // Method to add a student
    public void AddStudent(string student)
    {
        students.Add(student);
        Console.WriteLine($"{student} has been added as a student.");
    }

    // Method to remove a student
    public void RemoveStudent(string student)
    {
        if (students.Contains(student))
        {
            students.Remove(student);
            Console.WriteLine($"{student} has been removed.");
        }
        else
        {
            Console.WriteLine($"{student} not found.");
        }
    }

    // Method to add a teacher
    public void AddTeacher(string teacher)
    {
        teachers.Add(teacher);
        Console.WriteLine($"{teacher} has been added as a teacher.");
    }

    // Method to remove a teacher
    public void RemoveTeacher(string teacher)
    {
        if (teachers.Contains(teacher))
        {
            teachers.Remove(teacher);
            Console.WriteLine($"{teacher} has been removed.");
        }
        else
        {
            Console.WriteLine($"{teacher} not found.");
        }
    }

    // Method to create a class
    public void CreateClass(string className)
    {
        classes.Add(className);
        Console.WriteLine($"{className} class has been created.");
    }

    // Method to display all current students, teachers, and classes
    public void DisplayInfo()
    {
        Console.WriteLine("\nStudents:");
        Console.WriteLine("===========");
        foreach (var student in students) Console.WriteLine(student);

        Console.WriteLine("\nTeachers:");
        Console.WriteLine("===========");
        foreach (var teacher in teachers) Console.WriteLine(teacher);

        Console.WriteLine("\nClasses:");
        Console.WriteLine("==========");
        foreach (var className in classes) Console.WriteLine(className);
    }
}

class Program
{
    static void Main()
    {
        School school = new School();
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("===================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Add Teacher");
            Console.WriteLine("4. Remove Teacher");
            Console.WriteLine("5. Create Class");
            Console.WriteLine("6. Display All Info");
            Console.WriteLine("7. Exit");

            Console.WriteLine("\nEnter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string student = Console.ReadLine();
                    school.AddStudent(student);
                    break;
                case "2":
                    Console.Write("Enter student name to remove: ");
                    string removeStudent = Console.ReadLine();
                    school.RemoveStudent(removeStudent);
                    break;
                case "3":
                    Console.Write("Enter teacher name: ");
                    string teacher = Console.ReadLine();
                    school.AddTeacher(teacher);
                    break;
                case "4":
                    Console.Write("Enter teacher name to remove: ");
                    string removeTeacher = Console.ReadLine();
                    school.RemoveTeacher(removeTeacher);
                    break;
                case "5":
                    Console.Write("Enter class name: ");
                    string className = Console.ReadLine();
                    school.CreateClass(className);
                    break;
                case "6":
                    school.DisplayInfo();
                    break;
                case "7":
                    Console.WriteLine("Exiting the program...");
                    continueRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
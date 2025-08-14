class Student : Person
{
    public string CollegeName { get; set; }
    public int Sem1Marks { get; set; }
    public int Sem2Marks { get; set; }
    public int Sem3Marks { get; set; }

    // public Student(string collegeName, int sem1, int sem2, int sem3){
    //     CollegeName = collegeName;
    //     Sem1Marks = sem1;
    //     Sem2Marks = sem2;
    //     Sem3Marks = sem3;
    // }

    public void display(){
        
        Console.WriteLine("====================================");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Age: {this.Age}");
        Console.WriteLine($"Contact {this.Contact}");
        Console.WriteLine($"Mail: {this.MailID}");
        Console.WriteLine($"College Name: {this.CollegeName}");
        Console.WriteLine($"Semester Marks: I: {this.Sem1Marks}, II: {this.Sem2Marks}, III: {this.Sem3Marks}");
        int avg = average();
        Console.WriteLine($"Average Marks: {avg}");
        Console.WriteLine("====================================");
    }

    public int average(){
        int sum = Sem1Marks + Sem2Marks + Sem3Marks;
        int avg = sum / 3;
        return avg;
    }
}
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool Present { get; set; }

    public Student(int id, string name, bool isPresent)
    {
        Id = id;
        Name = name;
        Present = isPresent;
    }

}
namespace AttendanceTracker
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        public Student() { }

        public Student(int id, string name, string className = "")
        {
            Id = id;
            Name = name;
            Class = className;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {Id})";
        }
    }
}
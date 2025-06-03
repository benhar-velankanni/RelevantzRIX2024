class Program
{
    public static void Main(string[] args)
    {
        Attendance attendance = new Attendance();

        attendance.AddStudent(new Student(1, "Vignesh", true));
        attendance.AddStudent(new Student(2, "Mukesh", true));
        attendance.checkStatus(2);

        attendance.updateAttendance(2, "Absent");
        
        


        
        

        
    }
}
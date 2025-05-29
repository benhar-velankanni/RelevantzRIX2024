namespace AttendanceTracker
{
    public class AttendanceManager
    {
        private readonly ICollection<Student> presentStudents;

        public AttendanceManager()
        {
            presentStudents = new List<Student>();
        }

        public void MarkPresent(Student student)
        {
            if (IsStudentPresent(student))
            {
                Console.WriteLine($"{student.Name} is already marked present.");
                return;
            }

            presentStudents.Add(student);
            Console.WriteLine($"{student.Name} marked as present.");
        }

        public void RemoveStudent(Student student)
        {
            var studentToRemove = presentStudents.FirstOrDefault(s => s.Id == student.Id);
            
            if (studentToRemove != null)
            {
                presentStudents.Remove(studentToRemove);
                Console.WriteLine($"{student.Name} removed from attendance.");
            }
            else
            {
                Console.WriteLine($"{student.Name} not found in attendance list.");
            }
        }

        public void DisplayAttendance()
        {
            Console.WriteLine("\nPresent Students:");
            
            if (presentStudents.Count == 0)
            {
                Console.WriteLine("No students marked present.");
            }
            else
            {
                foreach (var student in presentStudents)
                {
                    Console.WriteLine(student.Name);
                }
            }
            
            Console.WriteLine($"Total Present: {presentStudents.Count}");
        }

        public int GetPresentCount()
        {
            return presentStudents.Count;
        }

        public bool IsStudentPresent(Student student)
        {
            return presentStudents.Any(s => s.Id == student.Id);
        }

        public List<Student> GetPresentStudents()
        {
            return presentStudents.ToList();
        }

        public void ClearAttendance()
        {
            presentStudents.Clear();
            Console.WriteLine("All attendance cleared.");
        }
    }
}
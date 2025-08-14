namespace TeaTokenManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public ICollection<TeaTokenLog> TeaTokenLogs { get; set; }
    }

}

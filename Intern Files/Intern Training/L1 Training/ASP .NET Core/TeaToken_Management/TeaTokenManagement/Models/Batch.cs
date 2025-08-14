namespace TeaTokenManagement.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}

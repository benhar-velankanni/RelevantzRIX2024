namespace TeaTokenManagement.Models
{
    public class TeaTokenLog
    {
        public int TeaTokenLogId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public string Session { get; set; } // "Morning" or "Evening"
        public string DrinkType { get; set; } // "Tea" or "Coffee"
        public string IssuedBy { get; set; }
    }

}

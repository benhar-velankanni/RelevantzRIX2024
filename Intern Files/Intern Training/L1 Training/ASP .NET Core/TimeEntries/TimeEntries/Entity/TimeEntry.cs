using System.ComponentModel.DataAnnotations;

namespace TimeEntries.Entity
{
    /// <summary>
    /// Represents a time entry record for an employee.
    /// </summary>
    public class TimeEntry
    {
        [Key]
        [Required]
        public int TimeEntryId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateOnly DateOfEntry { get; set; }

        [Required]
        public double NumberOfHours { get; set; }

        public string? TaskDescription { get; set; } = string.Empty;
    }
}
using TimeEntries.Entity;

namespace TimeEntries.Repository
{
    /// <summary>
    /// Interface for managing time entry data operations.
    /// Defines the contract for CRUD operations on TimeEntry entities.
    /// </summary>
    public interface ITimeEntryRepository
    {
        /// <summary>
        /// Retrieves all time entries.
        /// </summary>
        IEnumerable<TimeEntry> GetAllTimeEntries();

        /// <summary>
        /// Retrieves a specific time entry by its ID.
        /// </summary>
        TimeEntry GetTimeEntryById(int id);

        /// <summary>
        /// Adds a new time entry.
        /// </summary>
        void AddTimeEntry(TimeEntry entry);

        /// <summary>
        /// Updates an existing time entry.
        /// </summary>
        void UpdateTimeEntry(TimeEntry entry);

        /// <summary>
        /// Deletes a time entry by its ID.
        /// </summary>
        void DeleteTimeEntry(int id);
    }
}

using TimeEntries.Data;
using TimeEntries.Entity;

namespace TimeEntries.Repository
{
    /// <summary>
    /// Concrete implementation of ITimeEntryRepository using Entity Framework Core.
    /// Handles CRUD operations for TimeEntry entities.
    /// </summary>
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Constructor that injects the application's database context.
        /// </summary>
        public TimeEntryRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        /// <summary>
        /// Adds a new time entry to the database.
        /// </summary>
        public void AddTimeEntry(TimeEntry entry)
        {
            _appDbContext.TimeEntries.Add(entry);
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a time entry by its ID.
        /// </summary>
        public void DeleteTimeEntry(int id)
        {
            var entry = _appDbContext.TimeEntries.Find(id);
            if (entry != null)
            {
                _appDbContext.TimeEntries.Remove(entry);
                _appDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all time entries from the database.
        /// </summary>
        public IEnumerable<TimeEntry> GetAllTimeEntries()
        {
            return _appDbContext.TimeEntries.ToList();
        }

        /// <summary>
        /// Retrieves a specific time entry by its ID.
        /// </summary>
        public TimeEntry GetTimeEntryById(int id)
        {
            return _appDbContext.TimeEntries.FirstOrDefault(t => t.TimeEntryId == id);
        }

        /// <summary>
        /// Updates an existing time entry in the database.
        /// </summary>
        public void UpdateTimeEntry(TimeEntry entry)
        {
            _appDbContext.TimeEntries.Update(entry);
            _appDbContext.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TimeEntries.Entity;
using TimeEntries.Repository;
using System.Diagnostics.CodeAnalysis;

namespace TimeEntries.Controllers
{
    /// <summary>
    /// Controller for managing time entry operations such as listing, creating, editing, and deleting entries.
    /// </summary>
    public class TimeEntryController : Controller
    {
        private readonly ITimeEntryRepository _repository;
        private readonly ILogger<TimeEntryController> _logger;

        /// <summary>
        /// Constructor that injects the time entry repository and logger.
        /// </summary>
        public TimeEntryController(ITimeEntryRepository repository, ILogger<TimeEntryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Displays a list of all time entries.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var entries = _repository.GetAllTimeEntries();
                var viewModels = entries.Select(e => new TimeEntry
                {
                    TimeEntryId = e.TimeEntryId,
                    EmployeeId = e.EmployeeId,
                    DateOfEntry = e.DateOfEntry,
                    NumberOfHours = e.NumberOfHours,
                    TaskDescription = e.TaskDescription
                }).ToList();

                return View(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading time entries.");
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<TimeEntry>());
            }
        }

        /// <summary>
        /// Displays the form to create a new time entry.
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of a new time entry.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeEntry model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.AddTimeEntry(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating time entry.");
                    TempData["ErrorMessage"] = ex.Message;
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        /// <summary>
        /// Displays the form to edit an existing time entry.
        /// </summary>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var entry = _repository.GetTimeEntryById(id);
                if (entry == null)
                {
                    ViewBag.ErrorMessage = $"Time entry with ID {id} not found.";
                    return NotFound();
                }

                return View(entry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading time entry for editing.");
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        /// <summary>
        /// Handles the submission of an edited time entry.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TimeEntry entry)
        {
            if (id != entry.TimeEntryId)
            {
                ViewBag.ErrorMessage = "Mismatched time entry ID.";
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateTimeEntry(entry);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating time entry.");
                    ViewBag.ErrorMessage = ex.Message;
                }
            }

            return View(entry);
        }

        /// <summary>
        /// Displays the confirmation page for deleting a time entry.
        /// </summary>
        [HttpGet]        
        public IActionResult Delete(int id)
        {
            try
            {
                var entry = _repository.GetTimeEntryById(id);
                if (entry == null)
                {
                    ViewBag.ErrorMessage = $"Time entry with ID {id} not found.";
                    return NotFound();
                }

                return View(entry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading time entry for deletion.");
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        /// <summary>
        /// Handles the deletion of a time entry.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repository.DeleteTimeEntry(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting time entry.");
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Displays the details of a specific time entry.
        /// </summary>
        [HttpGet]        
        public IActionResult Details(int id)
        {
            try
            {
                var entry = _repository.GetTimeEntryById(id);
                if (entry == null)
                {
                    ViewBag.ErrorMessage = $"Time entry with ID {id} not found.";
                    return NotFound();
                }

                return View(entry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading time entry details.");
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}

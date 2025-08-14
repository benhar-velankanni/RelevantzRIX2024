using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeaTokenManagement.Data;
using TeaTokenManagement.Models;

public class TokenEntryModel : PageModel
{
    private readonly AppDbContext _context;

    public TokenEntryModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public DateTime EntryDate { get; set; } = DateTime.Today;

    [BindProperty]
    public string Session { get; set; } = "Morning";

    public List<Employee> Employees { get; set; } = new();

    [BindProperty]
    public List<int> SelectedIds { get; set; } = new();

    public async Task OnGetAsync()
    {
        Employees = await _context.Employees.Include(e => e.Batch).ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Employees = await _context.Employees.Include(e => e.Batch).ToListAsync();

        foreach (var empId in SelectedIds)
        {
            var drinkType = Request.Form[$"DrinkType_{empId}"];
            var log = new TeaTokenLog
            {
                EmployeeId = empId,
                Date = EntryDate.Date,
                Session = Session,
                DrinkType = drinkType,
                IssuedBy = "Admin" // You can replace with actual user
            };
            _context.TeaTokenLogs.Add(log);
        }

        await _context.SaveChangesAsync();
        TempData["Message"] = "Entries saved successfully!";
        return RedirectToPage();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeaTokenManagement.Data;
using TeaTokenManagement.Models;

public class DeleteTokenModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteTokenModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TeaTokenLog TokenLog { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        TokenLog = await _context.TeaTokenLogs
            .Include(t => t.Employee)
            .FirstOrDefaultAsync(t => t.TeaTokenLogId == id);

        if (TokenLog == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var token = await _context.TeaTokenLogs.FindAsync(TokenLog.TeaTokenLogId);
        if (token == null)
            return NotFound();

        _context.TeaTokenLogs.Remove(token);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Reports");
    }
}

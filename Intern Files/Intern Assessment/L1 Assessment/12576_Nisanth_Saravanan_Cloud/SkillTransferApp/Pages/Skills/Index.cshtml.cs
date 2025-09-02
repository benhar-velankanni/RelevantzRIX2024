using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkillTransferApp.Models;

namespace SkillTransferApp.Pages_Skills
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Skill> Skill { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Skill = await _context.Skills.ToListAsync();
        }
    }
}

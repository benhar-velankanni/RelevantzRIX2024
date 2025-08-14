using DemoRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazor.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]

        public User User { get; set; }

        public void OnGet()

        {

        }

        public IActionResult OnPost()

        {

            // You can handle form submission here (e.g., save to DB)

            return RedirectToPage("Success"); // or wherever you want

        }
    }
}



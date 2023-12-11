using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuAnsBibel.Models;

namespace QuAnsBibel.Pages
{
    public class IndexModel : PageModel
    {
        public FormSetup _FormSetup;

        public IActionResult OnGet()
        {
            return RedirectToPage("Home");
        }
    }
}


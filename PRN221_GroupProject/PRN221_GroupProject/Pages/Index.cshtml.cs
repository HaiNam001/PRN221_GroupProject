using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(PRN221Context context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        public CreateModel(PRN221Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

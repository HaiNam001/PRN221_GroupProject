using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        public DeleteModel(PRN221Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [BindProperty]
        public User Users { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var course = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Users = course;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var course = await _context.Users.FindAsync(id);

            if (course != null)
            {
                Users = course;
                _context.Users.Remove(Users);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

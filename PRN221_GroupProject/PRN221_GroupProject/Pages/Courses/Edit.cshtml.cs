using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_GroupProject.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _web;
        public EditModel(PRN221Context context, IConfiguration configuration, IWebHostEnvironment web)
        {
            _context = context;
            _configuration = configuration;
            _web = web;
        }

        [BindProperty]
        public Course Course { get; set; } = default!;
        [BindProperty]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            Course = course;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (File != null)
            {

                var path = Path.Combine(_web.WebRootPath, "./images", File.FileName);
                using var fileStream = new FileStream(path, FileMode.Create);
                File.CopyTo(fileStream);
                Course.Image = File.FileName;
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Course.CourseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Lessons
{
    public class IndexModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        public IndexModel(PRN221Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public List<Course> Courses { get; set; }

        public void OnGet()
        {
         var course = _context.Courses.ToList();
            Courses = course;
        }
    }
}

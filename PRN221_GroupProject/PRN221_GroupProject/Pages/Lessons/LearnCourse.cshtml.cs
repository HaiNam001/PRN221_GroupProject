using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Lessons
{
    public class LearnCourseModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        public LearnCourseModel(PRN221Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Course Course { get; set; }
        public List<Lesson> Lesson { get; set; }


        public void OnGet(int? id)
        {
            var Courses = _context.Courses.ToList();

            Course = Courses.FirstOrDefault(x => x.CourseId == id);

            Lesson = _context.Lessons.Where(x => x.CourseId == id).ToList();
        }
    }
}

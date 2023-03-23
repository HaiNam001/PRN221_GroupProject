using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.View
{
    public class MyCourseModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyCourseModel(PRN221Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [BindProperty]
        public List<MyCourse> MyCourse { get; set; }
        public IActionResult OnGet(int id,int index)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (id == 0)
            {
                return NotFound();
            }

            if (index == 0)
            {
                index = 1;
            }
            MyCourse = _context.MyCourses.Include(x => x.Course).Where(x => x.UserId == id).Skip((index-1)*3).Take(3).ToList();
            int totalMyCourse = _context.MyCourses.Where(x=>x.UserId== id).Count();
            int endpage = totalMyCourse/3;
            if(totalMyCourse % 3!=0)
            {
                endpage++;
            }
            session.SetInt32("endpage", endpage);
            return Page();
        }

     
    }
}

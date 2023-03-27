using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.View
{
    public class MyCourseModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        public MyCourseModel(PRN221Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // public User User { get; set; }
        public List<Rating> Rating { get; set; }


        public void OnGet()
        {
            Rating = _context.Ratings.Include(o => o.User).Include(o => o.Course).ToList();
        }


    }
}

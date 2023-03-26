using Lab2._2.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Users
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
        public List<User> Users { get; set; }

        public async Task OnGetAsync(int? pageNum)
        {
            Users = _context.Users.ToList();
            //IQueryable<User> user = from s in _context.Users
            //                        select s;
            //var pageSize = _configuration.GetValue("PageSize", 3);

            //Users = await PaginatedList<User>.CreateAsync(user.AsNoTracking(), pageNum ?? 1, pageSize);
        }

    }
}

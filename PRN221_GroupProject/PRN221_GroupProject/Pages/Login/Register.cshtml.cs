using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly PRN221Context _context;

        [BindProperty]
        public User User { get; set; }

        public string Message { get; set; }

        public RegisterModel(PRN221Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = _context.Users.Where(x => x.UserName.Equals(User.UserName) || x.UserEmail.Equals(User.UserEmail)).FirstOrDefault();
            if(user== null)
            {
                _context.Add(User);
                _context.SaveChanges();
                return RedirectToPage("/Login/Login");
            }
            Message = "UserName or Email has been registered!";
            return Page();
        }
    }
}

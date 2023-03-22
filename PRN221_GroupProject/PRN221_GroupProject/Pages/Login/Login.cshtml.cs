using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly PRN221Context _context;

        public LoginModel(PRN221Context context)
        {
            _context = context;
        }
        public string ErrorMessage { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(string username,string password)
        {
            var user = _context.Users.Where(x => x.UserName.Equals(username) && x.UserPassword.Equals(password)).FirstOrDefault();
            if(user != null)
            {
                return RedirectToPage("/Index");
            }
            ErrorMessage = "Invalid username or password!";
            return Page();
        }
    }
}

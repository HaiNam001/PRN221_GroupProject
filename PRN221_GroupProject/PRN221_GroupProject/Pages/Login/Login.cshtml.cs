using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;

namespace PRN221_GroupProject.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginModel(PRN221Context context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
                var session = _httpContextAccessor.HttpContext.Session;
                session.SetString("username",username);
                session.SetInt32("userid",user.UserId);
                return RedirectToPage("/Index");
            }
            ErrorMessage = "Invalid username or password!";
            return Page();
        }
    }
}

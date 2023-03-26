using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_GroupProject.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_GroupProject.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly PRN221Context _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _web;
        public CreateModel(PRN221Context context, IConfiguration configuration, IWebHostEnvironment web)
        {
            _context = context;
            _configuration = configuration;
            _web = web;
        }
        [BindProperty]
        public Course Course { get; set; }
        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage ="need choose a file")]
        [Display(Name ="Image")]
        public IFormFile File { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if(File != null)
            {

                var path = Path.Combine(_web.WebRootPath, "./images", File.FileName);
                using var fileStream = new FileStream(path, FileMode.Create);
                File.CopyTo(fileStream);
            }

            Course.Image = File.FileName;
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

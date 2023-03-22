using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_GroupProject.Models
{
    public partial class Course
    {
        public Course()
        {
            Lessons = new HashSet<Lesson>();
            MyCourses = new HashSet<MyCourse>();
            Ratings = new HashSet<Rating>();
        }
        
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        public string CourseName { get; set; } = null!;
        [Required(ErrorMessage = "Description can't be empty")]
        public string CourseDescription { get; set; } = null!;
        [Required(ErrorMessage = "Price can't be empty")]
        public decimal CoursePrice { get; set; }
        [Required(ErrorMessage = "Time can't be empty")]
        public int CourseTime { get; set; }
        [Required(ErrorMessage = "Image can't be empty")]
        public string Image { get; set; } = null!;

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<MyCourse> MyCourses { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}

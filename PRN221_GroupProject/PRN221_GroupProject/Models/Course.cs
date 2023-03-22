using System;
using System.Collections.Generic;

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
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public decimal CoursePrice { get; set; }
        public int CourseTime { get; set; }
        public string Image { get; set; } = null!;

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<MyCourse> MyCourses { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}

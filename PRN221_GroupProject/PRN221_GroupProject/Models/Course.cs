using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class Course
    {
        public Course()
        {
            Orders = new HashSet<Order>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int CourseTime { get; set; }
        public string Descriptions { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

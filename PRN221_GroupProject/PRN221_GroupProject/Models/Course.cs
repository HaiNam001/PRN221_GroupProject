using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class Course
    {
        public Course()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public decimal CoursePrice { get; set; }
        public int CourseTime { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

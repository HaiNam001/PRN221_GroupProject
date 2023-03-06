using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}

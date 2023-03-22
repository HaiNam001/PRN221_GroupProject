using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class Rating
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string Comment { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

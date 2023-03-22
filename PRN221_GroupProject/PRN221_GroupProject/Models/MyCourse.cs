using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class MyCourse
    {
        public int MycourseId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

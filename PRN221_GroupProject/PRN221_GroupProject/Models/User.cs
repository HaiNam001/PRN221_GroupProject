using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class User
    {
        public User()
        {
            MyCourses = new HashSet<MyCourse>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<MyCourse> MyCourses { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}

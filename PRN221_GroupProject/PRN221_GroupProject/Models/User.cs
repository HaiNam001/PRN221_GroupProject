using System;
using System.Collections.Generic;

namespace PRN221_GroupProject.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

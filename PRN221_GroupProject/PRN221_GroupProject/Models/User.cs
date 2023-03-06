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
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

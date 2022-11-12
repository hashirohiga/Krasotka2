using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? UserRole { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krasotka2.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; } = null!;
        [NotMapped]
        public string FullName
        {
            get => Surname + " " + Name + " " + LastName;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class StatusType
    {
        public StatusType()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

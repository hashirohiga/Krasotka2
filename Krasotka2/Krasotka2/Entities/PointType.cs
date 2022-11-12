using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class PointType
    {
        public PointType()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

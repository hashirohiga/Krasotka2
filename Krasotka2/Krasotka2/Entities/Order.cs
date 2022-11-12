using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderPropucts = new HashSet<OrderPropuct>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDateDelivery { get; set; }
        public int PickupPoint { get; set; }
        public string? Fio { get; set; }
        public string Cvv { get; set; } = null!;
        public int Status { get; set; }

        public virtual PointType PickupPointNavigation { get; set; } = null!;
        public virtual StatusType StatusNavigation { get; set; } = null!;
        public virtual ICollection<OrderPropuct> OrderPropucts { get; set; }
    }
}

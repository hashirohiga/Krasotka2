using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class SupplierType
    {
        public SupplierType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

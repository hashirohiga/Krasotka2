using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class ManufactureType
    {
        public ManufactureType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ManufactureName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

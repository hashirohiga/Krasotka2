using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

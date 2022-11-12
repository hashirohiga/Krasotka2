using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class Product
    {
        private string? _image;
        public Product()
        {
            OrderPropucts = new HashSet<OrderPropuct>();
        }

        public string Article { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal Cost { get; set; }
        public int MaxDiscount { get; set; }
        public int? Manufacture { get; set; }
        public int? Supplier { get; set; }
        public int? Category { get; set; }
        public int CurrentDiscount { get; set; }
        public int CountInStock { get; set; }
        public string Description { get; set; } = null!;
        public string? Image {
            get => (_image == null || _image == string.Empty)
                ? $"\\Resources\\picture.png"
                : $"\\Resources\\products\\{_image}";
            set => _image = value;
        }

        public virtual CategoryType? CategoryNavigation { get; set; }
        public virtual ManufactureType? ManufactureNavigation { get; set; }
        public virtual SupplierType? SupplierNavigation { get; set; }
        public virtual ICollection<OrderPropuct> OrderPropucts { get; set; }
    }
}

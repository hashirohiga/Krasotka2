using System;
using System.Collections.Generic;

namespace Krasotka2.Entities
{
    public partial class OrderPropuct
    {
        public int OrderId { get; set; }
        public string ArticleNumber { get; set; } = null!;
        public int ProductCount { get; set; }

        public virtual Product ArticleNumberNavigation { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}

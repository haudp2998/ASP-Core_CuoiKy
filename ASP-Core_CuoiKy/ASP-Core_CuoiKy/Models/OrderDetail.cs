using System;
using System.Collections.Generic;

namespace ASP_Core_CuoiKy.Models
{
    public partial class OrderDetail
    {
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}

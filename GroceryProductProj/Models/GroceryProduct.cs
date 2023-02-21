using System;
using System.Collections.Generic;

namespace GroceryProductProj.Models
{
    public partial class GroceryProduct
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
    }
}

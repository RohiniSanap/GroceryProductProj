using System;
using System.Collections.Generic;

namespace GroceryProductProj.Models
{
    public partial class GroceryProduct
    {
        public GroceryProduct()
        {
            SalePages = new HashSet<SalePage>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantityKg { get; set; }

        public virtual ICollection<SalePage> SalePages { get; set; }
    }
}

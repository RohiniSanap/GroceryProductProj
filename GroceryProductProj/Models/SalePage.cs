using System;
using System.Collections.Generic;

namespace GroceryProductProj.Models
{
    public partial class SalePage
    {
        public int Id { get; set; }
        public string CustName { get; set; } = null!;
        public string? Adress { get; set; }
        public int? ProductId { get; set; }
        public int? Rate { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
    }
}

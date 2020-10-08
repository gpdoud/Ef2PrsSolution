using System;
using System.Collections.Generic;

namespace Ef2PrsConsole
{
    public partial class Products
    {
        public Products()
        {
            Lineitems = new HashSet<Lineitems>();
        }

        public int Id { get; set; }
        public int VendorId { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string PhotoPath { get; set; }

        public virtual Vendors Vendor { get; set; }
        public virtual ICollection<Lineitems> Lineitems { get; set; }
    }
}

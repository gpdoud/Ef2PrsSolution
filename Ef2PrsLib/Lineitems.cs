using System;
using System.Collections.Generic;

namespace Ef2PrsConsole
{
    public partial class Lineitems
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual Request Request { get; set; }
    }
}

namespace SweetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int? OrderFID { get; set; }

        public int? ItemFID { get; set; }

        public int Quantity { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }
    }
}

namespace SweetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_Shop_Assignment
    {
        [Key]
        public int ItemShopID { get; set; }

        public int? ItemID { get; set; }

        public int? ShopID { get; set; }

        public virtual Item Item { get; set; }

        public virtual Shop Shop { get; set; }
    }
}

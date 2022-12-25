namespace SweetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_Shop_Assignment
    {
        [Key]
        public int CatShopID { get; set; }

        public int? CatFID { get; set; }

        public int? ShopFID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Shop Shop { get; set; }
    }
}

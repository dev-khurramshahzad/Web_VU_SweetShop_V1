namespace SweetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? CatFID { get; set; }

        public int? ShopFID { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime MFGDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EXPDate { get; set; }

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int Quantity { get; set; }

        public int? Rating { get; set; }

        [StringLength(250)]
        public string Details { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Category Category { get; set; }

        public virtual Shop Shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

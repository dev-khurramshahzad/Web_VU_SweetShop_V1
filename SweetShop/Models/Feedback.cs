namespace SweetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback
    {
        public int FeedBackID { get; set; }

        public int? ShopFID { get; set; }

        public int? UserFID { get; set; }

        [Required]
        [StringLength(50)]
        public string FeedbackType { get; set; }

        [Required]
        [StringLength(400)]
        public string Message { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual User User { get; set; }
    }
}

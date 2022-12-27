using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetShop.ViewModels
{
    public class OrderSearchModel
    {
        public string Store { get; set; }
        public string Status { get; set; }
        public DateTime ?  DateFrom { get; set; }
        public DateTime ?  DateTo { get; set; }
    }
}
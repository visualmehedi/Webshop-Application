using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewtonWebShop.Models
{
    public class OrderItem
    {
        [Key]
        public int IrderItemID { get; set; }
        public string OrderItemProductNumber { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemDescription { get; set; }
        public decimal OrderItemPrice { get; set; }
        public int OrderCount { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

    }
}
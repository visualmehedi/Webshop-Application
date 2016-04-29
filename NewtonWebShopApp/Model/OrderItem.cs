using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase;

namespace NewtonWebShopApp.Model
{
    public class OrderItem : PropertyChangedBase
    {
        public string OrderItemProductNumber { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemDescription { get; set; }
        public decimal OrderItemPrice { get; set; }
        private int ordercount;
        public int OrderCount
        {
            get
            {
                return ordercount;
            }
            set
            {
                ordercount = value;
                OnPropertyChanged();
            }
        }
    }
}

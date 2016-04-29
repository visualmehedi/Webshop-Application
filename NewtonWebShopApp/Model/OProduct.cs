using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase;
using NewtonWebShopApp.Service;
using System.Diagnostics;

namespace NewtonWebShopApp.Model
{
    public class OProduct : PropertyChangedBase
    {
        private OrderService service = new OrderService();
        private int ordercount;
        public int OrderCount
        {
            get
            {
                return ordercount;
            }
            set
            {
                this.ordercount = ordercount + value;
                Debug.WriteLine("COUNT IN OPRODUCT: " + ordercount.ToString());
                service.ProcessOrder(product);
                setStock();
                OnPropertyChanged();
            }
        }

        private void setStock()
        {
            if(product.Stock >= 5)
            {
                stockdisplay.StockString = "I lager";
                stockdisplay.StockBGColor = "#00FF00";
            }
            else if(product.Stock > 0)
            {
                stockdisplay.StockString = "<5 i lager";
                stockdisplay.StockBGColor = "#FF8000";
            }
            else
            {
                stockdisplay.StockString = "Slut";
                stockdisplay.StockBGColor = "#FF0000";
            }
        }

        public Product _product { get; set; }
        public Product product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                _product.ProductImagePath = "Assets/" + value.ProductImagePath;
                //OnPropertyChanged();
            }
        }
        public StockDisplay stockdisplay { get; set; }

        public OProduct()
        {
            stockdisplay = new StockDisplay();
        }
    }
}

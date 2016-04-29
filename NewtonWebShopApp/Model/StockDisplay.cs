using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase;

namespace NewtonWebShopApp.Model
{
    public class StockDisplay : PropertyChangedBase
    {
        private string stockstring;
        public string StockString
        {
            get
            {
                return stockstring;
            }
            set
            {
                stockstring = value;
                OnPropertyChanged();
            }
        }
        private string stockbgcolor;
        public string StockBGColor
        {
            get
            {
                return stockbgcolor;
            }
            set
            {
                stockbgcolor = value;
                OnPropertyChanged();
            }
        }
    }
}

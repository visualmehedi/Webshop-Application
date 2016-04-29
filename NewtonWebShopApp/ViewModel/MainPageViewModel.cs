using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonWebShopApp.Model;

namespace NewtonWebShopApp.ViewModel
{
    public class MainPageViewModel
    {
        public Repository WebRepository { get; set; }

        public MainPageViewModel()
        {
            WebRepository = Repository.Instance;
        }
    }
}

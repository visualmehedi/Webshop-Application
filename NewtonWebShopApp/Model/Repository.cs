using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using ViewModelBase;
using System.Diagnostics;

namespace NewtonWebShopApp.Model
{
    public class Repository : PropertyChangedBase
    {
        //private string localUri = "http://localhost:20710/";
        private string remoteUri = "http://webappshop.azurewebsites.net/";
        //private const string MODE = "REMOTE";
        private static Repository instance = new Repository();
        public static Repository Instance
        {
            get
            {
                return instance;
            }
        }

        //private ObservableCollection<OrderItem> orderitems = new ObservableCollection<OrderItem>();
        private ObservableCollection<OrderItem> orderitems;// = new ObservableCollection<OrderItem>(new List<OrderItem>() { new OrderItem() { OrderItemName="TEST", OrderItemDescription="DESCRIPTION", OrderItemPrice=230m, OrderCount=0} });
        public ObservableCollection<OrderItem> OrderItems
        {
            get
            {
                return orderitems;
            }
            set
            {
                orderitems = value;
                /*Debug.WriteLine("ORDER ITEMS (" + orderitems.Count.ToString() + ")");
                for (int i = 0; i < orderitems.Count; i++ )
                {
                    Debug.WriteLine("Item: " + orderitems[i].OrderItemName + ", Count: " + orderitems[i].OrderCount.ToString());
                }*/
                OnPropertyChanged();
            }
        }

        //public List<Product> Products { get; set; }
        private ObservableCollection<OProduct> oproducts;
        public ObservableCollection<OProduct> OProducts
        {
            get
            {
                return oproducts;
            }
            set
            {
                oproducts = value;
                OnPropertyChanged();
            }
        }

        private string orderref;
        public string OrderRef
        {
            get
            {
                return orderref;
            }
            set
            {
                orderref = value;
                OnPropertyChanged();
            }
        }
        private decimal total;
        public decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }

        public Repository()
        {
            /*if (MODE == "LOCAL")
            {
                //List<Product> localProduct = new List<Product>() { new Product(){ProductName="TSHIRT", Price=120m,ProductDescription="TSHIIIIRT", ProductImagePath="", ProductNumber="123"},
                //new Product(){ProductName="DOG", Price=3000m, ProductDescription="DOOOOOOOG", ProductImagePath="", ProductNumber="124"}};
                List<OProduct> localOProduct = new List<OProduct>() { new OProduct(){product=new Product(){ProductName="TSHIRT", Price=120m,ProductDescription="TSHIIIIRT", ProductImagePath="", ProductNumber="123"}, OrderCount=1},
                new OProduct(){product=new Product(){ProductName="DOG", Price=3000m, ProductDescription="DOOOOOOOG", ProductImagePath="", ProductNumber="124"}, OrderCount=2}};
                OProducts = new ObservableCollection<OProduct>(localOProduct);
                OrderItems = new ObservableCollection<OrderItem>(new List<OrderItem>() { new OrderItem() { OrderItemName="TEST", OrderItemDescription="DESCRIPTION", OrderItemPrice=230m, OrderCount=0} });
            }*/
            //else if(MODE == "REMOTE")
           //{
                Initialize();
            //}
        }

        private async void Initialize()
        {
            //OrderItems = new ObservableCollection<OrderItem>();
            OrderItems = new ObservableCollection<OrderItem>();//new List<OrderItem>() { new OrderItem() { OrderItemName="tSHIT", OrderItemDescription="TSSHIRTT", OrderItemPrice=87m, OrderCount=0, OrderItemProductNumber="1245"} });
            var productlist = await GetProducts();
            OProducts = new ObservableCollection<OProduct>(productlist);
        }

        private async Task<List<OProduct>> GetProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(remoteUri);
            HttpResponseMessage response = await client.GetAsync("api/ProductsApi");
            List<Product> products = await response.Content.ReadAsAsync<List<Product>>();
            var oproducts = products.Select(p => new OProduct() { product = p }).ToList<OProduct>();
            return oproducts;
        }

        public async void SaveOrder(Order order)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(remoteUri);
            await client.PostAsJsonAsync<Order>("api/OrdersApi", order);
        }
    }
}

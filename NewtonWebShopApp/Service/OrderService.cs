using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonWebShopApp.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace NewtonWebShopApp.Service
{
    public class OrderService
    {
        public void ProcessOrder(Product product)
        {
            OrderItem order = new OrderItem();
            order.OrderItemName = product.ProductName;
            order.OrderItemDescription = product.ProductDescription;
            order.OrderItemPrice = product.Price;
            order.OrderItemProductNumber = product.ProductNumber;

            if(Repository.Instance.OrderItems.Count > 0)
            {
                var doublecount = Repository.Instance.OrderItems.Where(i => i.OrderItemProductNumber == product.ProductNumber).Count();

                if(doublecount != 0)
                {
                    //Repository.Instance.OrderItems.Where(i => i.OrderItemProductNumber == product.ProductNumber).First().OrderCount++;
                    ObservableCollection<OrderItem> currentItems = Repository.Instance.OrderItems;
                    for(int i = 0; i < currentItems.Count; i++)
                    {
                        if(currentItems[i].OrderItemProductNumber == product.ProductNumber)
                        {
                            currentItems[i].OrderCount++;
                            break;
                        }
                    }
                    Repository.Instance.OrderItems = currentItems;
                }
                else
                {
                    ObservableCollection<OrderItem> currentItems = Repository.Instance.OrderItems;
                    order.OrderCount = 1;
                    currentItems.Add(order);
                    Repository.Instance.OrderItems = currentItems;
                    //Repository.Instance.OrderItems.Add(order);
                }
            }
            else
            {
                order.OrderCount = 1;
                //Repository.Instance.OrderItems.Add(order);
                ObservableCollection<OrderItem> currentItems = Repository.Instance.OrderItems;
                currentItems.Add(order);
                Repository.Instance.OrderItems = currentItems;
                /*Debug.WriteLine("First Order Item Added:");
                for (int i = 0; i < Repository.Instance.OrderItems.Count; i++ )
                {
                    Debug.WriteLine("OI name: " + Repository.Instance.OrderItems[i].OrderItemName + ", Count: " + Repository.Instance.OrderItems[i].OrderCount.ToString());
                }*/
                //order.OrderCount = 1;
            }

            Repository.Instance.Total = Repository.Instance.OrderItems.Sum(i => i.OrderItemPrice * i.OrderCount);
        }

        public void CheckoutOrder()
        {
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderPrice = Repository.Instance.Total;
            order.OrderRef = Repository.Instance.OrderRef;
            order.OrderItems = Repository.Instance.OrderItems.ToList<OrderItem>();

            Repository.Instance.SaveOrder(order);
            Repository.Instance.OrderItems.Clear();
            Repository.Instance.Total = 0;
            Repository.Instance.OrderRef = "";
        }
    }
}

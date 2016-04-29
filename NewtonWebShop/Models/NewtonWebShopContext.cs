﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewtonWebShop.Models;

namespace NewtonWebShop.Models
{
    public class NewtonWebShopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public NewtonWebShopContext() : base("name=NewtonWebShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<NewtonWebShop.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<NewtonWebShop.Models.OrderItem> OrderItems { get; set; }
    
    }
}

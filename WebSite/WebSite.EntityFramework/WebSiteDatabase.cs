using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.EntityFramework
{
    public class WebSiteDatabase : DbContext
    {
        public WebSiteDatabase() : base("WebSizeDataBaseConnectionString") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

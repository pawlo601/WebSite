using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.EntityFramework;

namespace WebSite.Data.EntityFramework
{
    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class WebSiteDatabase : DbContext
    {
        private static string cs = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=WebSiteDatabasa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public WebSiteDatabase() : base(cs) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PositionInTheOrder> PositionInTheOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

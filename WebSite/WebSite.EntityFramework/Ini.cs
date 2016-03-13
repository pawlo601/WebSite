using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.Data.EntityFramework;

namespace WebSite.EntityFramework
{
    public class Ini : System.Data.Entity.DropCreateDatabaseAlways<WebSiteDatabase>
    {
        protected override void Seed(WebSiteDatabase context)
        {
            var products = new List<Product>()
            {
                new Product() {ProductName="Produkt1", ProductDescription="Opis produktu1",PricePerUnit=12.34M, QuantityPerUnit=1234.45F  },
                new Product() {ProductName="Produkt2", ProductDescription="Opis produktu2",PricePerUnit=42.34M, QuantityPerUnit=1834.45F  },
                new Product() {ProductName="Produkt3", ProductDescription="Opis produktu3",PricePerUnit=62.34M, QuantityPerUnit=1634.45F  },
                new Product() {ProductName="Produkt4", ProductDescription="Opis produktu4",PricePerUnit=72.34M, QuantityPerUnit=184.45F  },
                new Product() {ProductName="Produkt5", ProductDescription="Opis produktu5",PricePerUnit=82.34M, QuantityPerUnit=1934.45F  },
            };
            products.ForEach(a => context.Products.Add(a));
            context.SaveChanges();
        }
    }
}

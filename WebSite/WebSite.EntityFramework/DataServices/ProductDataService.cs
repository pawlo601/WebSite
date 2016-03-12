using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.Data.Interfaces;
using System.Linq.Dynamic;

namespace WebSite.Data.EntityFramework.DataServices
{
    public class ProductDataService : EntityFrameworkService, IProductDataService
    {
        public void CreateProduct(Product product)
        {
            dbConnection.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            dbConnection.Products.Remove(product);
        }

        public Product GetProduct(int productID)
        {
            return dbConnection.Products.Where(p => p.ProductID == productID).FirstOrDefault();
        }

        public IList<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            totalRows = 0;
            sortExpression = sortExpression + " " + sortDirection;
            totalRows = dbConnection.Products.Count();
            List<Product> customers = dbConnection.Products.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
            return customers;
        }

        public void UpdateProduct(Product product)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.Data.Interfaces;

namespace WebSite.Data.EntityFramework.DataServices
{
    public class ProductDataService : EntityFrameworkService, IProductDataService
    {
        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using CodeProject.Interfaces;
using System.Collections.Generic;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Interfaces
{
    public interface IProductDateService: IDataRepository, IDisposable
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        Product GetProduct(int productID);
        void DeleteProduct(Product product);
        IList<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection,string filter, out int totalRows);
    }
}

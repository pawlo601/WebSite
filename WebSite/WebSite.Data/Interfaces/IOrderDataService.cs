using System;
using System.Collections.Generic;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Interfaces
{
    public interface IOrderDataService: IDataRepository, IDisposable
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrder(int orderid);
        IList<Order> GetOrders(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows);
    }
}

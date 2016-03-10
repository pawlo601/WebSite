﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Interfaces
{
    public interface IOrderDataService
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrder(int orderid);
        IList<Order> GetOrders(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows);
    }
}

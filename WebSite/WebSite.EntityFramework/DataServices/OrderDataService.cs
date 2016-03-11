using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.Data.Interfaces;

namespace WebSite.Data.EntityFramework.DataServices
{
    public class OrderDataService : EntityFrameworkService, IOrderDataService
    {
        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderid)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetOrders(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

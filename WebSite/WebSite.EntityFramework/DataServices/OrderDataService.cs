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
    public class OrderDataService : EntityFrameworkService, IOrderDataService
    {
        public void CreateOrder(Order order)
        {
            dbConnection.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            dbConnection.Orders.Remove(order);
        }

        public Order GetOrder(int orderid)
        {
            return dbConnection.Orders.Where(p=>p.OrderID==orderid).FirstOrDefault();
        }

        public IList<Order> GetOrders(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            totalRows = 0;
            sortExpression = sortExpression + " " + sortDirection;
            totalRows = dbConnection.Orders.Count();
            List<Order> customers = dbConnection.Orders.OrderBy(sortExpression).Skip((currentPageNumber - 1) * pageSize).Take(pageSize).ToList();
            return customers;
        }

        public void UpdateOrder(Order order)
        {
            
        }
    }
}

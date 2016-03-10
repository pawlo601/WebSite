using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Common;
using WebSite.Data.Business.Entities;
using WebSite.Data.Business.Rules;
using WebSite.Data.Interfaces;

namespace WebSite.Data.Business.Services
{
    public class OrderBusinessService
    {
        private IOrderDataService _orderDataService;
        public OrderBusinessService(IOrderDataService orderDataService)
        {
            _orderDataService = orderDataService;
        }
        public Order CreateOrder(Order order, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _orderDataService.CreateSession();
                _orderDataService.BeginTransaction();
                _orderDataService.CreateOrder(order);
                _orderDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Order successfully created.");
            }
            catch (Exception ex)
            {
                _orderDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _orderDataService.CloseSession();
            }
            return order;
        }
        public void UpdateOrder(Order order, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _orderDataService.CreateSession();
                _orderDataService.BeginTransaction();

                Order existingOrder = _orderDataService.GetOrder(order.OrderID);
                existingOrder.DateOfSubmission = order.DateOfSubmission;
                existingOrder.Status = existingOrder.Status;
                existingOrder.OrderedItems = existingOrder.OrderedItems;

                _orderDataService.UpdateOrder(order);
                _orderDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Order was successfully updated.");

            }
            catch (Exception ex)
            {
                _orderDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _orderDataService.CloseSession();
            }
        }
        public Order GetOrder(int orderID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            Order order = new Order();
            try
            {
                _orderDataService.CreateSession();
                order = _orderDataService.GetOrder(orderID);
                _orderDataService.CloseSession();
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _orderDataService.CloseSession();
            }
            return order;
        }
        public void DeleteOrder(Order order, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _orderDataService.CreateSession();
                _orderDataService.BeginTransaction();
                _orderDataService.DeleteOrder(order);
                _orderDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Order successfully deleted.");
            }
            catch (Exception ex)
            {
                _orderDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _orderDataService.CloseSession();
            }
        }
        public IList<Order> GetOrders(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IList<Order> products = new List<Order>();
            try
            {
                int totalRows;
                _orderDataService.CreateSession();
                products = _orderDataService.GetOrders(currentPageNumber, pageSize, sortExpression, sortDirection, filter, out totalRows);
                _orderDataService.CloseSession();
                transaction.TotalPages = Utilities.CalculateTotalPages(totalRows, pageSize);
                transaction.TotalRows = totalRows;
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _orderDataService.CloseSession();
            }
            return products;
        }
    }
}

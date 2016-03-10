using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Data.Business.Entities
{
    public class PositionInTheOrder
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public decimal Quantity { get; set; }

        public PositionInTheOrder(int productID, int customerID, int quantity)
        {
            ProductID = productID;
            CustomerID = customerID;
            Quantity = quantity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Data.Business.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string Status { get; set; }
        public Customer Client { get; set; }
        public List<PositionInTheOrder> OrderedItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Data.Business.Entities
{
    public abstract class Customer
    {
        public int CustomerID { get; set; }
        public string ContactTitle { get; set; }
        public Address ContactAddress { get; set; }
        public Address ResresidentialAddress { get; set; }
        public string Mail1 { get; set; }
        public string Phone1 { get; set; }
        public string Mail2 { get; set; }
        public string Phone2 { get; set; }
    }
}

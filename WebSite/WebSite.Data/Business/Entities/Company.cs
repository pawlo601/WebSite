using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Data.Business.Entities
{
    public class Company:Customer
    {
        public string CompanyName { get; set; }
        public string REGON { get; set; }
        public string TaxID { get; set; }
    }
}

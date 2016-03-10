using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Data.Business.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public string Status { get; set; }
        public Customer Client { get; set; }
        public List<PositionInTheOrder> OrderedItems { get; set; }
    }
}

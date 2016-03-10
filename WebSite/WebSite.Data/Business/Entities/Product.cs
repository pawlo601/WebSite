using System.ComponentModel.DataAnnotations;

namespace WebSite.Data.Business.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float QuantityPerUnit { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}

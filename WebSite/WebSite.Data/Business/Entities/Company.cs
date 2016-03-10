namespace WebSite.Data.Business.Entities
{
    public class Company : Customer
    {
        public string CompanyName { get; set; }
        public string REGON { get; set; }
        public string TaxID { get; set; }
    }
}

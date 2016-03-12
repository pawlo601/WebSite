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
    public class CustomerDataService : EntityFrameworkService, ICustomerDataService
    {
        public void CreateCompany(Company company)
        {
            dbConnection.Customers.Add(company);
        }

        public void CreateIndividualClient(IndividualClient client)
        {
            dbConnection.Customers.Add(client);
        }

        public void DeleteCompany(Company company)
        {
            dbConnection.Customers.Remove(company);
        }

        public void DeleteIndividualClient(IndividualClient client)
        {
            dbConnection.Customers.Remove(client);
        }

        public IList<Company> GetCompanies(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            List<Company> list = new List<Company>();
            totalRows = 0;
            return list;
        }

        public Company GetCompany(int compayid)
        {
            return (Company)dbConnection.Customers.Where(p => p.CustomerID == compayid).FirstOrDefault();
        }

        public IndividualClient GetIndividualClient(int clientid)
        {
            return (IndividualClient)dbConnection.Customers.Where(p => p.CustomerID == clientid).FirstOrDefault();
        }

        public IList<IndividualClient> GetIndividualClients(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            List<IndividualClient> list = new List<IndividualClient>();
            totalRows = 0;
            return list;
        }

        public void UpdateCompany(Company compay)
        {

        }

        public void UpdateIndividualClient(IndividualClient client)
        {

        }
    }
}

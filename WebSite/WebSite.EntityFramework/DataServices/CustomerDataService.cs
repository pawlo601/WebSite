using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;
using WebSite.Data.Interfaces;

namespace WebSite.Data.EntityFramework.DataServices
{
    public class CustomerDataService : EntityFrameworkService, ICustomerDataService
    {
        public void CreateCompany(Company compay)
        {
            throw new NotImplementedException();
        }

        public void CreateIndividualClient(IndividualClient client)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(Company compay)
        {
            throw new NotImplementedException();
        }

        public void DeleteIndividualClient(IndividualClient client)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetCompanies(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int compayid)
        {
            throw new NotImplementedException();
        }

        public IndividualClient GetIndividualClient(int clientid)
        {
            throw new NotImplementedException();
        }

        public IList<IndividualClient> GetIndividualClients(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompany(Company compay)
        {
            throw new NotImplementedException();
        }

        public void UpdateIndividualClient(IndividualClient client)
        {
            throw new NotImplementedException();
        }
    }
}

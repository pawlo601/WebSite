using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Interfaces
{
    public interface ICustomerDateService
    {
        void CreateIndividualClient(IndividualClient client);
        void CreateCompany(Company compay);
        void UpdateIndividualClient(IndividualClient client);
        void UpdateCompany(Company compay);
        void DeleteIndividualClient(IndividualClient client);
        void DeleteCompany(Company compay);
        IndividualClient GetIndividualClient(int clientid);
        Company GetCompany(int compayid);
        IList<IndividualClient> GetIndividualClients(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows);
        IList<Company> GetCompanies(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out int totalRows);
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Data.Business.Common;
using WebSite.Data.Business.Entities;
using WebSite.Data.Business.Rules;
using WebSite.Data.Interfaces;

namespace WebSite.Data.Business.Services
{
    public class CustomerBusinessService
    {
        private ICustomerDataService _customerDataService;

        public CustomerBusinessService(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }
        public Company CreateCompany(Company company, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                CompanyRule rules = new CompanyRule();
                var result = rules.Validate(company);
                AddressRule rules2 = new AddressRule();
                var result2 = rules2.Validate(company.ContactAddress);
                AddressRule rules3 = new AddressRule();
                var result3 = rules3.Validate(company.ResresidentialAddress);

                bool validationSucceeded = result.IsValid& result2.IsValid& result.IsValid;
                var a = result2.Errors.Concat(result3.Errors);
                IList<ValidationFailure> failures = result.Errors.Concat(a).ToList();

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return company;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.CreateCompany(company);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Company successfully created.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return company;
        }
        public IndividualClient CreateIndividualClient(IndividualClient individualClient, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                IndividualClientRule rules = new IndividualClientRule();
                var result = rules.Validate(individualClient);
                AddressRule rules2 = new AddressRule();
                var result2 = rules2.Validate(individualClient.ContactAddress);
                AddressRule rules3 = new AddressRule();
                var result3 = rules3.Validate(individualClient.ResresidentialAddress);

                bool validationSucceeded = result.IsValid & result2.IsValid & result.IsValid;
                var a = result2.Errors.Concat(result3.Errors);
                IList<ValidationFailure> failures = result.Errors.Concat(a).ToList();

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return individualClient;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.CreateIndividualClient(individualClient);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Company successfully created.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return individualClient;
        }
        public void UpdateCompany(Company company, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                CompanyRule rules = new CompanyRule();
                var result = rules.Validate(company);
                AddressRule rules2 = new AddressRule();
                var result2 = rules2.Validate(company.ContactAddress);
                AddressRule rules3 = new AddressRule();
                var result3 = rules3.Validate(company.ResresidentialAddress);

                bool validationSucceeded = result.IsValid & result2.IsValid & result.IsValid;
                var a = result2.Errors.Concat(result3.Errors);
                IList<ValidationFailure> failures = result.Errors.Concat(a).ToList();

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();

                Company existingCompany = _customerDataService.GetCompany(company.CustomerID);
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.ContactTitle = company.ContactTitle;
                existingCompany.Mail1 = company.Mail1;
                existingCompany.Mail2 = company.Mail2;
                existingCompany.Phone1 = company.Phone1;
                existingCompany.Phone2 = company.Phone2;
                existingCompany.REGON = company.REGON;
                existingCompany.TaxID = company.TaxID;
                existingCompany.ResresidentialAddress = company.ResresidentialAddress;
                existingCompany.ContactAddress = company.ContactAddress;

                _customerDataService.UpdateCompany(company);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Company was successfully updated.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
        }
        public void UpdateIndividualClient(IndividualClient individualClient, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                IndividualClientRule rules = new IndividualClientRule();
                var result = rules.Validate(individualClient);
                AddressRule rules2 = new AddressRule();
                var result2 = rules2.Validate(individualClient.ContactAddress);
                AddressRule rules3 = new AddressRule();
                var result3 = rules3.Validate(individualClient.ResresidentialAddress);

                bool validationSucceeded = result.IsValid & result2.IsValid & result.IsValid;
                var a = result2.Errors.Concat(result3.Errors);
                IList<ValidationFailure> failures = result.Errors.Concat(a).ToList();

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return;
                }

                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();

                IndividualClient existingindividualClient = _customerDataService.GetIndividualClient(individualClient.CustomerID);
                existingindividualClient.ContactTitle = individualClient.ContactTitle;
                existingindividualClient.Mail1 = individualClient.Mail1;
                existingindividualClient.Mail2 = individualClient.Mail2;
                existingindividualClient.Phone1 = individualClient.Phone1;
                existingindividualClient.Phone2 = individualClient.Phone2;
                existingindividualClient.ResresidentialAddress = individualClient.ResresidentialAddress;
                existingindividualClient.ContactAddress = individualClient.ContactAddress;
                existingindividualClient.Birthday = individualClient.Birthday;
                existingindividualClient.Name = individualClient.Name;
                existingindividualClient.Surname = individualClient.Surname;
                existingindividualClient.PeselNumber = individualClient.PeselNumber;

                _customerDataService.UpdateIndividualClient(individualClient);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Individual client was successfully updated.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
        }
        public Company GetCompany(int companyID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            Company company = new Company();
            try
            {
                _customerDataService.CreateSession();
                company = _customerDataService.GetCompany(companyID);
                _customerDataService.CloseSession();
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return company;
        }
        public IndividualClient GetIndividualClient(int individualClientID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IndividualClient individualClient = new IndividualClient();
            try
            {
                _customerDataService.CreateSession();
                individualClient = _customerDataService.GetIndividualClient(individualClientID);
                _customerDataService.CloseSession();
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return individualClient;
        }
        public void DeleteCompany(Company company, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.DeleteCompany(company);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Company successfully deleted.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
        }
        public void DeleteIndividualClient(IndividualClient individualClient, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _customerDataService.CreateSession();
                _customerDataService.BeginTransaction();
                _customerDataService.DeleteIndividualClient(individualClient);
                _customerDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Individual client successfully deleted.");
            }
            catch (Exception ex)
            {
                _customerDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
        }
        public IList<Company> GetCompanies(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IList<Company> companies = new List<Company>();
            try
            {
                int totalRows;
                _customerDataService.CreateSession();
                companies = _customerDataService.GetCompanies(currentPageNumber, pageSize, sortExpression, sortDirection, filter, out totalRows);
                _customerDataService.CloseSession();
                transaction.TotalPages = Utilities.CalculateTotalPages(totalRows, pageSize);
                transaction.TotalRows = totalRows;
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return companies;
        }
        public IList<IndividualClient> GetIndividualClients(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IList<IndividualClient> individualClients = new List<IndividualClient>();
            try
            {
                int totalRows;
                _customerDataService.CreateSession();
                individualClients = _customerDataService.GetIndividualClients(currentPageNumber, pageSize, sortExpression, sortDirection, filter, out totalRows);
                _customerDataService.CloseSession();
                transaction.TotalPages = Utilities.CalculateTotalPages(totalRows, pageSize);
                transaction.TotalRows = totalRows;
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _customerDataService.CloseSession();
            }
            return individualClients;
        }
    }
}

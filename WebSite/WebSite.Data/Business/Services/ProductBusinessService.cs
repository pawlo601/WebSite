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
    public class ProductBusinessService
    {
        private IProductDataService _productDataService;
        public ProductBusinessService(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }
        public Product CreateProduct(Product product, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                ProductRules rules = new ProductRules();
                var result = rules.Validate(product);

                bool validationSucceeded = result.IsValid;
                IList<ValidationFailure> failures = result.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return product;
                }

                _productDataService.CreateSession();
                _productDataService.BeginTransaction();
                _productDataService.CreateProduct(product);
                _productDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Product successfully created.");
            }
            catch (Exception ex)
            {
                _productDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }
            return product;
        }
        public void UpdateProduct(Product product, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                ProductRules productBusinessRules = new ProductRules();
                ValidationResult results = productBusinessRules.Validate(product);
                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded == false)
                {
                    transaction = ValidationErrors.PopulateValidationErrors(failures);
                    return;
                }

                _productDataService.CreateSession();
                _productDataService.BeginTransaction();

                Product existingProduct = _productDataService.GetProduct(product.ProductID);
                existingProduct.ProductName = product.ProductName;
                existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.PricePerUnit = product.PricePerUnit;

                _productDataService.UpdateProduct(product);
                _productDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Product was successfully updated.");

            }
            catch (Exception ex)
            {
                _productDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }
        }
        public Product GetProduct(int productID, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            Product product = new Product();
            try
            {
                _productDataService.CreateSession();
                product = _productDataService.GetProduct(productID);
                _productDataService.CloseSession();
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
                _productDataService.CloseSession();
            }
            return product;
        }
        public void DeleteProduct(Product product, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                _productDataService.CreateSession();
                _productDataService.BeginTransaction();
                _productDataService.DeleteProduct(product);
                _productDataService.CommitTransaction(true);

                transaction.ReturnStatus = true;
                transaction.ReturnMessage.Add("Product successfully deleted.");
            }
            catch (Exception ex)
            {
                _productDataService.RollbackTransaction(false);
                string errorMessage = ex.Message;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnStatus = false;
            }
            finally
            {
                _productDataService.CloseSession();
            }
        }
        public IList<Product> GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, string filter, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            IList<Product> products = new List<Product>();
            try
            {
                int totalRows;
                _productDataService.CreateSession();
                products = _productDataService.GetProducts(currentPageNumber, pageSize, sortExpression, sortDirection, filter, out totalRows);
                _productDataService.CloseSession();
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
                _productDataService.CloseSession();
            }
            return products;
        }
    }
}

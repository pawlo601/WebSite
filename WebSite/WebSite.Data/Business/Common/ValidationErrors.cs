using FluentValidation.Results;
using System.Collections.Generic;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Business.Common
{
    public static class ValidationErrors
    {
        public static TransactionalInformation PopulateValidationErrors(IList<ValidationFailure> failures)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            transaction.ReturnStatus = false;
            foreach (ValidationFailure error in failures)
            {
                if (transaction.ValidationErrors.ContainsKey(error.PropertyName) == false)
                    transaction.ValidationErrors.Add(error.PropertyName, error.ErrorMessage);

                transaction.ReturnMessage.Add(error.ErrorMessage);
            }

            return transaction;

        }
    }
}

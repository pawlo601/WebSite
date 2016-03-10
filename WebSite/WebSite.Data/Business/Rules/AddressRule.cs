using FluentValidation;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Business.Rules
{
    public class AddressRule : AbstractValidator<Address>
    {
        public AddressRule()
        {
            RuleFor(p => p.Street).NotEmpty().WithMessage("Name of street is required.");
            RuleFor(p => p.Building).NotEmpty().WithMessage("Name of street is required.");
            RuleFor(p => p.City).NotEmpty().WithMessage("Name of city is required.");
            RuleFor(p => p.PostalCode).NotEmpty().WithMessage("Postal code is required.");
            RuleFor(p => p.Country).NotEmpty().WithMessage("Name of country is required.");
        }
    }
}

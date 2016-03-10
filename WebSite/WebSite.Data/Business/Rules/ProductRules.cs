using FluentValidation;
using WebSite.Data.Business.Entities;

namespace WebSite.Data.Business.Rules
{
    public class ProductRules: AbstractValidator<Product>
    {
        public ProductRules()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(p=>p.PicePerUnit).GreaterThanOrEqualTo(0).WithMessage("Price has to be greater or equal 0.");
            RuleFor(p=>p.QuantityPerUnit).GreaterThanOrEqualTo(0).WithMessage("Quantity has to be greater or equal 0.");
        }
    }
}

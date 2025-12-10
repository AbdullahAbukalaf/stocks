using api.DTO.Stock;
using FluentValidation;

namespace api.Validation
{
    public class UpdateStockRequestValidator : AbstractValidator<UpdateStockDTO>
    {
        public UpdateStockRequestValidator() 
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Symbol is required.")
                .MaximumLength(10).WithMessage("Symbol cannot exceed 10 characters.")
                .When(x => x.Symbol != null);

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(100).WithMessage("Company Name cannot exceed 100 characters.")
                .When(x => x.CompanyName != null);

            RuleFor(x => x.Purchase)
                .GreaterThan(0).WithMessage("Purchase price must be greater than 0.")
                .When(x => x.Purchase.HasValue);

            RuleFor(x => x.LastDividend)
                .GreaterThanOrEqualTo(0).WithMessage("Last Dividend cannot be negative.")
                .When(x => x.LastDividend.HasValue);

            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required.")
                .MaximumLength(50).WithMessage("Industry cannot exceed 50 characters.")
                .When(x => x.Industry != null);

            RuleFor(x => x.MarketCap)
                .GreaterThanOrEqualTo(0).WithMessage("Market Cap cannot be negative.")
                .When(x => x.MarketCap.HasValue);
        }
    }
}

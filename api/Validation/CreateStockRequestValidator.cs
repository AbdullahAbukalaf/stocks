using api.DTO.Stock;
using FluentValidation;

namespace api.Validation
{
    public class CreateStockRequestValidator : AbstractValidator<CreateStockDTO>
    {
        public CreateStockRequestValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Symbol is required.")
                .MaximumLength(10).WithMessage("Symbol cannot exceed 10 characters.");
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(100).WithMessage("Company Name cannot exceed 100 characters.");
            RuleFor(x => x.Purchase)
                .GreaterThan(0).WithMessage("Purchase price must be greater than 0.");
            RuleFor(x => x.LastDividend)
                .GreaterThanOrEqualTo(0).WithMessage("Last Dividend cannot be negative.");
            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required.")
                .MaximumLength(50).WithMessage("Industry cannot exceed 50 characters.");
            RuleFor(x => x.MarketCap)
                .GreaterThanOrEqualTo(0).WithMessage("Market Cap cannot be negative.");
        }
    }
}

using api.DTO.Stock;
using api.Interfaces.StockServices;
using api.Repositories.StockRepository;
using api.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // Add your service registrations here
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockServices, StockServices>();
            // FluentValidation automatic validation + register validators from this assembly
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateStockRequestValidator>();
            // add services for the validation
            services.AddScoped<IValidator<CreateStockDTO>, CreateStockRequestValidator>();
            services.AddScoped<IValidator<UpdateStockDTO>, UpdateStockRequestValidator>();
            return services;
        }
    }
}

using Automation.Interfaces;
using Automation.Services;

namespace Automation.ServiceRegistration
{
    public static class DiRegisteration
    {
        public static IServiceCollection AddApplicationServices(
           this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IStockDetailsService, StockDetailsService>();


            return services;
        }
    }
}

using Automation.Interfaces;
using Automation.Interfaces.CustomerInterface;
using Automation.Services;
using Automation.Services.CustomerService;

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

using Assignment.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Application
{
    public static class DependecyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITransactionLogService, TransactionLogService>();
            services.AddScoped<IDataSeederService, DataSeederService>();

            return services;
        }
    }
}

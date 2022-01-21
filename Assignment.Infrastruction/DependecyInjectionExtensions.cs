using Assignment.Domain.Contracts;
using Assignment.Infrastruction.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Infrastruction
{
    public static class DependecyInjectionExtensions
    {
        /// <summary>
        ///  This is an extensions method to help inject the dependecies as we are uinsg depency inject framework 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<ITransactionLogRepository, TransactionLogRepository>();
            services.AddSingleton<IDateProvider, DateProvider>();

            services.AddDbContext<ApplicationDbContext>();
            return services;
        }
    }
}

using Assignment.Application;
using Assignment.Contracts;
using Assignment.Infrastruction;
using Assignment.IO;
using Assignment.Presentation;
using Assignment.Presentation.Actions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Builder
{
    public static class ApplicationHostBuilder
    {
        /// <summary>
        ///  This will inject all the dependencies and load connection string from appsetting and create an instance of 
        ///  ApplicationHost class witch is the starting point of our application
        /// </summary>
        /// <returns></returns>
        public static ApplicationHost Build()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            var serviceProvider = new ServiceCollection()
            .AddApplication()
            .AddInfrastructure(configuration)
            .AddScoped<ApplicationHost>()
            .AddScoped<IConsoleReader, ConsoleReader>()
            .AddScoped<IConsoleWriter, ConsoleWriter>()
            .AddScoped<IActionStrategy, ViewFinancialReportStrategy>()
            .AddScoped<IActionStrategy, ViewInventoryReportsStrategy>()
            .AddScoped<IActionStrategy, ViewPersonalUsageReportStrategy>()
            .AddScoped<IActionStrategy, ViewTransactionLogStrategy>()
            .AddScoped<IActionStrategy, AddItemToStockStrategy>()
            .AddScoped<IActionStrategy, AddQuantityToItemStrategy>()
            .AddScoped<IActionStrategy, TakeQuantityFromItemStrategy>()
            .AddScoped<IActionStrategy, NullStrategy>()
            .BuildServiceProvider();

            return serviceProvider.GetService<ApplicationHost>();
        }
    }
}

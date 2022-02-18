using Banking.Operation.Receipt.Consumer.Domain.Receipt.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IReceiptService, ReceiptService>();
        }
    }
}
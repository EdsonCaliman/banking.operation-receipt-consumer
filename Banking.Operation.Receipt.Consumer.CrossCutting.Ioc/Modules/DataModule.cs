using Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Repositories;
using Banking.Operation.Receipt.Consumer.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var kafkaParameters = configuration.GetSection("KafkaParameters").Get<KafkaParameters>();
            services.AddSingleton(kafkaParameters);

            services.AddScoped<IReceiptRepository, ReceiptRepository>();
        }
    }
}
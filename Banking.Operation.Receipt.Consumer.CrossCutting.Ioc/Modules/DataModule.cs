using Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters;
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
            var mongoParameters = configuration.GetSection("MongoDatabase").Get<MongoParameters>();
            services.AddSingleton(mongoParameters);

            //services.AddScoped<IRepository, Repository>();
        }
    }
}
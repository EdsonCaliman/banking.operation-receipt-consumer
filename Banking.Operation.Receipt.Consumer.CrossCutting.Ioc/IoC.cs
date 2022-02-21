using Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            MongoDbModule.Register(services, configuration);
            DataModule.Register(services, configuration);
            AutoMapperModule.Register(services);
            services.Register(configuration);

            return services;
        }
    }
}
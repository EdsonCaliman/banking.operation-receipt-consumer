using AutoMapper;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class AutoMapperModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(ConfigureMapping);
        }

        public static void ConfigureMapping(IMapperConfigurationExpression mapping)
        {
            mapping.DisableConstructorMapping();

            mapping.AddProfile<ReceiptProfile>();
        }
    }
}
using AutoMapper;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules
{
    public static class AutoMapperModule
    {
        public static void Register(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReceiptDto, ReceiptEntity>()
                .ForMember(d => d.Id, act => act.Ignore())
                .ForMember(d => d.ClientId, o => o.MapFrom(a => a.Id));
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
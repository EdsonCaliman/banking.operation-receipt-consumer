using AutoMapper;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Mapper
{
    public class ReceiptProfile : Profile
    {
        public ReceiptProfile()
        {
            CreateMap<ReceiptDto, ReceiptEntity>()
            .ForMember(d => d.Id, act => act.Ignore())
            .ForMember(d => d.ClientId, o => o.MapFrom(a => a.Id));
        }
    }
}
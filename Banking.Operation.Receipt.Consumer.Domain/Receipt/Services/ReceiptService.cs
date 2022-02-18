using AutoMapper;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IMapper _mapper;

        public ReceiptService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task ProcessAndSaveReceipt(ReceiptDto receipt)
        {
            var entity = _mapper.Map<ReceiptEntity>(receipt);

            return Task.CompletedTask;
        }
    }
}
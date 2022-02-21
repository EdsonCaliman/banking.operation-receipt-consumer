using AutoMapper;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReceiptService> _logger;

        public ReceiptService(
            IMapper mapper,
            IReceiptRepository receiptRepository,
            ILogger<ReceiptService> logger)
        {
            _mapper = mapper;
            _receiptRepository = receiptRepository;
            _logger = logger;
        }

        public async Task ProcessAndSaveReceipt(ReceiptDto receipt)
        {
            try
            {
                var entity = _mapper.Map<ReceiptEntity>(receipt);

                await _receiptRepository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on ProcessAndSaveReceipt");
                throw;
            }
        }
    }
}
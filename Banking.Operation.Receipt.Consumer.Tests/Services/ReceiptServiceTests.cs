using AutoMapper;
using Banking.Operation.Receipt.Consumer.CrossCutting.Ioc.Modules;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Repositories;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Tests.Services
{
    public class ReceiptServiceTests
    {
        private MapperConfiguration _mapperConfiguration;
        private IReceiptService _receiptService;
        private Mock<IReceiptRepository> _receiptRepository;
        private Mock<ILogger<ReceiptService>> _logger;

        [SetUp]
        public void SetUp()
        {
            _mapperConfiguration = new MapperConfiguration(AutoMapperModule.ConfigureMapping);
            _receiptRepository = new Mock<IReceiptRepository>();
            _logger = new Mock<ILogger<ReceiptService>>();

            _receiptService = new ReceiptService(_mapperConfiguration.CreateMapper(), _receiptRepository.Object, _logger.Object);
        }

        [Test]
        public async Task ProcessAndSaveReceipt_ShouldReturnSuccess_WhenReceiptIsValid()
        {
            var receipt = new ReceiptDto() { Id = Guid.NewGuid(), ClientName = "Test" };

            await _receiptService.ProcessAndSaveReceipt(receipt);
        }
    }
}
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Services;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConsumerConfig _consumerConfig;
        private readonly KafkaParameters _kafkaParameters;
        private readonly IReceiptService _receiptService;

        public Worker(
            ILogger<Worker> logger,
            KafkaParameters kafkaParameters,
            IReceiptService receiptService)
        {
            _logger = logger;
            _kafkaParameters = kafkaParameters;
            _receiptService = receiptService;
            _consumerConfig = new ConsumerConfig
            {
                GroupId = kafkaParameters.GroupId,
                BootstrapServers = kafkaParameters.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.Plaintext,
                EnableSslCertificateVerification = false
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            _logger.LogInformation(
                "Worker is started...");

            using (var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build())
            {
                consumer.Subscribe(_kafkaParameters.Topic);

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = consumer.Consume(stoppingToken);

                            var receipt = JsonSerializer.Deserialize<ReceiptDto>(cr.Message.Value);

                            await _receiptService.ProcessAndSaveReceipt(receipt);
                        }
                        catch (ConsumeException ex)
                        {
                            _logger.LogError(ex, $"Error occured");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }
        }
    }
}
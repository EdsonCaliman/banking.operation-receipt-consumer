using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters
{
    [ExcludeFromCodeCoverage]
    public class KafkaParameters
    {
        public string BootstrapServers { get; set; }
        public string Topic { get; set; }
        public string GroupId { get; set; }
    }
}
namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Parameters
{
    public class MongoParameters
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
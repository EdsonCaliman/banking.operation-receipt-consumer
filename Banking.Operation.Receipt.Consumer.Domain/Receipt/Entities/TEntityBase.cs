using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities
{
    public class TEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
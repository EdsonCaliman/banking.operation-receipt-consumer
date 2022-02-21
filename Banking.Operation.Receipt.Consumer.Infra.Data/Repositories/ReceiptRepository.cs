using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using Banking.Operation.Receipt.Consumer.Domain.Receipt.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Infra.Data.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        protected IMongoCollection<ReceiptEntity> Collection { get; private set; }

        protected ReceiptRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<ReceiptEntity>(collectionName);
        }

        public async Task AddAsync(ReceiptEntity entity)
        {
            await Collection.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<ReceiptEntity>> GetAllAsync()
        {
            return await Collection.Find(m => true).ToListAsync();
        }
    }
}
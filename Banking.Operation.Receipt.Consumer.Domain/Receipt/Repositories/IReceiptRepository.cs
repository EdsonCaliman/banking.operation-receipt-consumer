using Banking.Operation.Receipt.Consumer.Domain.Receipt.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Repositories
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<ReceiptEntity>> GetAllAsync();

        Task AddAsync(ReceiptEntity entity);
    }
}
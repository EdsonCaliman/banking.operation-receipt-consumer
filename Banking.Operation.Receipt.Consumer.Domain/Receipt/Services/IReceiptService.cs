using Banking.Operation.Receipt.Consumer.Domain.Receipt.Dtos;
using System.Threading.Tasks;

namespace Banking.Operation.Receipt.Consumer.Domain.Receipt.Services
{
    public interface IReceiptService
    {
        Task ProcessAndSaveReceipt(ReceiptDto receipt);
    }
}
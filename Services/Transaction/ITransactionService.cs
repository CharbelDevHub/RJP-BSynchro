using RJP.Models;

namespace RJP.Services;

public interface ITransactionService {
    void CreateTransaction(Account account, decimal amount);
}
using RJP.Models;

namespace RJP.Services;

public class TransactionService : ITransactionService
{
    private readonly DataDbContext _context;
    
    public TransactionService(DataDbContext dataDbContext){
        _context = dataDbContext;
    }
    public void CreateTransaction(Account account, decimal amount)
    {
        var transaction = new Transaction
        {
            AccountID = account.Id,
            Amount = amount,
            Date = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        account.Amount += amount;
        _context.SaveChanges();

    }
}
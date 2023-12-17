using RJP.Models;

namespace RJP.Services;

public class AccountService : IAccountService
{
    private readonly DataDbContext _context;

    public AccountService(DataDbContext dataDbContext){
        _context = dataDbContext;
    }

    public Account CreateAccount(Customer customer, decimal initialCredit)
    {
        var account = new Account
        {
            CustomerId = customer.Id ,
            Amount = initialCredit
        };

        _context.Accounts.Add(account);
        _context.SaveChanges();
        return account;
    }

    
}


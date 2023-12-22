using System.Linq;
using Microsoft.EntityFrameworkCore;
using RJP.Exceptions;
using RJP.Models;
using RJP.Responses;

namespace RJP.Services;

public class CustomerService : ICustomerService
{   
    private readonly DataDbContext _context;
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;
    public CustomerService(DataDbContext dataDbContext, IAccountService accountService,ITransactionService transactionService){
        _context = dataDbContext;
        _accountService = accountService;
        _transactionService = transactionService;
    }

    public CustomerInformationResponse GetAccountInfo(int customerId)
    {
        return _context.Customers
            .Where(c => c.Id == customerId)
            .Include(c => c.Accounts)  // Include accounts
                .ThenInclude(a => a.Transactions)
                .Select(c => new CustomerInformationResponse{
                    Name = c.Name,
                    Surname = c.Surname,
                    Accounts = c.Accounts.Select(a => new AccountResponse{
                        Id = a.Id,
                        Amount = a.Amount,
                        Transactions = a.Transactions.Select(t => new TransactionResponse{
                            Amount = t.Amount,
                            Date = t.Date
                        }).ToList()
                    }).ToList()
                })
            .FirstOrDefault()??throw new CustomerNotFoundException("Customer Not Found");
    }

    public  List<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public Customer GetCustomerById(int customerId)
    {
        return _context.Customers.FirstOrDefault(c => c.Id == customerId)??throw new CustomerNotFoundException("Customer Not Found");
    }

    public void OpenAccount(int customerId, decimal initialCredit)
    {
        var customer = GetCustomerById(customerId);
        var account = _accountService.CreateAccount(customer, 0);

        if (initialCredit > 0)
        {
            _transactionService.CreateTransaction(account, initialCredit);
        }
    }
}


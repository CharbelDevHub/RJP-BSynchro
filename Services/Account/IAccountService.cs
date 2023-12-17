using RJP.Models;

namespace RJP.Services;

public interface IAccountService {
    Account CreateAccount(Customer customer, decimal initialCredit);
    
}
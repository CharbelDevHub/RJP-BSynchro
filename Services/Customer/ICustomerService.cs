using RJP.Models;
using RJP.Responses;

namespace RJP.Services;

public interface ICustomerService {
        void OpenAccount(int customerId, decimal initialCredit);
        List<Customer> GetAll();
        CustomerInformationResponse GetAccountInfo(int customerId);
        Customer GetCustomerById(int userId);
}
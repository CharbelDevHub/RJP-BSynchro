using RJP.Models;

namespace RJP.Responses;

public class CustomerListViewModel {
    public int CustomerId {get; set; }
    public decimal InitialCredit {get; set;}
    public List<Customer>? Customers { get; set; }
}
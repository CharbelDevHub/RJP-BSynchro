namespace RJP.Responses;


public class AccountResponse {

    public int Id { get; set; }
    public decimal Amount { get; set; }
    public List<TransactionResponse>? Transactions {get; set;}
}
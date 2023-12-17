namespace RJP.Responses;

public class CustomerInformationResponse{

    public String? Name { get; set; }
    public String? Surname { get; set; }
    public List<AccountResponse>? Accounts { get; set; }
    
}
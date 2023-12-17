using System.ComponentModel.DataAnnotations;

namespace RJP.Models;

public class Customer {

    [Key]
    public int Id { get; set; }

    [Required]
    public required String Name { get; set; }
    
    [Required]
    public required String Surname { get; set; }

    public List<Account>? Accounts {get; set; }
}
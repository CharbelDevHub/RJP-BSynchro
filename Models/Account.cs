using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJP.Models;

public class Account {

    [Key]
    public int Id { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer? Customer {get; set;}

    public List<Transaction>? Transactions {get; set; }


}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RJP.Models;

public class Transaction {

    [Key]
    public int TransactionId { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }
    public Account? Account {get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public DateTime Date {get; set;}


}
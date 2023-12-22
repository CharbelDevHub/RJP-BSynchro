using RJP.Models;
using Microsoft.EntityFrameworkCore;

public class DataDbContext : DbContext{

    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options){

    }

    public DataDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RJP;Trusted_Connection=True;Encrypt=False;");
        }
    }

    public DbSet<Customer> Customers {get; set;}
    public DbSet<Account> Accounts {get; set;}
    public DbSet<Transaction> Transactions {get; set;}
}

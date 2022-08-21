using Microsoft.EntityFrameworkCore;
using BudgetInterface.Models;


namespace BudgetBll.DbContextBll
{
    internal class BudgetContext : DbContext
    {
        public BudgetContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database=budgetDb;Username=postgres;Password=Egor1324");
        
        public DbSet<Shop>? Shops { get; set; }
        public DbSet<PersonWhoPaid>? PeopleWhoPaid { get; set; }
        public DbSet<LogEntry>? LogsEntrie { get; set; }
    }
}

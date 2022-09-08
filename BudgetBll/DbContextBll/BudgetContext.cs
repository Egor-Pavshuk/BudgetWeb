using Microsoft.EntityFrameworkCore;
using BudgetInterface.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace BudgetBll.DbContextBll
{
    public class BudgetContext : DbContext
    {
        public BudgetContext()
        {
            //Database.OpenConnection();
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=budgetDb;Username=postgres;Password=Egor1324;");
        
        public DbSet<Shop>? Shops { get; set; }
        public DbSet<PersonWhoPaid>? PeopleWhoPaid { get; set; }
        public DbSet<LogEntry>? LogsEntrie { get; set; }
    }

    public class BudgetContextFactory : IDesignTimeDbContextFactory<BudgetContext>
    {
        public BudgetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BudgetContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5050; Database=budgetDb;Username=postgres;Password=Egor1324");

            return new BudgetContext(optionsBuilder.Options);
        }
    }
}

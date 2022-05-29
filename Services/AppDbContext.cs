using CurrencyExchangeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeAPI.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Exchange> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=currencies.db;");
        }
    }

}
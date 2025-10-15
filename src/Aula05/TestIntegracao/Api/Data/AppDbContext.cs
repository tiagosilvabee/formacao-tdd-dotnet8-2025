using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
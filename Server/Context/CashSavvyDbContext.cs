using CashSavvy.Shared;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CS8618

namespace CashSavvy.Server.Context;

public class CashSavvyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public CashSavvyDbContext(DbContextOptions<CashSavvyDbContext> options) : base(options)
    {
    }
}
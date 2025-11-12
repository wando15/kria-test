using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.ConfigurationRoot;

public class MongoDbContext : DbContext
{
    public DbSet<Transacao> Transacoes { get; set; }

    public MongoDbContext(DbContextOptions<MongoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
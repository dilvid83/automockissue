using Microsoft.EntityFrameworkCore;
using MockingIssue.Entities;

namespace MockingIssue.Data;

public class MyContext : DbContext
{
    public virtual DbSet<SomeEntity>? SomeStuff { get; set; }
    public virtual DbSet<CountryEntity>? Countries { get; set; }
    
    public MyContext()
    { 
    }

    public MyContext(DbContextOptions<MyContext> appSettings) : base(appSettings)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    
}
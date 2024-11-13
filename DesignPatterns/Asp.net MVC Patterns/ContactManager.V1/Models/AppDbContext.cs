using ContactManager.V1.Configurations;
using ContactManager.V1.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.V1.Models;

public class AppDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection =
            @"Server=.\SQLEXPRESS;Integrated Security=true;Database=ContactManager;Trusted_Connection=Yes;";
        optionsBuilder.UseSqlServer(connection, builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
        ;
        base.OnConfiguring(optionsBuilder);
    }
}
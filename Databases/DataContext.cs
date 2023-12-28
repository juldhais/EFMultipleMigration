using EFMultipleMigration.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMultipleMigration.Databases;

public class DataContext : DbContext
{
    public DbSet<Person> Person { get; set; }

    // Other properties...
}

using Microsoft.EntityFrameworkCore;

namespace EFMultipleMigration.Databases;

public class SqliteDataContext(IConfiguration configuration) : DataContext
{
    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("Sqlite"));
    }
}

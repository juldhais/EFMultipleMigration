using Microsoft.EntityFrameworkCore;

namespace EFMultipleMigration.Databases;

public class SqlServerDataContext(IConfiguration configuration) : DataContext
{
    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
    }
}

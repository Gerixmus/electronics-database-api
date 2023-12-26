using ElectronicsDbApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ElectronicsDbApi
{
    public class PartDbContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public PartDbContext(DbContextOptions<PartDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    // Create db if can't connect
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();

                    // Create tables if no tables were created
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

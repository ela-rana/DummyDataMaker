using Microsoft.EntityFrameworkCore;

namespace DummyDataMaker.Models
{
    public class GenerateContext:DbContext
    {
        public GenerateContext(DbContextOptions<GenerateContext> options) : base(options)
        {

        }

        public DbSet<GeneratedDatabase> GeneratedDatabases { get; set; }
        public DbSet<GeneratedTable> GeneratedTables { get; set; }
        public DbSet<GeneratedField> GeneratedFields { get; set; }

    }
}

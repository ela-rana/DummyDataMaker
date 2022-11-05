using Microsoft.EntityFrameworkCore;

namespace DummyDataMaker.Models
{
    public class DataPoolContext:DbContext
    {
        public DataPoolContext(DbContextOptions<DataPoolContext> options) : base(options)
        {

        }

        public DbSet<FirstNamePool> FirstNamePools { get; set; }
        public DbSet<LastNamePool> LastNamePools { get; set; }

    }
}

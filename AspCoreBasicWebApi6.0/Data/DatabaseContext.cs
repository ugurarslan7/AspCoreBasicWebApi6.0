using AspCoreBasicWebApi6._0.Core;

namespace AspCoreBasicWebApi6._0.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base (option) 
        {

        }

        public DbSet<ProductEntity> productEntities { get; set; }
    }


}

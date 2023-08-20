using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KLYDBMS.Application.Core.Data
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer("Data Source=192.168.3.9;Initial Catalog=KLYStorages;User ID=sa;Password=sa123;Integrated Security=true;Encrypt=false;TrustServerCertificate=True");

            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}

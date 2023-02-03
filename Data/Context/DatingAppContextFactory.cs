using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{

    public class DatingAppContextFactory : IDesignTimeDbContextFactory<DatingAppContext>
    {
        public DatingAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                       .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
 
                                       

            var builder = new DbContextOptionsBuilder<DatingAppContext>();
            var connectionString = configuration.GetConnectionString("DatingAppConnectionString");

            builder.UseSqlServer(connectionString);

            return new DatingAppContext(builder.Options);
        }

     
    }

}

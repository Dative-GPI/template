using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using XXXXX.Context.Core;

namespace XXXXX.Context.Migrations
{
    public class CustomApplicationContextDesignFactory : IDesignTimeDbContextFactory<CustomApplicationContext>
    {
        public CustomApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
                
            // Here we create the DbContextOptionsBuilder manually.        
            var builder = new DbContextOptionsBuilder<ApplicationContext>();

            // Build connection string. This requires that you have a connectionstring in the appsettings.json
            var connectionString = configuration.GetConnectionString("PGSQL");

            builder.UseNpgsql(connectionString, otp => otp.MigrationsAssembly(this.GetType().Assembly.FullName));

            // Create our DbContext.
            return new CustomApplicationContext(builder.Options);
        }
    }
}
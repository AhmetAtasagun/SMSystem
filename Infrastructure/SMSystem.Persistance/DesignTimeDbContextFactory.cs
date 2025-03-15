using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SMSystem.Persistance.Contexts;
using System.IO;

namespace SMSystem.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SMSDbContext>
    {
        public SMSDbContext CreateDbContext(string[] args)
        {
            //var basePath = Directory.GetCurrentDirectory();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SMSDbConnection");

            var contextOptionsBuilder = new DbContextOptionsBuilder<SMSDbContext>();
            contextOptionsBuilder.UseSqlServer(connectionString);

            return new SMSDbContext(contextOptionsBuilder.Options);
        }
    }
}

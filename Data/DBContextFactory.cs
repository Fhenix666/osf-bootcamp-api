using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BootCamp.Adm.Data
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        DBContext IDesignTimeDbContextFactory<DBContext>.CreateDbContext(string[] args) 
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DBContext>();
            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);
            return new DBContext(builder.Options);

        }

    }
}

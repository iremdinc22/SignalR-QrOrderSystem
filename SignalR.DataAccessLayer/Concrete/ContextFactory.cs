using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SignalR.DataAccessLayer.Concrete
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SignalRContext>
    {
        public SignalRContext CreateDbContext(string[] args)
        {
            // API projesindeki appsettings.json dosyasını okuyacak
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SignalRApi"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<SignalRContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new SignalRContext(optionsBuilder.Options);
        }
    }
}

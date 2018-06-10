using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ControleDoisV.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<C2VContext>
    {
        public C2VContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<C2VContext>();

            var connectionString = configuration.GetConnectionString("C2VConnection");

            builder.UseSqlServer(connectionString);

            return new C2VContext(builder.Options);
        }
    }
}

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

            var builder = new DbContextOptionsBuilder<C2VContext>();

            var connectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog = C2VDatabase; User Id = sa; Password = masterkey; MultipleActiveResultSets = True";

            builder.UseSqlServer(connectionString);

            return new C2VContext(builder.Options);
        }
    }
}

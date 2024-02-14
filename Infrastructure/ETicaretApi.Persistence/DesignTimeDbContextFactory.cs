using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        public ETicaretAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<ETicaretAPIDbContext>();
            // Ensure you have the correct using directive for UseSqlServer:
            // using Microsoft.EntityFrameworkCore;
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString); // This line should match your database provider
            return new ETicaretAPIDbContext(dbContextOptionsBuilder.Options);
        }

    }
}

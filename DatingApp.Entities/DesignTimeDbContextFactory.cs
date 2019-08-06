using DatingApp.Domain.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatingApp.Entities
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Server=localhost\\TESTMSSQL;Database=DatingApp;Trusted_Connection=True;User ID=test1;Password=gp9802043";
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    public static class DB
    {
        private static readonly IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        private static readonly DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")).Options;
        public static DatabaseContext connector = new(options);

    }
}

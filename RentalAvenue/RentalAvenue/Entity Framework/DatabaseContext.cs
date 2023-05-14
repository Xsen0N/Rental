using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentalAvenue.Entities;

namespace RentalAvenue
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Houses> Houses { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ATCT_Backend.Models;
using System.Collections.Generic;


// Creating the AppDbContext class that inherits from DbContext. Used to interact with the database.

namespace ATCT_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Speaker> Speakers => Set<Speaker>();

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}

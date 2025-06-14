using Microsoft.EntityFrameworkCore;
using ATCT_Backend.Models;

namespace ATCT_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Speaker> Speakers => Set<Speaker>();
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CheckInRecord> CheckInRecords { get; set; }

        // Dodaj join tabelu
        public DbSet<UserSession> UserSessions { get; set; }

        public DbSet<SessionFeedback> SessionFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracija M:N relacije User <-> Session
            modelBuilder.Entity<UserSession>()
                .HasKey(us => new { us.UserId, us.SessionId });

            modelBuilder.Entity<UserSession>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSessions)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSession>()
                .HasOne(us => us.Session)
                .WithMany(s => s.UserSessions)
                .HasForeignKey(us => us.SessionId);
        }
    }
}

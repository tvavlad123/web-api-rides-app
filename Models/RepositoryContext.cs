using Microsoft.EntityFrameworkCore;

namespace GreenBridgeWebApi.Models
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }
 
        public DbSet<Car> Cars { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRide> UserRides { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRide>().HasKey(t => new { t.UserId, t.RideId });
        }
    }
}
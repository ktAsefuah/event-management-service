using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    /// <summary>
    /// EF Core database context — backed by SQLite for persistent storage.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed demo events so the list is not empty on first run
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id          = 1,
                    Title       = "Community Clean-Up Day",
                    Description = "Join us to clean up Riverside Park. Gloves and bags provided.",
                    Date        = new System.DateTime(2025, 6, 14),
                    Time        = new System.TimeSpan(9, 0, 0),
                    Location    = "Riverside Park, Main Entrance",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 2,
                    Title       = "Summer BBQ & Fundraiser",
                    Description = "Annual neighbourhood BBQ. All proceeds go to the local food bank.",
                    Date        = new System.DateTime(2025, 7, 4),
                    Time        = new System.TimeSpan(13, 0, 0),
                    Location    = "Community Centre Grounds",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 3,
                    Title       = "Local Farmers Market",
                    Description = "Fresh produce, artisanal goods, and community vendors. Support local farmers!",
                    Date        = new System.DateTime(2025, 8, 15),
                    Time        = new System.TimeSpan(8, 30, 0),
                    Location    = "Downtown Square",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 4,
                    Title       = "Movie Night Under the Stars",
                    Description = "Outdoor cinema experience with popcorn and blankets. Family-friendly classic films.",
                    Date        = new System.DateTime(2025, 8, 22),
                    Time        = new System.TimeSpan(20, 0, 0),
                    Location    = "City Park Amphitheater",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 5,
                    Title       = "Tech Workshop: Introduction to AI",
                    Description = "Learn the basics of artificial intelligence and machine learning. No prior experience required.",
                    Date        = new System.DateTime(2025, 9, 5),
                    Time        = new System.TimeSpan(14, 0, 0),
                    Location    = "Public Library Conference Room",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 6,
                    Title       = "Autumn Harvest Festival",
                    Description = "Celebrate the harvest season with games, food stalls, and live music. Great for all ages!",
                    Date        = new System.DateTime(2025, 10, 12),
                    Time        = new System.TimeSpan(11, 0, 0),
                    Location    = "Fairgrounds Pavilion",
                    CreatedBy   = "admin"
                },
                new Event
                {
                    Id          = 7,
                    Title       = "Holiday Craft Fair",
                    Description = "Handmade gifts, decorations, and seasonal treats. Perfect for holiday shopping!",
                    Date        = new System.DateTime(2025, 12, 7),
                    Time        = new System.TimeSpan(10, 0, 0),
                    Location    = "Community Center Hall",
                    CreatedBy   = "admin"
                }
            );
        }
    }
}

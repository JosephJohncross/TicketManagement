using TicketManagement.Domain.Common;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // send data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7353-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E88}"),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6).ToUniversalTime(),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerised the worls with his banjo",
                ImageUrl = "https://images.unsplash.com/photo-1533174072545-7a4b6ad7a6c3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{EE57FF8B-6A96-4EB6-8625-EB4BE2D84E88}"),
                Name = "Clash of the Dj",
                Price = 85,
                Artist = "Dj Neptune",
                Date = DateTime.Now.AddMonths(8).ToUniversalTime(),
                Description = "DJs from all over the world will compete in this epic battle for the Sound King",
                ImageUrl = "https://images.unsplash.com/photo-1526979118433-63c7344f06f1?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{FA576F8B-6A8A-4EE6-8635-EB4BE2D84E88}"),
                Name = "The state of Affairs: Michael Live!",
                Price = 85,
                Artist = "Michael Jackson",
                Date = DateTime.Now.AddMonths(10).ToUniversalTime(),
                Description = "Micael Jackson doesn't need an introduction. His 25 concert across the global last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "https://images.unsplash.com/photo-1577640905050-83665af216b9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{EF236F8B-788A-4E6D-8635-EB4BE2D84E88}"),
                Name = "Spanish guitar hits woth Manuel",
                Price = 25,
                Artist = "Mauel Santinonsi",
                Date = DateTime.Now.AddMonths(4).ToUniversalTime(),
                Description = "The best tech conference in the world!",
                ImageUrl = "https://images.unsplash.com/photo-1577640905050-83665af216b9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
                CategoryId = conferenceGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{98AC6F8B-6A8A-46D6-8635-EB4BE2D84E88}"),
                Name = "To The Moon And Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = DateTime.Now.AddMonths(8).ToUniversalTime(),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravagance, written by Nick Sailor, the man from 'My Dad and Sister'",
                ImageUrl = "https://images.unsplash.com/photo-1516450360452-9312f5e86fc7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                CategoryId = musicalGuid
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{E45C6F8B-6E9A-46F6-8635-F6729EA54BBA}"),
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = DateTime.Now.ToUniversalTime(),
                UserId = Guid.Parse("{ABB57894-6E1A-AAF6-8635-F6729EA54BBA}"),
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{86D3A045-34FD-4E4D-8635-AD129EA54BBA}"),
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = DateTime.Now.ToUniversalTime(),
                UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-8635-AD1083DDC340}"),
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{7A1CCA4B-066C-4AC7-B3DF-F6729EA5E7E0}"),
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = DateTime.Now.ToUniversalTime(),
                UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}"),
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                OrderTotal = 245,
                OrderPaid = true,
                OrderPlaced = DateTime.Now.ToUniversalTime(),
                UserId = Guid.Parse("{4AD901BE-6E1A-46DD-8635-F6729EA54BBA}"),
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{E6A2679C-80B1-4781-B5C0-6F4C91B405B6}"),
                OrderTotal = 142,
                OrderPaid = true,
                OrderPlaced = DateTime.Now.ToUniversalTime(),
                UserId = Guid.Parse("{7AEB2C01-6E1A-46DD-8635-330BDF950F5C}"),
            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now.ToUniversalTime();
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
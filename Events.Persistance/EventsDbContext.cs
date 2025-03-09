using Events.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistance
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext() { }
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Event> Events { get; set; }
    }
}

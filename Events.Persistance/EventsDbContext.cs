using Events.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistance
{
    public class EventsDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}

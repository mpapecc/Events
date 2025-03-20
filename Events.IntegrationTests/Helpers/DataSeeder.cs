using Events.Domain.Entities;
using Events.Persistance;

namespace IntegrationTests.Helpers;

public static class DataSeeder
{
    public static void InitializeDbForTests(EventsDbContext db)
    {
        db.Events.AddRange(GetSeedingMessages());
        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(EventsDbContext db)
    {
        db.Events.RemoveRange(db.Events);
        InitializeDbForTests(db);
    }

    public static List<Event> GetSeedingMessages()
    {
        return new List<Event>()
        {
            new Event()
            {
                Name = "TEST RECORD: You're standing on my scarf.",
                Description = "The Fourth Doctor",
                StartDateTime = DateTime.Parse("1975-09-06T18:15:00")
            },
        };
    }
}
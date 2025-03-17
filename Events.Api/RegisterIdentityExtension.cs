using Events.Domain.Entities;
using Events.Persistance;
using Microsoft.AspNetCore.Identity;

namespace Events.Api
{
    public static class RegisterIdentityExtension
    {
        public static void RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(o =>
                {
                    o.SignIn.RequireConfirmedEmail = true;
                })
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<EventsDbContext>()
                .AddApiEndpoints();
        }
    }
}

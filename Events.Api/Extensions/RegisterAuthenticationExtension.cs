using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Events.Api.Extensions
{
    public static class RegisterAuthenticationExtension
    {
        public static void RegisterAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(o => o.RequireAuthenticatedSignIn = true)
            .AddBearerToken(IdentityConstants.BearerScheme)
            .AddIdentityCookies(o =>
            {
                o.ApplicationCookie?.Configure(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    options.SlidingExpiration = true;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        }
                    };

                });
            });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Events.Api.Extensions
{
    public static class RegisterAuthorizationExtension
    {
        public static void RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(o =>
            {
                o.DefaultPolicy = new AuthorizationPolicyBuilder(
                    IdentityConstants.BearerScheme,
                    IdentityConstants.ApplicationScheme)
                .RequireAuthenticatedUser().Build();
            });
        }
    }
}

using Events.Application.Options;

namespace Events.Api.Extensions
{
    public static class RegisterAppSettingsTypesExtension
    {
        public static void RegisterSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpOptions>(configuration.GetSection(nameof(SmtpOptions)));
        }
    }
}

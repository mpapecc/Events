using Events.Application.Options;

namespace Events.Api
{
    public static class RegisterAppSettingsTypesExtension
    {
        public static void RegisterSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpSection>(configuration.GetSection(nameof(SmtpSection)));
        }
    }
}

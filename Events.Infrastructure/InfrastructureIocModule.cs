using Autofac;
using Events.Infrastructure.EmailService;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Events.Infrastructure
{
    public class InfrastructureIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerDependency();
        }
    }
}

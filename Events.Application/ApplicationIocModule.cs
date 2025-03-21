﻿using Autofac;

namespace Events.Application
{
    public class ApplicationIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationIocModule).Assembly)
               .Where(t => t.IsClass && !t.IsGenericType && t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
               .AsSelf();
        }
    }
}

using Autofac;
using MediatR;
using System.Linq;
using samson.autofac.mediatr.infrastructure.Attribiutes;

namespace samson.autofac.mediatr
{
    public class Startup
    {
        /// <summary>
        /// Initialize dependency injection container and register services
        /// </summary>
        /// <returns>DI container with services</returns>
        public IContainer Init()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            RegisterServices(containerBuilder);
            RegisterMediatr(containerBuilder);

            return containerBuilder.Build();
        }

        /// <summary>
        /// Register in DI container classes with ServiceAttribute attribute
        /// </summary>
        /// <param name="container">Dependency injection container builder</param>
        private void RegisterServices(ContainerBuilder container)
        {
            var services = from assemblies in System.AppDomain.CurrentDomain.GetAssemblies()
                          from types in assemblies.GetTypes()
                          where types.IsDefined(typeof(ServiceAttribute), false)
                          select types;

            foreach (var service in services)
            {
                container
                    .RegisterType(service)
                    .InstancePerLifetimeScope();
            }
        }

        /// <summary>
        /// Register implementation on mediator design pattern
        /// </summary>
        /// <param name="container">Dependency injection container builder</param>
        private void RegisterMediatr(ContainerBuilder container)
        {
            container
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();
        }
    }
}

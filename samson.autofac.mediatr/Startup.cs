using Autofac;
using MediatR;
using System.Linq;
using samson.autofac.mediatr.infrastructure.Attributes;
using samson.autofac.mediatr.infrastructure.Classes;
using samson.autofac.mediatr.infrastructure.Interfaces;

namespace samson.autofac.mediatr
{
    public class Startup
    {
        /// <summary>
        /// Initialize dependency injection container and register:
        /// Services
        /// , CommandHandlers
        /// , Mediatr
        /// , Gate
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
            RegisterCommandHandlers(containerBuilder);
            RegisterMediatr(containerBuilder);
            RegisterGate(containerBuilder);

            return containerBuilder.Build();
        }

        /// <summary>
        /// Register in DI container classes with Service attribute
        /// </summary>
        /// <param name="container">Dependency injection container builder</param>
        private void RegisterServices(ContainerBuilder container)
        {
            var services = from assemblies in System.AppDomain.CurrentDomain.GetAssemblies()
                          from types in assemblies.GetExportedTypes()
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

        /// <summary>
        /// Register IGate to dispatch commands
        /// </summary>
        /// <param name="container">Dependency injection container builder</param>
        private void RegisterGate(ContainerBuilder container)
        {
            container
                .RegisterType<Gate>()
                .As<IGate>()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Register in DI container classes with CommandHandler attribute
        /// </summary>
        /// <param name="container">Dependency injection container builder</param>
        private void RegisterCommandHandlers(ContainerBuilder container)
        {
            var commandHandlers = from assemblies in System.AppDomain.CurrentDomain.GetAssemblies()
                from types in assemblies.GetExportedTypes()
                where types.IsDefined(typeof(CommandHandlerAttribute), false)
                select types;

            foreach (var commandHandler in commandHandlers)
            {
                container
                    .RegisterType(commandHandler)
                    .InstancePerLifetimeScope();
            }
        }
    }
}

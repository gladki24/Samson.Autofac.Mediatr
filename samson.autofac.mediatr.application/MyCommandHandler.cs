using System;
using System.Threading;
using System.Threading.Tasks;
using samoson.autofac.mediatr.interfaces;
using samson.autofac.mediatr.infrastructure.Attributes;
using samson.autofac.mediatr.infrastructure.Classes;
using samson.autofac.mediatr.infrastructure.Interfaces;

namespace samson.autofac.mediatr.application
{
    [CommandHandler]
    public class MyCommandHandler : ICommandHandler<MyCommand, string>
    {
        private readonly IMyService _service;

        public MyCommandHandler(
            IMyService service
        )
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public Task<string> Handle(CommandRequest<MyCommand, string> command, CancellationToken cancellationToken)
        {
            return Task.FromResult(this._service.GetHelloMessage(command.Command.Name));
        }
    }
}

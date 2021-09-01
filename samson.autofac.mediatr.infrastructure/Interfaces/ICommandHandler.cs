using System.Threading;
using System.Threading.Tasks;
using MediatR;
using samson.autofac.mediatr.infrastructure.Classes;

namespace samson.autofac.mediatr.infrastructure.Interfaces
{
    /// <summary>
    /// Handle incoming commands from Gate
    /// </summary>
    /// <typeparam name="TCommand">Type of incoming command</typeparam>
    /// <typeparam name="TResponse">Type of command handling result</typeparam>
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<CommandRequest<TCommand, TResponse>, TResponse>
    {
        /// <summary>
        /// Function to handle incoming command
        /// </summary>
        /// <param name="command">Command to handle</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Asynchronous result of handling command</returns>
        public Task<TResponse> Handle(CommandRequest<TCommand, TResponse> command, CancellationToken cancellationToken);
    }
}
    
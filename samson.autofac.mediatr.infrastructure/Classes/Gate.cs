using System;
using System.Threading.Tasks;
using MediatR;
using samson.autofac.mediatr.infrastructure.Interfaces;

namespace samson.autofac.mediatr.infrastructure.Classes
{
    /// <summary>
    /// Default implementation of IGate interface to handle commands and queries
    /// </summary>
    public class Gate : IGate
    {
        /// <summary>
        /// Mediator pattern implementation
        /// </summary>
        private IMediator _mediator;

        /// <summary>
        /// Default constructor of Gate
        /// </summary>
        /// <param name="mediator">Mediator pattern implementation</param>
        public Gate(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Entry for command to handle. Commands will be handled by command handlers then result will be returned asynchronous.
        /// </summary>
        /// <typeparam name="TCommand">Type of passed command</typeparam>
        /// <typeparam name="TResponse">Type of returned result of handling</typeparam>
        /// <param name="command">Command to handle</param>
        /// <returns>Asynchronous result of handling command</returns>
        public Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command)
        {
            var commandRequest = new CommandRequest<TCommand, TResponse>(command);
            return _mediator.Send(commandRequest);
        }
    }
}

using System;
using MediatR;

namespace samson.autofac.mediatr.infrastructure.Classes
{
    /// <summary>
    /// Wrapper for command to implement 3rd-party Mediatr IRequest interface
    /// </summary>
    /// <typeparam name="TCommand">Type of passed command</typeparam>
    /// <typeparam name="TResponse">Type of returned result of handling command</typeparam>
    public class CommandRequest<TCommand, TResponse> : IRequest<TResponse>
    {
        /// <summary>
        /// Command to handle
        /// </summary>
        public TCommand Command { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="command">Command to handle</param>
        public CommandRequest(TCommand command)
        {
            Command = command ?? throw new ArgumentException(nameof(command));
        }
    }
}

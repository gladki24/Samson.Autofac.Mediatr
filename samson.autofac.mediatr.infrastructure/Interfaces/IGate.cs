using System.Threading.Tasks;

namespace samson.autofac.mediatr.infrastructure.Interfaces
{
    /// <summary>
    /// Dispatch commands and queries to CQRS mediator
    /// </summary>
    public interface IGate
    {
        /// <summary>
        /// Dispatch command to update or create entities
        /// </summary>
        /// <typeparam name="TCommand">Type of command to handle</typeparam>
        /// <typeparam name="TResponse">Type of handling command result</typeparam>
        /// <param name="command"></param>
        /// <returns>Asynchronous result of handling command</returns>
        public Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command);
    }
}

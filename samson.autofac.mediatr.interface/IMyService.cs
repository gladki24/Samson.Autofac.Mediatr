using System;

namespace samoson.autofac.mediatr.interfaces
{
    /// <summary>
    /// Example of service
    /// </summary>
    public interface IMyService
    {
        /// <summary>
        /// Return welcoming message for user
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <returns>Formatted welcoming message</returns>
        public string GetHelloMessage(string name);
    }
}

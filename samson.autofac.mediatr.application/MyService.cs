using samoson.autofac.mediatr.interfaces;
using samson.autofac.mediatr.infrastructure.Attributes;
using System;

namespace samoson.autofac.mediatr.application
{
    /// <summary>
    /// Example service implementation
    /// </summary>
    [Service]
    public class MyService : IMyService
    {
        /// <summary>
        /// Return welcoming message for user
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <returns>Formatted welcoming message</returns>
        public string GetHelloMessage(string name)
        {
            return $"Hello {name}!";
        }
    }
}

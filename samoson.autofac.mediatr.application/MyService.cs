using samoson.autofac.mediatr.interfaces;
using samson.autofac.mediatr.infrastructure.Attribiutes;
using System;

namespace samoson.autofac.mediatr.application
{
    [Service]
    public class MyService : IMyService
    {
       
        public string GetHelloMessage()
        {
            return "Hello Autofac!";
        }
    }
}

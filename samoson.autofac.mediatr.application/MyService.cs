using samoson.autofac.mediatr.interfaces;
using samson.autofac.mediatr.infrastructure.Attributes;
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

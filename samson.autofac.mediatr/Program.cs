using Autofac;
using samoson.autofac.mediatr.application;

namespace samson.autofac.mediatr
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();
            var container = startup.Init();

            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<MyService>();
                System.Console.WriteLine(service.GetHelloMessage());
            }
        }
    }
}

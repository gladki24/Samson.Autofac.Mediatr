using System.Threading.Tasks;
using Autofac;
using samson.autofac.mediatr.application;
using samson.autofac.mediatr.infrastructure.Interfaces;

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
                var gate = scope.Resolve<IGate>();
                var command = new MyCommand("Mark");

                var result = gate.Dispatch<MyCommand, string>(command);
                System.Console.WriteLine(result.Result);
            }
        }
    }
}

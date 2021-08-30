using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samson.autofac.mediatr.infrastructure.Attribiutes
{
    /// <summary>
    /// Attribute to decorate command class
    /// Decorate class registers class in DI container
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class CommandAttribute : System.Attribute
    { }
}

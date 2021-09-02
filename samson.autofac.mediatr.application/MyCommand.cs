using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samson.autofac.mediatr.application
{
    public class MyCommand
    {
        public string Name { get; set; }

        public MyCommand(string name)
        {
            Name = name;
        }
    }
}

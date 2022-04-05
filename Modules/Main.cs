using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzu.Modules
{

    class Main
    {
        Kuzu.Modules.Commands Commands;

        public void setup()
        {
            Commands = new Kuzu.Modules.Commands();
            Commands.AutomaticRun();
        }
    }
}

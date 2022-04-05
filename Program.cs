using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kuzu;

namespace Kuzu
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Kuzu.Modules.Main m = new Kuzu.Modules.Main();
            m.setup();
        }
    }
}

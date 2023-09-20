using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Part2.Final
{
    public abstract class Command
    {
        public abstract void Execute(string url);
    }
}

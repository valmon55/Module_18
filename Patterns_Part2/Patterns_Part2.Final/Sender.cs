using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Part2.Final
{
    public class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        { 
            this._command = command; 
        }

        public void Execute(string url) 
        {
            _command.Execute(url);
        }
    }
}

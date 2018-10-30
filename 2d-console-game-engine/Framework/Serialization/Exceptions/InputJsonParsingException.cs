using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Serialization
{
    public class InputJsonParsingException : System.Exception
    {
        public InputJsonParsingException() : base(string.Format("Key that you've typed into the Input.json does not exist in the ConsoleKey enum!"))
        {
        }
    }
}

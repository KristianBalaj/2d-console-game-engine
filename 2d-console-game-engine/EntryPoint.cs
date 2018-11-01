using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace GameEngine
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            MyGame game = new MyGame();
            game.InitInstance();
        }
    }
}

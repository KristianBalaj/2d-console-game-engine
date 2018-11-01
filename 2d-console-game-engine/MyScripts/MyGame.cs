using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameEngine
{
    public class MyGame : GameCodeBase
    {
        private const string INPUT_JSON_PATH = @"Data\Input.json";

        protected override GameLogicBase createGame()
        {
            return new MyGameLogic();
        }

        protected override Renderer initializeRendering()
        {
            return new ConsoleRenderer(101, 101);
        }

        protected override Dictionary<string, string> loadStrings()
        {
            var dict = new Dictionary<string, string>();

            string inputJson;
#if DEBUG
            inputJson = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"..\..", INPUT_JSON_PATH)); // returning into the project folder (grandparent folder)
#else
            inputJson = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, INPUT_JSON_PATH)); // The data should be where the executable is
#endif

            dict.Add("Input", inputJson);

            return dict;
        }
    }
}

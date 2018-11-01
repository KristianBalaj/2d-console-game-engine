using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class InputManager
    {
        public static InputManager instance;

        private List<ConsoleKey> availableKeys;

        public InputManager()
        {
            instance = this;

            this.availableKeys = new List<ConsoleKey>();
        }

        /// <summary>
        /// Initializes available keys from the json input.
        /// </summary>
        public void InitInputManager(string inputJsonText)
        {
            var result = JsonConvert.DeserializeObject<Serialization.InputModel>(inputJsonText);

            foreach (var item in result.AvailableKeys)
            {
                if (Enum.TryParse<ConsoleKey>(item, out ConsoleKey key))
                {
                    availableKeys.Add(key);
                }
                else
                {
                    throw new Serialization.InputJsonParsingException();
                }
            }
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                while (Console.KeyAvailable)
                {
                    // clears the remaining inputstream
                    var temp = Console.ReadKey(true);
                }

                if (availableKeys.Contains(key))
                {
                    EventManager.TriggerEvent<OnKeyPressedEvent>(new OnKeyPressedEventContext(key));
                }
            }
        }

    }
}

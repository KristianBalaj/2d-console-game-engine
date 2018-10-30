using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OnKeyPressedEvent : EventBase<EventContext> { }

    public class OnKeyPressedEventContext : EventContext
    {
        public readonly ConsoleKey PressedKey;

        public OnKeyPressedEventContext(ConsoleKey pressedKey)
        {
            this.PressedKey = pressedKey;
        }
    }
}

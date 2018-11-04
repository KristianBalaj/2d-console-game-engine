using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Internal
{
    public class OnPhysicsBodyAddedEvent : EventBase<EventContext> { }

    public class OnPhysicsBodyAddedEventContext : EventContext
    {
        public readonly ICollidable NewCollidable;

        public OnPhysicsBodyAddedEventContext(ICollidable newCollidable)
        {
            this.NewCollidable = newCollidable;
        }
    }
}

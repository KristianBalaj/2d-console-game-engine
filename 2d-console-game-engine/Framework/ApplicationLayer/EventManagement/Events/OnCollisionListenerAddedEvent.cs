using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Internal
{
    public class OnCollisionListenerAddedEvent : EventBase<EventContext> { }

    public class OnCollisionListenerAddedEventContext : EventContext
    {
        public readonly Actor CorrespondingActor;
        public readonly ICollisionListener CollisionListener;

        public OnCollisionListenerAddedEventContext(Actor actor, ICollisionListener collisionListener)
        {
            this.CorrespondingActor = actor;
            this.CollisionListener = collisionListener;
        }
    }

}

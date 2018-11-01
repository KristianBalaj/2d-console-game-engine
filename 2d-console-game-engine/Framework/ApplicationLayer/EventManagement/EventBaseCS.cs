using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class EventBase<T> where T : EventContext
    {
        private System.Action<EventContext> subscribers;

        public virtual void Subscribe(Action<EventContext> subscriber)
        {
            // this serves to prevent double subscription on one event instance
            subscribers -= subscriber;

            // using C# Events syntax
            subscribers += subscriber;
        }

        /// <summary>
        /// Unregister a callback from this event.
        /// </summary>
        /// <param name="subscriber">function pointer (delegate) to the callback</param>
        public virtual void Unsubscribe(Action<EventContext> subscriber)
        {
            // using C# Events syntax
            subscribers -= subscriber;
        }

        /// <summary>
        /// "Fire" the event - notify the subscribers if there are any
        /// </summary>
        /// <param name="context">the payload - event data to be sent to callback</param>
        public virtual void Trigger(T context)
        {
            if (subscribers != null)
            {
                subscribers(context);
            }
        }
    }
}

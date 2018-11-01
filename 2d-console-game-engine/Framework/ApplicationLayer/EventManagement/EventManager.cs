using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace GameEngine
{
    public class EventManager
    {
        private static EventManager instance;

        public static bool HasInstance { get { return instance != null; } }

        /// <summary>
        /// Context sensitive events
        /// </summary>
        private Dictionary<Type, EventBase<EventContext>> eventsDictionaryCS;

        /// <summary>
        /// Context free events
        /// </summary>
        private Dictionary<Type, EventBase> eventsDictionaryCF = new Dictionary<Type, EventBase>();


        public EventManager()
        {
            instance = this;

            eventsDictionaryCS = new Dictionary<Type, EventBase<EventContext>>();
            eventsDictionaryCF = new Dictionary<Type, EventBase>();
        }

        #region Adding Listeners

        public static void Subscribe<T>(Action callbackMethod) where T : EventBase
        {
            EventBase tempEvent;

            if (instance.eventsDictionaryCF.TryGetValue(typeof(T), out tempEvent))
            {
                tempEvent.Subscribe(callbackMethod);
            }
            else
            {
                T newEvent = (T)Activator.CreateInstance(typeof(T));

                newEvent.Subscribe(callbackMethod);
                instance.eventsDictionaryCF.Add(typeof(T), newEvent);
            }
        }

        public static void Subscribe<T>(Action<EventContext> callbackMethod) where T : EventBase<EventContext>
        {
            EventBase<EventContext> tempEvent;

            if (instance.eventsDictionaryCS.TryGetValue(typeof(T), out tempEvent))
            {
                tempEvent.Subscribe(callbackMethod);
            }
            else
            {
                T newEvent = (T)Activator.CreateInstance(typeof(T));

                newEvent.Subscribe(callbackMethod);
                instance.eventsDictionaryCS.Add(typeof(T), newEvent);
            }
        }

        #endregion
        #region Removing Listeners

        public static void Unsubscribe(Type eventType, Action callbackMethod)
        {
            internalUnsubscribe(eventType, callbackMethod);
        }

        public static void Unsubscribe(Type eventType, Action<EventContext> callbackMethod)
        {
            internalUnsubscribe(eventType, callbackMethod);
        }

        public static void Unsubscribe<T>(Action callbackMethod) where T : EventBase
        {
            internalUnsubscribe(typeof(T), callbackMethod);
        }

        public static void Unsubscribe<T>(Action<EventContext> callbackMethod) where T : EventBase<EventContext>
        {
            internalUnsubscribe(typeof(T), callbackMethod);
        }

        private static void internalUnsubscribe(Type eventType, Action callbackMethod)
        {
            EventBase tempEvent;

            if (instance.eventsDictionaryCF.TryGetValue(eventType, out tempEvent))
            {
                tempEvent.Unsubscribe(callbackMethod);
            }
        }

        private static void internalUnsubscribe(Type eventType, Action<EventContext> callbackMethod)
        {
            EventBase<EventContext> tempEvent;

            if (instance.eventsDictionaryCS.TryGetValue(eventType, out tempEvent))
            {
                tempEvent.Unsubscribe(callbackMethod);
            }
        }

        #endregion
        #region Triggering Events

        public static void TriggerEvent<T>() where T : EventBase
        {
            EventBase tempEvent;

            if (instance.eventsDictionaryCF.TryGetValue(typeof(T), out tempEvent))
            {
                tempEvent.Trigger();
            }
        }

        public static void TriggerEvent<T>(EventContext context) where T : EventBase<EventContext>
        {
            EventBase<EventContext> tempEvent;

            if (instance.eventsDictionaryCS.TryGetValue(typeof(T), out tempEvent))
            {
                tempEvent.Trigger(context);
            }
        }

        #endregion

        // TODO: add logging
    }
}
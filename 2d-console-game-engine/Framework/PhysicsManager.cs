using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public sealed class PhysicsManager
    {
        private class ActorCollisionListeners
        {
            private List<ICollisionListener> collisionListeners;
            private Dictionary<ICollidable, bool> collisionCollidersStartTriggered;

            public ActorCollisionListeners()
            {
                this.collisionListeners = new List<ICollisionListener>();
                this.collisionCollidersStartTriggered = new Dictionary<ICollidable, bool>();
            }

            public void AddListener(ICollisionListener newListener)
            {
                collisionListeners.Add(newListener);
            }

            /// <summary>
            /// This forgets for the triggered onCollisionStart and Exit callbacks.
            /// </summary>
            public void ClearCollisionData()
            {
                this.collisionCollidersStartTriggered.Clear();
            }

            /// <summary>
            /// Triggers OnCollision and triggers onCollisionEnter when it was not triggered.
            /// </summary>
            /// <param name="otherColl"></param>
            public void TriggerCollisionListeners(ICollidable otherColl)
            {
                bool isOnEnter = false;
                if (collisionCollidersStartTriggered.TryGetValue(otherColl, out bool isStartTriggered))
                {
                    if (!isStartTriggered)
                    {
                        isOnEnter = true;
                    }
                }
                else
                {
                    collisionCollidersStartTriggered.Add(otherColl, false);
                    isOnEnter = true;
                }

                // TODO: store triggeredInFrame variable for each collision
                if (isOnEnter)
                {
                    foreach (var coll in collisionListeners)
                    {
                        coll.OnCollisionEnter(otherColl);
                    }

                    collisionCollidersStartTriggered[otherColl] = true;
                }

                foreach (var coll in collisionListeners)
                {
                    coll.OnCollision(otherColl);
                }
            }

            /// <summary>
            /// OnCollisionExit is triggered only when there was CollisionStart triggered.
            /// </summary>
            /// <param name="otherColl"></param>
            public void TriggerOnCollisionExit(ICollidable otherColl)
            {
                if (collisionCollidersStartTriggered.ContainsKey(otherColl))
                {
                    collisionCollidersStartTriggered.Remove(otherColl);

                    foreach (var coll in collisionListeners)
                    {
                        coll.OnCollisionExit(otherColl);
                    }
                }
            }
        }

        private List<ICollidable> collidables;

        private Dictionary<Actor, ActorCollisionListeners> collisionListenersMap;

        public PhysicsManager()
        {
            this.collidables = new List<ICollidable>();
            this.collisionListenersMap = new Dictionary<Actor, ActorCollisionListeners>();

            EventManager.Subscribe<Internal.OnPhysicsBodyAddedEvent>(onPhysicsBodyAdded);
            EventManager.Subscribe<Internal.OnCollisionListenerAddedEvent>(onCollisionListenerAdded);
            // TODO: removing collidables and listeners
        }

        private void onCollisionListenerAdded(EventContext context)
        {
            var specificContext = context as Internal.OnCollisionListenerAddedEventContext;

            if (collisionListenersMap.TryGetValue(specificContext.CorrespondingActor, out ActorCollisionListeners listeners))
            {
                listeners.AddListener(specificContext.CollisionListener);
            }
            else
            {
                collisionListenersMap.Add(specificContext.CorrespondingActor, new ActorCollisionListeners());
                onCollisionListenerAdded(specificContext);
            }
        }

        private void onPhysicsBodyAdded(EventContext context)
        {
            collidables.Add((context as Internal.OnPhysicsBodyAddedEventContext).NewCollidable);
        }

        public void ProcessCollisions()
        {
            Bounds[] bounds = collidables.Select(c => c.GetCollisionBounds()).ToArray();

            // This loops through each collider and checks if it intersects with any other.

            for (int i = 0; i < bounds.Length; i++)
            {
                if (!(collidables[i] as Component).IsUpdatable)
                {
                    if (collisionListenersMap.TryGetValue((collidables[i] as Component).ParentActor, out ActorCollisionListeners listeners))
                    {
                        listeners.ClearCollisionData();
                    }

                    continue;
                }

                for (int p = i + 1; p < bounds.Length; p++)
                {
                    if (!(collidables[p] as Component).IsUpdatable)
                    {
                        if (collisionListenersMap.TryGetValue((collidables[p] as Component).ParentActor, out ActorCollisionListeners listeners))
                        {
                            listeners.ClearCollisionData();
                        }

                        continue;
                    }

                    bool areIntersecting = bounds[i].Intersects(bounds[p]);

                    int[] collidableIndexes = new int[] { i, p };

                    for (int id = 0; id < 2; id++) // This checks if one itersects the other and if so, notify collision listeners if there are any.
                    {
                        int collidableID1 = collidableIndexes[id];
                        int collidableID2 = collidableIndexes[(id + 1) % 2];

                        if (collisionListenersMap.TryGetValue((collidables[collidableID1] as Component).ParentActor, out ActorCollisionListeners listeners))
                        {
                            if (areIntersecting)
                            {
                                listeners.TriggerCollisionListeners(collidables[collidableID2]);
                            }
                            else
                            {
                                listeners.TriggerOnCollisionExit(collidables[collidableID2]);
                            }
                        }
                    }

                    if (areIntersecting)
                    {
                        if (!collidables[i].IsTrigger && !collidables[p].IsTrigger)
                        {
                            modifyCollisionPositions(collidables[i], collidables[p]);
                        }
                    }
                }
            }

            allignColliders();
        }

        private void modifyCollisionPositions(ICollidable coll1, ICollidable coll2)
        {
            // TODO: modifying collider(actor) positions according to collision.
        }

        private void allignColliders()
        {
            foreach (var coll in collidables)
            {
                coll.AllignColliders();
            }
        }
    }

}

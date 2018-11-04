using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public sealed class PhysicsManager
    {
        private List<ICollidable> collidables;

        private Dictionary<Actor, List<ICollisionListener>> collisionListenersMap;

        public PhysicsManager()
        {
            this.collidables = new List<ICollidable>();
            this.collisionListenersMap = new Dictionary<Actor, List<ICollisionListener>>();

            EventManager.Subscribe<Internal.OnPhysicsBodyAddedEvent>(onPhysicsBodyAdded);
            EventManager.Subscribe<Internal.OnCollisionListenerAddedEvent>(onCollisionListenerAdded);
            // TODO: removing collidables and listeners
        }

        private void onCollisionListenerAdded(EventContext context)
        {
            var specificContext = context as Internal.OnCollisionListenerAddedEventContext;

            if (collisionListenersMap.TryGetValue(specificContext.CorrespondingActor, out List<ICollisionListener> listenersList))
            {
                listenersList.Add(specificContext.CollisionListener);
            }
            else
            {
                collisionListenersMap.Add(specificContext.CorrespondingActor, new List<ICollisionListener>());
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
                    continue;
                }

                for (int p = i; p < bounds.Length; p++)
                {
                    if (i == p || !(collidables[p] as Component).IsUpdatable)
                    {
                        continue;
                    }

                    int[] collidableIndexes = new int[] { i, p };

                    for (int id = 0; id < 2; id++) // This checks if one itersects the other and if so, notify collision listeners if there are any.
                    {
                        int collidableID1 = collidableIndexes[id];
                        int collidableID2 = collidableIndexes[(id + 1) % 2];

                        if (bounds[collidableID1].Intersects(bounds[collidableID2]))
                        {
                            if (collisionListenersMap.TryGetValue((collidables[collidableID1] as Component).ParentActor, out List<ICollisionListener> listeners))
                            {
                                foreach (var listener in listeners)
                                {
                                    listener.OnCollision(collidables[collidableID2]);
                                }
                            }
                        }
                    }
                }
            }

            allignColliders();
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

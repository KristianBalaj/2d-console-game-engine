using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ActorManager
    {
        public static int LastActorUniqueID = 0;

        private List<Actor> actors = new List<Actor>();

        public void AddActor(Actor newActor)
        {
            actors.Add(newActor);
        }

        public void RemoveActor(Actor actorToRemove)
        {
            actors.Remove(actorToRemove);
        }

        /// <summary>
        /// Calls the Start method on all the newly created components.
        /// </summary>
        public void StartActors()
        {
            foreach(var actor in actors)
            {
                if (!actor.IsDestroyed)
                {
                    actor.StartNewComponents();
                }
            }
        }
        
        /// <summary>
        /// Updates all the enabled components on all the non destroyed actors.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateActors(float deltaTime)
        {
            foreach (var actor in actors)
            {
                if (!actor.IsDestroyed)
                {
                    actor.UpdateComponents(deltaTime);
                }
            }
        }

        /// <summary>
        /// Searches through all the actor's components and picks the IRenderable ones.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IRenderable> GetRenderables()
        {
            List<IRenderable> result = new List<IRenderable>();

            foreach (var actor in actors)
            {
                if (actor.IsDestroyed)
                {
                    continue;
                }

                var components = actor.GetAllComponents();

                foreach (var component in components)
                {
                    if (!component.IsUpdatable)
                    {
                        continue;
                    }

                    if (component is IRenderable)
                    {
                        result.Add(component as IRenderable);
                    }
                }
            }

            return result;
        }

    }
}

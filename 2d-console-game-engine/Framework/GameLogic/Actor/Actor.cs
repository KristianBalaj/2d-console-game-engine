using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameEngine
{
    /// <summary>
    /// Anything in the game is an actor - a player, enemy, pick-up, bullet, etc.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Actor
    {
        [JsonProperty]
        public readonly int UNIQUE_ID;

        [JsonProperty]
        public string Name;

        [JsonProperty]
        private bool isDestroyed;

        private List<Component> newAddedComponents;

        private Dictionary<Type, Component> components; // maps component type to component object

        /// <summary>
        /// World position of the actor.
        /// </summary>
        [JsonProperty]
        public Vector2 Position { get; set; }

        /// <summary>
        /// This is used for positioning the actor into console world.
        /// </summary>
        public Vector2Int ClampedPosition { get { return (Vector2Int)Position; } }

        public bool IsDestroyed { get { return isDestroyed; } }

        public Actor(Vector2 position, string actorName)
        {
            this.Position = position;
            this.isDestroyed = false;
            this.Name = actorName;

            // TODO: implement generator of unique IDs
            ActorManager.LastActorUniqueID++;
            this.UNIQUE_ID = ActorManager.LastActorUniqueID;

            this.components = new Dictionary<Type, Component>();
            this.newAddedComponents = new List<Component>();
            System.Diagnostics.Debug.WriteLine("Shiat");
        }

        public void Destroy()
        {
            foreach (var component in components)
            {
                component.Value.OnDestroy();
            }

            this.isDestroyed = true;
        }

        /// <summary>
        /// Calls the Start method on newly added components and removes them from the newly added list of components.
        /// </summary>
        public void StartNewComponents()
        {
            if(newAddedComponents.Count > 0)
            {
                foreach (var comp in newAddedComponents)
                {
                    comp.Start();
                }

                newAddedComponents.Clear();
            }
        }

        /// <summary>
        /// Updates all the enabled components on this actor.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateComponents(float deltaTime)
        {
            var components = GetAllComponents();

            foreach (var component in components)
            {
                if (component.IsEnabled)
                {
                    component.Update(deltaTime);
                }
            }
        }

        public IEnumerable<Component> GetAllComponents()
        {
            return components.Values;
        }

        public T AddComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
            {
                throw new DuplicateComponentException();
            }

            T componentInstance = Activator.CreateInstance(typeof(T), this) as T;
            components.Add(typeof(T), componentInstance);
            newAddedComponents.Add(componentInstance);

            return componentInstance;
        }

        public T GetComponent<T>() where T : Component
        {
            Component outComponent;

            if (components.TryGetValue(typeof(T), out outComponent))
            {
                return (T)outComponent;
            }
            else
            {
                return null;
            }
        }
    }
}

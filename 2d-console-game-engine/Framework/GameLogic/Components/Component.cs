using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameEngine
{
    public abstract class Component
    {
        /// <summary>
        /// If isEnabled false, then none of the abstract methods are called in game loop.
        /// </summary>
        public bool IsEnabled;
        public bool IsUpdatable { get { return IsEnabled && !ParentActor.IsDestroyed; } }

        public Actor ParentActor { get; private set; }

        public Component(Actor parentActor)
        {
            this.IsEnabled = true;
            this.ParentActor = parentActor;
        }

        public abstract void Start();
        public abstract void Update(float deltaTime);
        public abstract void OnDestroy();
    }
}

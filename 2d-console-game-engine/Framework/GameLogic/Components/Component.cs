using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Component
    {
        /// <summary>
        /// If isEnabled false, then none of the abstract methods are called in game loop.
        /// </summary>
        public bool IsEnabled;

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

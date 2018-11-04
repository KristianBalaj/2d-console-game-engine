using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class ListenerTest : Component, ICollisionListener
    {
        public ListenerTest(Actor parentActor) : base(parentActor)
        {
        }

        public void OnCollision(ICollidable otherCol)
        {
            System.Diagnostics.Debug.WriteLine("Collision on actor {0} uid {1}", ParentActor.Name, ParentActor.UNIQUE_ID);
        }

        public override void OnDestroy()
        {
        }

        public override void Start()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}

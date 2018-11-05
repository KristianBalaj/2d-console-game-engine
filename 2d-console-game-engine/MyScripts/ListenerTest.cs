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
        }

        public void OnCollisionEnter(ICollidable otherCol)
        {
            System.Diagnostics.Debug.WriteLine("Entering collision on {0}", ParentActor.Name);
        }

        public void OnCollisionExit(ICollidable otherCol)
        {
            System.Diagnostics.Debug.WriteLine("Exiting collision on {0}", ParentActor.Name);
        }

        public override void OnDestroy()
        {
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }
    }
}

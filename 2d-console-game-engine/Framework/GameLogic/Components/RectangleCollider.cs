using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class RectangleCollider : Component, ICollidable
    {
        /// <summary>
        /// Used for continuous collision detection.
        /// </summary>
        private Vector2Int previousPos;

        private Vector2Int boundsSize;

        public RectangleCollider(Actor parentActor) : base(parentActor)
        {
        }

        public override void OnDestroy()
        {
        }

        public override void Start()
        {
            this.previousPos = ParentActor.ClampedPosition;
        }

        public override void Update(float deltaTime)
        {
        }

        public void SetupCollisionBounds(Vector2Int size)
        {
            this.boundsSize = size;
        }

        Bounds ICollidable.GetCollisionBounds()
        {
            // TODO: difference between triggers and colliders
            Vector2Int collisionBoundsSize = new Vector2Int();
            collisionBoundsSize.x = boundsSize.x + Math.Abs(previousPos.x - ParentActor.ClampedPosition.x);
            collisionBoundsSize.y = boundsSize.y + Math.Abs(previousPos.y - ParentActor.ClampedPosition.y);

            Vector2Int boundsTopLeft = new Vector2Int();
            boundsTopLeft.x = Math.Min(ParentActor.ClampedPosition.x, previousPos.x);
            boundsTopLeft.y = Math.Min(ParentActor.ClampedPosition.y, previousPos.y);

            Bounds collBounds = new Bounds(boundsTopLeft, collisionBoundsSize);

            return collBounds;
        }

        void ICollidable.AllignColliders()
        {
            this.previousPos = ParentActor.ClampedPosition;
        }

    }
}

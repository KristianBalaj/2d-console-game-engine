using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface ICollisionListener
    {
        /// <summary>
        /// This is invoked every frame when in collision.
        /// </summary>
        /// <param name="otherCol"></param>
        void OnCollision(ICollidable otherCol);
        /// <summary>
        /// This is triggered in the frame when collided with the other.
        /// </summary>
        /// <param name="otherCol"></param>
        void OnCollisionEnter(ICollidable otherCol);
        /// <summary>
        /// This is triggered in the frame when collision finished with the other.
        /// </summary>
        /// <param name="otherCol"></param>
        void OnCollisionExit(ICollidable otherCol);
    }
}

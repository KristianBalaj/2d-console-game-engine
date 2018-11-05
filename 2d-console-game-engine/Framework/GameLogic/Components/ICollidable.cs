using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface ICollidable
    {
        Bounds GetCollisionBounds();
        void AllignColliders();
        /// <summary>
        /// When istrigger is true, then the collider is used like an area detector. Otherwise it is used like normal solid collider.
        /// </summary>
        bool IsTrigger { get; set; }
    }
}

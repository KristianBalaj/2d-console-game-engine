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
    }
}

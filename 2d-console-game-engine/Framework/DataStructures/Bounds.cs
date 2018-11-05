using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Bounds
    {
        public Vector2Int TopLeft;
        public Vector2Int Size;

        public Bounds(Vector2Int topLeftCorner, Vector2Int size)
        {
            this.TopLeft = topLeftCorner;
            this.Size = size;
        }

        public bool Intersects(Bounds bounds)
        {
            if (TopLeft.x >= bounds.TopLeft.x + bounds.Size.x || bounds.TopLeft.x >= TopLeft.x + Size.x)
            {
                return false;
            }

            if (TopLeft.y >= bounds.TopLeft.y + bounds.Size.y || bounds.TopLeft.y >= TopLeft.y + Size.y)
            {
                return false;
            }

            return true;
        }
    }
}

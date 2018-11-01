using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameEngine
{
    [JsonObject(MemberSerialization.OptIn)]
    public sealed class Vector2Int
    {
        [JsonProperty]
        private int[] vals = new int[2];

        public int x
        {
            get { return vals[0]; }
            set { vals[0] = value; }
        }

        public int y
        {
            get { return vals[1]; }
            set { vals[1] = value; }
        }

        public float Magnitude
        {
            get { return (float)Math.Sqrt(vals[0] * vals[0] + vals[1] * vals[1]); }
        }

        public static Vector2Int Zero { get { return new Vector2Int(); } }
        public static Vector2Int Left { get { return new Vector2Int(-1, 0); } }
        public static Vector2Int Right { get { return new Vector2Int(1, 0); } }
        public static Vector2Int Up { get { return new Vector2Int(0, 1); } }
        public static Vector2Int Down { get { return new Vector2Int(0, -1); } }


        public Vector2Int() : this(0, 0)
        {
        }

        public Vector2Int(int x, int y)
        {
            vals[0] = x;
            vals[1] = y;
        }

        public static float Dot(Vector2Int vec1, Vector2Int vec2)
        {
            return vec1.x * vec2.x + vec1.y + vec2.y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", vals[0], vals[1]);
        }

    }

}

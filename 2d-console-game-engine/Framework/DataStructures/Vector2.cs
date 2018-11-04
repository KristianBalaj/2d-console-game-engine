using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameEngine
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Vector2
    {
        [JsonProperty]
        private float[] vals = new float[2];

        public float x
        {
            get { return vals[0]; }
            set { vals[0] = value; }
        }

        public float y
        {
            get { return vals[1]; }
            set { vals[1] = value; }
        }

        public float Magnitude
        {
            get { return (float)Math.Sqrt(vals[0] * vals[0] + vals[1] * vals[1]); }
        }

        public static Vector2 Zero { get { return new Vector2(); } }
        public static Vector2 Left { get { return new Vector2(-1, 0); } }
        public static Vector2 Right { get { return new Vector2(1, 0); } }
        public static Vector2 Up { get { return new Vector2(0, 1); } }
        public static Vector2 Down { get { return new Vector2(0, -1); } }


        public Vector2() : this(0, 0)
        {
        }

        public Vector2(float x, float y)
        {
            vals[0] = x;
            vals[1] = y;
        }

        public static float Dot(Vector2 vec1, Vector2 vec2)
        {
            return vec1.x * vec2.x + vec1.y + vec2.y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", vals[0], vals[1]);
        }

        public static explicit operator Vector2(Vector2Int vec)
        {
            return new Vector2(vec.x, vec.y);
        }
    }
}

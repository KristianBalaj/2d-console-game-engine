using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class MyMath
    {
        public const float EPSILON = .0001f;

        public static bool Approximately(float x, float y)
        {
            return x >= y - EPSILON && x <= y + EPSILON;
        }

        public static int ClampInt(int min, int max, int x)
        {
            if (min > max)
            {
                return x;
            }

            if (x < min)
            {
                x = min;
            }
            else if (x > max)
            {
                x = max;
            }

            return x;
        }
    }
}

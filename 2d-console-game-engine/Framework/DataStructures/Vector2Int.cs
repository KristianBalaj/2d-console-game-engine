using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vector2Int
    {
        // Fields
        public int x;

        public int y;

        // Indexer
        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case X_INDEX:
                        return this.x;
                    case Y_INDEX:
                        return this.y;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2i index!");
                }
            }
            set
            {
                switch (index)
                {
                    case X_INDEX:
                        this.x = value;
                        break;
                    case Y_INDEX:
                        this.y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector2i index!");
                }
            }
        }

        // Constructors
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Properties
        public float sqrMagnitude
        {
            get { return (float)x * x + (float)y * y; }
        }

        public float magnitude
        {
            get { return (float)Math.Sqrt(sqrMagnitude); }
        }

        public bool IsWithinBounds(Vector2Int from, Vector2Int to)
        {
            return this.x >= from.x && this.x < to.x &&
                    this.y >= from.y && this.y < to.y;
        }

        // Set
        public void Set(int new_x, int new_y)
        {
            this.x = new_x;
            this.y = new_y;
        }

        // Scaling
        public void Scale(Vector2Int scale)
        {
            x *= scale.x;
            y *= scale.y;
        }

        public static Vector2Int Scale(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(
                a.x * b.x,
                a.y * b.y
            );
        }

        // Rotations
        public void RotateCW()
        {
            int old_x = x;
            x = y;
            y = -old_x;
        }

        public void RotateCCW()
        {
            int old_x = x;
            x = -y;
            y = old_x;
        }

        public static Vector2Int RotateCW(Vector2Int a)
        {
            return new Vector2Int(a.y, -a.x);
        }

        public static Vector2Int RotateCCW(Vector2Int a)
        {
            return new Vector2Int(-a.y, a.x);
        }

        // Loops
        public static void RectLoop(Vector2Int from, Vector2Int to, Action<Vector2Int> body)
        {
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Vector2Int iterator = Vector2Int.zero;
            for (iterator.x = from.x; iterator.x < to.x; iterator.x++)
            {
                for (iterator.y = from.y; iterator.y < to.y; iterator.y++)
                {
                    body(iterator);
                }
            }
        }

        // ToString
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }

        // Operators
        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(
                a.x + b.x,
                a.y + b.y
            );
        }

        public static Vector2Int operator -(Vector2Int a)
        {
            return new Vector2Int(
                -a.x,
                -a.y
            );
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return a + (-b);
        }

        public static Vector2Int operator *(int d, Vector2Int a)
        {
            return new Vector2Int(
                d * a.x,
                d * a.y
            );
        }

        public static Vector2Int operator *(Vector2Int a, int d)
        {
            return d * a;
        }

        public static Vector2Int operator /(Vector2Int a, int d)
        {
            return new Vector2Int(
                a.x / d,
                a.y / d
            );
        }

        // Equality
        public static bool operator ==(Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator !=(Vector2Int lhs, Vector2Int rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector2Int))
            {
                return false;
            }
            return this == (Vector2Int)other;
        }

        public bool Equals(Vector2Int other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (x.GetHashCode() << 6) ^ y.GetHashCode();
        }

        // Static methods

        public static float Distance(Vector2Int a, Vector2Int b)
        {
            return (a - b).magnitude;
        }

        public static Vector2Int Min(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(
                Math.Min(lhs.x, rhs.x),
                Math.Min(lhs.y, rhs.y)
            );
        }

        public static Vector2Int Max(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(
                Math.Max(a.x, b.x),
                Math.Max(a.y, b.y)
            );
        }

        public static int Dot(Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.x * rhs.x +
                    lhs.y * rhs.y;
        }

        public static float Magnitude(Vector2Int a)
        {
            return a.magnitude;
        }

        public static float SqrMagnitude(Vector2Int a)
        {
            return a.sqrMagnitude;
        }

        // Default values
        public static Vector2Int down
        {
            get { return new Vector2Int(0, -1); }
        }

        public static Vector2Int up
        {
            get { return new Vector2Int(0, +1); }
        }

        public static Vector2Int left
        {
            get { return new Vector2Int(-1, 0); }
        }

        public static Vector2Int right
        {
            get { return new Vector2Int(+1, 0); }
        }

        public static Vector2Int one
        {
            get { return new Vector2Int(+1, +1); }
        }

        public static Vector2Int zero
        {
            get { return new Vector2Int(0, 0); }
        }

        // Constants
        public const int X_INDEX = 0;
        public const int Y_INDEX = 1;
    }


}

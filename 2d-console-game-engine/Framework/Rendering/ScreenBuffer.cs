using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ScreenBuffer<T>
    {
        private readonly T emptyValue;
        private T[,] internalBuffer;

        public int GetWidth { get { return internalBuffer.GetLength(0); } }
        public int GetHeight { get { return internalBuffer.GetLength(1); } }

        public T GetEmptyValue { get { return emptyValue; } }

        // Indexer method
        public T this[int x, int y]
        {
            get { return internalBuffer[x, y]; }
            set { internalBuffer[x, y] = value; }
        }

        // Constructor
        public ScreenBuffer(int width, int height, T emptyValue)
        {
            this.internalBuffer = new T[width, height];
            this.emptyValue = emptyValue;
        }

        public ScreenBuffer(Vector2Int size, T emptyValue) : this(size.x, size.y, emptyValue)
        {
        }

        /// <summary>
        /// Sets every position in the buffer to empty value
        /// </summary>
        public void ClearBuffer()
        {
            float width, height;

            width = GetWidth;
            height = GetHeight;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    internalBuffer[x, y] = emptyValue;
                }
            }
        }

        public T Get(int x, int y)
        {
            return internalBuffer[x, y];
        }

        public void Set(int x, int y, T character)
        {
            internalBuffer[x, y] = character;
        }
    }
}

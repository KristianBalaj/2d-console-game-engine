using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ConsoleRenderer : Renderer
    {
        private ScreenBuffer<char> previousBuffer;
        private Bounds screenBounds;

        public ConsoleRenderer(int screenWidth, int screenHeight) : base(screenWidth, screenHeight)
        {
            previousBuffer = new ScreenBuffer<char>(screenWidth, screenHeight, ' ');
            previousBuffer.ClearBuffer();

            screenBounds = new Bounds(Vector2Int.Zero, new Vector2Int(screenWidth, screenHeight));
        }

        /// <summary>
        /// This method combines screen buffers from all the renderables according to their sortOrders.
        /// </summary>
        /// <param name="renderablesToCombineIntoSingleBuffer"></param>
        /// <returns></returns>
        public override object CombineRenderables(IEnumerable<IRenderable> renderablesToCombineIntoSingleBuffer)
        {
            IRenderable[] sortedRenderables = renderablesToCombineIntoSingleBuffer.OrderByDescending(rend => rend.GetSortOrder).ToArray();

            ScreenBuffer<char> result = new ScreenBuffer<char>(SCREEN_WIDTH, SCREEN_HEIGHT, previousBuffer.GetEmptyValue);
            result.ClearBuffer();

            char emptyValue = previousBuffer.GetEmptyValue;

            foreach (var renderable in sortedRenderables)
            {
                var tempResult = renderable.OnRender() as ScreenBuffer<char>;

                Bounds renderableBounds = renderable.GetBounds();

                if (renderableBounds.Intersects(screenBounds))
                {
                    for (int x = MyMath.ClampInt(0, SCREEN_WIDTH, renderableBounds.TopLeft.x), localX = 0; x < MyMath.ClampInt(0, SCREEN_WIDTH, renderableBounds.TopLeft.x + renderableBounds.Size.x); x++, localX++)
                    {
                        for (int y = MyMath.ClampInt(0, SCREEN_HEIGHT, renderableBounds.TopLeft.y), localY = 0; y < MyMath.ClampInt(0, SCREEN_HEIGHT, renderableBounds.TopLeft.y + renderableBounds.Size.y); y++, localY++)
                        {
                            if (tempResult[localX, localY] != emptyValue && result[x, y] == emptyValue)
                            {
                                result[x, y] = tempResult[localX, localY];
                            }
                        }
                    }
                }
            }

            return result;
        }

        public override void Draw(object displayBuffer)
        {
            if (!(displayBuffer is ScreenBuffer<char>))
            {
                throw new WrongScreenBufferTypeException();
            }

            var bufferToDraw = displayBuffer as ScreenBuffer<char>;

            for (int x = 0; x < SCREEN_WIDTH; x++)
            {
                for (int y = 0; y < SCREEN_HEIGHT; y++)
                {
                    if (previousBuffer[x, y] != bufferToDraw[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(bufferToDraw[x, y]);

                        previousBuffer[x, y] = bufferToDraw[x, y];
                    }
                }
            }
        }

        public override void Init()
        {
            Console.CursorVisible = false;
        }
    }
}

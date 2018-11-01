using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class Renderer
    {
        public readonly int SCREEN_WIDTH;
        public readonly int SCREEN_HEIGHT;

        public Vector2Int GetRendererSize { get { return new Vector2Int(SCREEN_WIDTH, SCREEN_HEIGHT); } }

        public Renderer(int screenWidth, int screenHeight)
        {
            if (screenWidth % 2 != 1 || screenHeight % 2 != 1)
            {
                throw new Exception("Make the size of the renderer odd!");
            }

            this.SCREEN_HEIGHT = screenHeight;
            this.SCREEN_WIDTH = screenWidth;
        }

        public abstract void Init();
        public abstract void Draw(object displayBuffer);

        public abstract object CombineRenderables(IEnumerable<IRenderable> renderablesToCombineIntoSingleBuffer);
    }

}

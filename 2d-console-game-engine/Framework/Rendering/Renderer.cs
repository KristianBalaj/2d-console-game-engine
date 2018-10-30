using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Renderer
    {
        protected readonly int SCREEN_WIDTH;
        protected readonly int SCREEN_HEIGHT;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ConsoleRenderComponent : Component, IRenderable
    {
        private int sortOrder = 0;
        private ScreenBuffer<char> currentRenderBuffer = new ScreenBuffer<char>(new Vector2Int(1, 1), '█');

        public int GetSortOrder { get { return sortOrder; } }

        public ConsoleRenderComponent(Actor parentActor) : base(parentActor) { }

        public override void OnDestroy() { }

        public override void Start()
        {
        }

        public override void Update(float deltaTime)
        {
        }

        public object OnRender()
        {
            ScreenBuffer<char> representation = currentRenderBuffer;
            representation.ClearBuffer();

            return representation;
        }

        public Bounds GetBounds()
        {
            return new Bounds(ParentActor.Position, currentRenderBuffer.GetSize);
        }

        public void ChangeRendering(Vector2Int size, int sortOrder, char character)
        {
            this.sortOrder = sortOrder;
            this.currentRenderBuffer = new ScreenBuffer<char>(size, character);
        }
    }
}

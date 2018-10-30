using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConsoleRenderComponent : Component, IRenderable
    {
        public Vector2Int size;

        public int GetSortOrder => 0;

        public ConsoleRenderComponent(Actor parentActor) : base(parentActor) { }

        public override void OnDestroy() { }

        public override void Start()
        {
            this.size = new Vector2Int(5, 3);
        }

        public override void Update(float deltaTime)
        {
        }

        public object OnRender()
        {
            ScreenBuffer<char> representation = new ScreenBuffer<char>(size, '█');
            representation.ClearBuffer();

            return representation;
        }

        public Bounds GetBounds()
        {
            return new Bounds(ParentActor.Position, size);
        }
    }
}

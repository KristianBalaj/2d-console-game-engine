using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ActorsFactory
    {
        public Actor CreatePlayer(Vector2 position)
        {
            Actor newAct = new Actor(position, "Player");
            var renderComponent = newAct.AddComponent<ConsoleRenderComponent>();
            newAct.AddComponent<MovementComponent>();
            newAct.AddComponent<ListenerTest>();
            var coll = newAct.AddComponent<RectangleCollider>();

            coll.SetupCollisionBounds(new Vector2Int(2, 2), false);
            renderComponent.ChangeRendering(new Vector2Int(2, 2), 0, '*');

            return newAct;
        }

        public Actor CreateTest(Vector2 position)
        {
            Actor newAct = new Actor(position, "TesterAct");
            var renderComponent = newAct.AddComponent<ConsoleRenderComponent>();
            //newAct.AddComponent<MovementComponent>();
            newAct.AddComponent<ListenerTest>();
            var coll = newAct.AddComponent<RectangleCollider>();

            coll.SetupCollisionBounds(new Vector2Int(2, 2), false);
            renderComponent.ChangeRendering(new Vector2Int(2, 2), 0, 't');

            return newAct;
        }

    }
}

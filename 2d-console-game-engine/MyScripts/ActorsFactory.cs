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

            renderComponent.ChangeRendering(new Vector2Int(2, 2), 0, '*');

            return newAct;
        }

    }
}

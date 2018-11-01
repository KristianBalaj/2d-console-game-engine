using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class ActorsFactory
    {
        public Actor CreatePlayer()
        {
            ActorManager.LastActorUniqueID++;
            Actor newAct = new Actor(Vector2Int.Zero, ActorManager.LastActorUniqueID, "Player");
            var renderComponent = newAct.AddComponent<ConsoleRenderComponent>();
            newAct.AddComponent<MovementComponent>();

            renderComponent.ChangeRendering(new Vector2Int(2, 2), 0, '█');

            return newAct;
        }

    }
}

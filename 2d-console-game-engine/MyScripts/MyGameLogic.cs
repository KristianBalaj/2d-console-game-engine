using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyGameLogic : GameLogicBase
    {
        public override void InitLogic()
        {
            Actor newActor = new Actor(Vector2Int.zero, 0, "NewActor");
            newActor.AddComponent<ConsoleRenderComponent>();
            newActor.AddComponent<MovementComponent>();

            this.actorManager.AddActor(newActor);
        }
    }
}

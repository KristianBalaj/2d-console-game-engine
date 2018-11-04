using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class MyGameLogic : GameLogicBase
    {
        public override void InitLogic()
        {
            ActorsFactory factory = new ActorsFactory();

            this.actorManager.AddActor(factory.CreatePlayer(Vector2.Zero));
        }
    }
}

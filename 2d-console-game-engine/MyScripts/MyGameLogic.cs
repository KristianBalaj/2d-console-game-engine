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
            this.actorManager.AddActor(factory.CreateTest(new Vector2(5, 5)));
            this.actorManager.AddActor(factory.CreateTest(new Vector2(8, 8)));
            this.actorManager.AddActor(factory.CreateTest(new Vector2(2, 8)));
            this.actorManager.AddActor(factory.CreateTest(new Vector2(2, 11)));

        }
    }
}

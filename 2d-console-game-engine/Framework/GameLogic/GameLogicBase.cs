using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class GameLogicBase
    {
        private GameStateBase currentGameState;
        protected ActorManager actorManager;

        public GameLogicBase()
        {
            this.actorManager = new ActorManager();
        }

        public void ChangeGameState(GameStateBase newState)
        {
            newState.InitializeState();

            if (currentGameState != null)
            {
                currentGameState.FinishState();
            }

            currentGameState = newState;
        }

        public void UpdateLogic(float deltaTime)
        {
            if (currentGameState != null)
            {
                currentGameState.UpdateState(deltaTime);
            }

            actorManager.StartActors();
            actorManager.UpdateActors(deltaTime);
        }

        public IEnumerable<IRenderable> GetRenderables()
        {
            return actorManager.GetRenderables();
        }

        // Creates actors and components, sets game state
        public abstract void InitLogic();
    }
}

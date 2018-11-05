using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
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

        public void UpdateLogic()
        {
            if (currentGameState != null)
            {
                currentGameState.UpdateState();
            }

            actorManager.StartActors();
            actorManager.UpdateActors();
        }

        public IEnumerable<IRenderable> GetRenderables()
        {
            return actorManager.GetRenderables();
        }

        // Creates actors and components, sets game state
        public abstract void InitLogic();
    }
}

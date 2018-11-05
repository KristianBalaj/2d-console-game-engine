using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class GameCodeBase
    {
        private readonly int MS_PER_FRAME = 1000 / 60;

        private EventManager eventManager;
        private Renderer currentRenderer;
        private PhysicsManager physicsManager;
        private GameLogicBase currentGameLogic;
        private InputManager inputManager;

        /// <summary>
        /// Keys are the string IDs.
        /// </summary>
        private Dictionary<string, string> gameStrings;

        /// <summary>
        /// Creates event manager, loads strings, creates game logic & views, loads initial game options, inits rendering device + window
        /// </summary>
        public void InitInstance()
        {
            this.gameStrings = loadStrings();

            this.eventManager = new EventManager();
            this.inputManager = new InputManager();
            this.currentRenderer = initializeRendering();
            this.physicsManager = new PhysicsManager();
            this.currentGameLogic = createGame();

            this.inputManager.InitInputManager(gameStrings["Input"]);

            this.currentRenderer.Init();
            this.currentGameLogic.InitLogic();
            // logic & views

            while (true)
            {
                long start = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                Time.UpdateTime(MS_PER_FRAME / 1000.0f);

                this.inputManager.ProcessInput();

                this.currentGameLogic.UpdateLogic();

                physicsManager.ProcessCollisions();

                render();

                int dt = (int)(start - DateTimeOffset.Now.ToUnixTimeMilliseconds());

                if (dt + MS_PER_FRAME > 0)
                {
                    System.Threading.Thread.Sleep(dt + MS_PER_FRAME);
                }
            }
        }

        public string GetString(string id)
        {
            string result;

            if (gameStrings.TryGetValue(id, out result))
            {
                return result;
            }

            return string.Empty;
        }

        private void render()
        {
            object resultScreenBuffer = currentRenderer.CombineRenderables(currentGameLogic.GetRenderables());
            currentRenderer.Draw(resultScreenBuffer);
        }

        protected abstract Dictionary<string, string> loadStrings();
        protected abstract GameLogicBase createGame();
        protected abstract Renderer initializeRendering();
    }
}

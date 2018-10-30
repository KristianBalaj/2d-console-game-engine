using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;

namespace ConsoleApp1
{
    public class RunningGameState : GameStateBase
    {
        public override void FinishState()
        {
        }

        public override void InitializeState()
        {
        }

        public override void UpdateState(float deltaTime)
        {
            Debug.WriteLine("Updating game state");
        }
    }
}

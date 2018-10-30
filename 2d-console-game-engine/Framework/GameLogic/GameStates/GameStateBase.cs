using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class GameStateBase
    {
        public abstract void InitializeState();
        public abstract void UpdateState(float deltaTime);
        public abstract void FinishState();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public abstract class GameStateBase
    {
        public abstract void InitializeState();
        public abstract void UpdateState();
        public abstract void FinishState();
    }
}

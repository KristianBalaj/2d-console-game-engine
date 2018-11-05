using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class Time
    {
        /// <summary>
        /// Contains the number of updates since the Game Engine start.
        /// </summary>
        // The Game Engine would have to run for cca 9 bilion years to make this TicksCount variable overflow.
        public static ulong TicksCount { get; private set; } = 0;
        /// <summary>
        /// Stores current frame's delta time.
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// Updates all the Time variables.
        /// </summary>
        /// <param name="deltaTime"></param>
        public static void UpdateTime(float deltaTime)
        {
            DeltaTime = deltaTime;
            TicksCount++;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace benjohnson
{
    public class Timer
    {
        private float duration;
        private float elapsed;
        public event Action onTimerComplete; // Function called when timer is complete

        public Timer(float duration)
        {
            this.duration = duration;
            elapsed = 0;
        }

        // Overload including callback function
        public Timer(float duration, Action onTimerComplete) : this(duration)
        {
            this.onTimerComplete = onTimerComplete;
        }

        public void Tick(float deltaTime)
        {
            if (elapsed == duration)
                return; // Timer is already complete, do not update

            elapsed += deltaTime;

            if (elapsed > duration)
            {
                // Timer complete
                elapsed = duration;
                onTimerComplete?.Invoke();
            }
        }

        // Returns time remaining in seconds
        public float TimeRemaining()
        {
            return duration - elapsed;
        }
    }
}

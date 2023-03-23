using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame
{
    // Singleton
    public class Timer
    {
        int maxTime = 300;
        int currentTime = 0;
        DateTime lastTime;

        public static Timer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Timer();
                }

                return instance;
            }
        }

        static Timer instance;

        public Timer()
        {
            ResetTime();
        }

        public void SetStartTime()
        {
            lastTime = DateTime.Now;
        }

        public void ResetTime()
        {
            currentTime = maxTime;
        }

        public string PrintTimer()
        {
            TimeSpan diff = DateTime.Now - lastTime;
            int seconds = (int)diff.TotalSeconds;
            lastTime = DateTime.Now;
            SubtractTime(seconds);

            int minutes = (int)Math.Floor((double)currentTime / 60);
            int dseconds = currentTime % 60;

            return $"Time left: {minutes}:{dseconds}";
        }

        public bool IsTimeRemaining()
        {
            TimeSpan diff = DateTime.Now - lastTime;
            int seconds = (int)diff.TotalSeconds;
            lastTime = DateTime.Now;
            SubtractTime(seconds);

            return currentTime > 0;
        }

        void SubtractTime(int seconds)
        {
            currentTime -= seconds;
        }
    }
}

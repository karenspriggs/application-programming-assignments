using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame
{
    // Singleton
    public class PlayerLives
    {
        int maxLives = 5;
        int lives;

        public static PlayerLives Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerLives();
                }

                return instance;
            }
        }

        static PlayerLives instance;

        public PlayerLives()
        {
            ResetLives();
        }

        public void DepleteLife()
        {
            lives--;
        }

        public void ResetLives()
        {
            lives = maxLives;
        }

        public string PrintLives()
        {
            return $"You have {lives} lives left";
        }

        public bool IsDead() 
        {
            return lives <= 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Characters;

namespace CPUBattleApp
{
    public class Wind
    {
        List<Character> characters;
        int maxWindDamage;
        int minWindDamage;
        public int actualWindDamage;

        // Initialize wind values
        public void StartWind(int min, int max)
        {
            this.minWindDamage = min;
            this.maxWindDamage = max;
        }

        // Knocks down each players tower by a random amount of blocks
        public void Notify()
        {
            foreach (Character c in characters)
            {
                actualWindDamage = new Random().Next(minWindDamage, maxWindDamage);
                c.Update(this);
            }
        }

        // Attaches self to a character
        public void Attach(Character character)
        {
            characters.Add(character);
        }

        // Removes self from a character
        public void Remove(Character character)
        {
            characters.Remove(character);
        }
    }
}

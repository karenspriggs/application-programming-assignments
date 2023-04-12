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
        List<ICharacter> characters;
        int maxWindDamage;
        int minWindDamage;
        public int actualWindDamage;
        Random random = new Random();

        // Initialize wind values
        public void StartWind(int min, int max)
        {
            characters = new List<ICharacter>();
            this.minWindDamage = min;
            this.maxWindDamage = max;
        }

        // Knocks down each players tower by a random amount of blocks
        public void Notify()
        {
            foreach (ICharacter c in characters)
            {
                actualWindDamage = random.Next(minWindDamage, maxWindDamage);
                c.Update(this);
            }
        }

        // Attaches self to a character
        public void Attach(ICharacter character)
        {
            characters.Add(character);
        }

        // Removes self from a character
        public void Remove(ICharacter character)
        {
            characters.Remove(character);
        }
    }
}

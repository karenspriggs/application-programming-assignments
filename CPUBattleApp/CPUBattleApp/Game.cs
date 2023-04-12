using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Characters;

namespace CPUBattleApp
{
    internal class Game<T, U> where T : ICharacter
                                  where U : ICharacter
    {
        public void BeginGame(T char1, U char2)
        {
            PlayerSetup(char1);
            Play(char1, char2);
        }

        public void PlayerSetup(ICharacter playerCharacter)
        {

        }

        public void Play(ICharacter playerCharacter, ICharacter computer)
        {
            // Max tower height is 100, if a character hits this height then they win
            while (playerCharacter.TowerHeight < 100 && computer.TowerHeight < 100)
            {
                DoRound(playerCharacter, computer);
            }
        }

        public void DoRound(ICharacter playerCharacter, ICharacter computer)
        {
            TakeTurn(playerCharacter);
            TakeTurn(computer);
            // do wind damage
        }

        public void TakeTurn(ICharacter turnCharacter)
        {
            turnCharacter.DescribeTurn();
        }
    }
}

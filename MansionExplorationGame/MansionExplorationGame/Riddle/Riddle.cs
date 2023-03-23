using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Riddle
{
    public class RiddleB : RiddleBase
    {
        RiddleBank riddleBank;

        public RiddleB(string _riddleKey)
        {
            riddleBank = new RiddleBank();

            this.Prompt = riddleBank.GetRiddlePrompt(_riddleKey);
            this.Answer = riddleBank.GetRiddleAnswer(_riddleKey);
        }
    }
}

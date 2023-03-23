using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Riddle
{
    public class RiddleBank
    {
        // Riddles from : https://www.riddles.com/

        public string GetRiddlePrompt(string riddleKey)
        {
            switch (riddleKey)
            {
                case ("circle"):
                    return "How many sides does a circle have?\n1)Two\n2)One\n3)None";
                case ("house"):
                    return "You live in a one story house made entirely of redwood.\nAre your stairs also red (true or false)?";
                case ("steps"):
                    return "The more of me you take, the more of me you leave behind. What am I?\n1)Naps\n2)Footsteps\n3)Love";
                case ("family"):
                    return "Mr. and Mrs. Mustard have six daughters and each daughter has one brother.\nDoes the Mustard family have nine members (true or false)?";
                case ("broken"):
                    return "What is more useful when it is broken?\n1)A promise\n2)An egg\n3)A heart";
                case ("catch"):
                    return "What can you catch but never throw?\n1)A ball\n2)These hands\n3)A cold";
                default: return "Default prompt";
            }
        }

        public string GetRiddleAnswer(string riddleKey)
        {
            switch (riddleKey)
            {
                case ("circle"):
                    return "1";
                case ("house"):
                    return "false";
                case ("steps"):
                    return "2";
                case ("family"):
                    return "true";
                case ("broken"):
                    return "2";
                case ("catch"):
                    return "3";

                default: return "Default answer";
            }
        }
    }
}

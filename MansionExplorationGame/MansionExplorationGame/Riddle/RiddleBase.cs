using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame
{
    public class RiddleBase
    {
        public string Prompt { get; set; } = "";
        public string Answer { get; set; } = "";

        public void PrintRiddle()
        {
            Console.WriteLine(Prompt);
        }

        public bool IsCorrectAnswer(string attempt)
        {
            return attempt.ToLower() == Answer.ToLower();
        }
    }
}

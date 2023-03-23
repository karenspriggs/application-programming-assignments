using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MansionExplorationGame.Riddle;

namespace MansionExplorationGame.Level
{
    public abstract class LevelBase : ILevel
    {
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public string Boss { get; set; }
        public string RiddleID { get; set; }

        RiddleBase FloorRiddle;

        public IItem FloorItem { get; set; }

        public LevelBase(string _riddleID)
        {
            RiddleID = _riddleID;
            FloorRiddle = new RiddleB(RiddleID);
        }

        public void PrintLevelContent()
        {
            Console.WriteLine($"Welcome to floor {FloorNumber}, the {Name}.\n{Boss} greets you as you enter and asks you a riddle:");
            Console.WriteLine("");
            FloorRiddle.PrintRiddle();
        }

        public bool CompareAnswer(string input)
        {
            return input == FloorRiddle.Answer;
        }
    }
}

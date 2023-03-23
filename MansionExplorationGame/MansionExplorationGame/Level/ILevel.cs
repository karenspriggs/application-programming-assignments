using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Level
{
    public interface ILevel
    {
        string Name { get; set; }
        int FloorNumber { get; set; }
        string Boss { get; set; }
        string RiddleID { get; set; }
        IItem FloorItem { get; set; }

        void PrintLevelContent();
        bool CompareAnswer(string input);
    }
}

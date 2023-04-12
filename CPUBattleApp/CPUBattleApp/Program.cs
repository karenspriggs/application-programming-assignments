using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Characters;

namespace CPUBattleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Character playerChar = new Character();
            Character computerChar = new Character() { Name = "Puter", Inventory = new List<Items.IItem>() { new Items.Item("Thing1", 2), new Items.Item("Thing2", 3) } };

            Game<Character, Character> game = new Game<Character, Character>();

            game.BeginGame(playerChar, computerChar);
        }
    }
}

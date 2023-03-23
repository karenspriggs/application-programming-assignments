using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Receivers
{
    public class FoodReceiver : ItemReceiver
    {
        public override void ProcessRequest(IItem item)
        {
            if (item.Type == "Food")
            {
                Console.WriteLine($"You have obtained the {item.Describe()} using your food processor");
            }
            else
            {
                NextReceiver.ProcessRequest(item);
            }
        }
    }
}

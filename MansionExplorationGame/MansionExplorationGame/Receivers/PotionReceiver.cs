using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Receivers
{
    public class PotionReceiver : ItemReceiver
    {
        public override void ProcessRequest(IItem item)
        {
            if (item.Type == "Potion")
            {
                Console.WriteLine($"You have obtained the {item.Describe()} using your potion processor");
            }
            else
            {
                NextReceiver.ProcessRequest(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Receivers
{
    public abstract class ItemReceiver : IReceiver
    {
        public IReceiver NextReceiver { get; set; }

        public virtual void ProcessRequest(IItem item)
        {
            if (item.Type == "Item")
            {
                Console.WriteLine($"You have obtained the {item.Describe()} using your item processor");
            } else
            {
                NextReceiver.ProcessRequest(item);
            }
        }

        public void SetNextReceiver(IReceiver next)
        {
            this.NextReceiver = next;
        }
    }
}

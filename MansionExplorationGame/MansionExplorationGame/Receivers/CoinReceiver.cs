﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Receivers
{
    public class CoinReceiver : ItemReceiver
    {
        public override void ProcessRequest(IItem item)
        {
            if (item.Type == "Coin")
            {
                Console.WriteLine($"You have obtained the {item.Describe()} using your coin processor");
            }
            else
            {
                NextReceiver.ProcessRequest(item);
            }
        }
    }
}

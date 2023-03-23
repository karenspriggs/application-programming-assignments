using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Receivers
{
    public interface IReceiver
    {
        IReceiver NextReceiver { get; set; }
        void ProcessRequest(IItem item);
        void SetNextReceiver(IReceiver next);
    }
}

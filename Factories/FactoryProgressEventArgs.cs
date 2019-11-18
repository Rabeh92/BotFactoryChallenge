using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class FactoryProgressEventArgs : EventArgs, IFactoryProgressEventArgs
    {
        public string NewStatus { get; set; }
        public IFactoryQueueElement QueueElement { get; set; }
        public ITestingUnit TestingUnit { get; set; }
    }
}

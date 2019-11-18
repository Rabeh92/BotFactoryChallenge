using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        public string NewStatus { get; set; }

    }
}

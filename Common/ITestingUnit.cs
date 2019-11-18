using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;
using BotFactory.Common.Tools;

namespace BotFactory.Interface
{
    public interface ITestingUnit
    {
        bool IsWorking { get; set; }
        string Name { set; }
        double Speed { get; set; }
        double BuildTime { get; set; }
        Coordinates CurrentPos { get; set; }
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }

        event EventHandler UnitStatusChanged;

        Task<bool> MoveAsync(Coordinates currentPos, Coordinates targetPos);
        Task<bool> WorkBeginsAsync();
        Task<bool> WorkEndsAsync();

        


    }
}

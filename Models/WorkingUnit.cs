using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BotFactory.Interface;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit,IWorkingUnit, ITestingUnit
    {
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        protected bool isWorking { get; set; }
        public bool IsWorking
        {
            get
            {
                return isWorking;
            }

            set
            {
                isWorking = value;
                StatusChangedEventArgs eventArg = new StatusChangedEventArgs();
                eventArg.NewStatus = isWorking ?
                    "began working at " + DateTime.Now.ToString()
                    : "Stoped charging at " + DateTime.Now.ToString();
                OnStatusChanged(eventArg);
            }
        }
        public WorkingUnit(double speed, double buildTime)
            : base(speed, buildTime)
        {

        }
        public virtual async Task<bool> WorkBeginsAsync()
        {
            var result = await MoveAsync(CurrentPos, WorkingPos);
            if (result)
            {
                IsWorking = result;
            }
            return result;
        }
        public virtual async Task<bool> WorkEndsAsync()
        {
            IsWorking = false;
            var result = await MoveAsync(CurrentPos, ParkingPos);
            return result;
        }

    }
}

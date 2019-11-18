using BotFactory.Common.Tools;
using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        protected string name { get; set; }
        protected double speed { get; set; }
        protected Coordinates currentPos { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public Coordinates CurrentPos
        {
            get
            {
                return currentPos;
            }
            set
            {
                currentPos = value;
                StatusChangedEventArgs e = new StatusChangedEventArgs();
                e.NewStatus = DateTime.Now.ToString() + "Moved to" + currentPos;
                base.OnStatusChanged(e);
            }

        }

        public BaseUnit()
        {
            currentPos = new Coordinates();
            speed = 1.0;
        }
        public BaseUnit(string name, double speed)
        {
            this.name = name;
            this.speed = speed;
            CurrentPos = new Coordinates();
        }
        public BaseUnit(double speed, double buildTime)
            : base(buildTime)
        {
            this.speed = speed;
            CurrentPos = new Coordinates();
        }
        private async Task SimulateMoveTime(double movingTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(movingTime));
        }
        public async Task<bool> MoveAsync(Coordinates currentPos, Coordinates targetPos)
        {
            if (!currentPos.Equals(targetPos))
            {
                Vector vector = Vector.FromCoordinates(currentPos, targetPos);
                var vectorLength = vector.Length();
                var movingTime = vectorLength / Speed;
                await SimulateMoveTime(movingTime);
                CurrentPos = targetPos;
                return true;
            }
            return false;
        }

    }
}

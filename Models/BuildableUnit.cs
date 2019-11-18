using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        protected double buildTime;
        public double BuildTime
        {
            get
            {
                return buildTime;
            }
            set
            {
                if (value > 0.0)
                {
                    buildTime = value;
                }
            }
        }
        public string Model
        {
            get
            {
                return base.GetType().Name;
            }
        }
        public BuildableUnit(double buildTime = 5.0)
        {
            BuildTime = buildTime;
        }
    }
}

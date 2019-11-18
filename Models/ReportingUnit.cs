using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;
namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {
        public event EventHandler UnitStatusChanged;
        public ReportingUnit()
        {

        }
        public ReportingUnit(double buildTime)
            : base(buildTime)
        {

        }
        protected virtual void OnStatusChanged(IStatusChangedEventArgs args)
        {
            UnitStatusChanged?.Invoke(this, (StatusChangedEventArgs)args);
        }

    }
}

using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        
        public Coordinates(double x=0 , double y=0)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))

                return false;
            else
            {
                Coordinates coordinate = (Coordinates)obj;
                return (X == coordinate.X) && (Y == coordinate.Y);
            }

        }
    }
}

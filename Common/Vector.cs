using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vector()
        {

        }
        public Vector(double x , double y)
        {
            X = x;
            Y = y;
        }
        public static Vector FromCoordinates(Coordinates begin,Coordinates end)
        {
            return new Vector(end.X - begin.X, end.Y - begin.Y);
        }
        public double Length()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }


    }
}

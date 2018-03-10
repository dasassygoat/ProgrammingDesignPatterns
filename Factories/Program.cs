using System;
using static System.Console;

namespace Factories
{
    public static class PointFactory
    {
        public static Point NewPolorPoint(double rho, double theta)
        {
            return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }

        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
    }
    public class Point
    {
        
        private double x, y;

        //cant override the constructor.
        public  Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        { 
            var point = PointFactory.NewPolorPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }
}
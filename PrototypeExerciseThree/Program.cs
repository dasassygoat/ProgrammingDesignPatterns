using System;

namespace PrototypeExerciseThree
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            // todo
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line();
            line.Start = new Point();
            line.Start.X = 199;
            line.Start.Y = 234;
            line.End = new Point();
            line.End.X = 233;
            line.End.Y = 199;
            
            var line2 = line.DeepCopy();
            line2.Start.X = 45;
            
            System.Console.WriteLine($"Line 1 Start X: {line.Start.X}");
            System.Console.WriteLine($"Line 2 Start X: {line2.Start.X}");

        }
    }
}
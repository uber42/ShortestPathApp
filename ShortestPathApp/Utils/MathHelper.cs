using System;
using System.Drawing;

namespace ShortestPathApp.Utils
{
    static class MathHelper
    {
        static public Func<int, int> GetLinearFunc(Point begin, Point end)
        {
            return (x) =>
            {
                return (x - begin.X) * (end.Y - begin.Y) / (end.X - begin.X) + begin.Y;
            };
        }

        static public Func<int, Point> GetLengthFunction(Point begin, Point end)
        {
            int nNodeRadius = Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius;
            Point nBeginVertex = new Point(
                            begin.X + nNodeRadius,
                            begin.Y + nNodeRadius
                            );
            Point nEndVertex = new Point(
                            end.X + nNodeRadius,
                            end.Y + nNodeRadius
                            );

            int xDiff = nBeginVertex.X - nEndVertex.X;
            int yDiff = nBeginVertex.Y - nEndVertex.Y;

            double angle = Math.Atan((double)yDiff / xDiff);
            int xCenter = nBeginVertex.X;
            int yCenter = nBeginVertex.Y;

            if (xDiff >= 0)
            {
                angle += Math.PI;
            }

            return (offset) =>
            {
                Point result = new Point();
                result.X = (int)((offset) * Math.Cos(angle)) + xCenter;
                result.Y = (int)((offset) * Math.Sin(angle)) + yCenter;
                return result;
            };
        }
    }
}
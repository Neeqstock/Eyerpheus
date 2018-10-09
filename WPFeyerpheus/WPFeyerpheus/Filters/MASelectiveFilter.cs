using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    class MASelectiveFilter : IFilter
    {
        private Point[] points;
        private Point lastMean = new Point(0, 0);
        private int maxVariance;

        public MASelectiveFilter(int arrayDimension, int maxVariance)
        {
            this.points = new Point[arrayDimension];
            this.maxVariance = maxVariance;
        }

        public void push(Point point)
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                points[i + 1] = points[i];
            }
            points[0] = point;
        }

        public Point getMean()
        {
            int x = 0;
            int y = 0;
            foreach (Point point in points)
            {
                if (Math.Abs(x - lastMean.X) < maxVariance)
                {
                    x += (int)point.X;
                }
                if (Math.Abs(y - lastMean.Y) < maxVariance)
                {
                    y += (int)point.Y;
                }
            }
            x = (int)(x / points.Length);
            y = (int)(y / points.Length);
            this.lastMean.X = x;
            this.lastMean.Y = y;
            return new Point(x, y);
        }
    }
}

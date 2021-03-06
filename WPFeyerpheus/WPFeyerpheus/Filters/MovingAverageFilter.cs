﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    class MovingAverageFilter : IFilter
    {
        private Point[] points;

        public MovingAverageFilter(int arrayDimension)
        {
            this.points = new Point[arrayDimension];
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
                x += (int)point.X;
                y += (int)point.Y;
            }
            x = (int)(x / points.Length);
            y = (int)(y / points.Length);
            return new Point(x, y);
        }
    }
}

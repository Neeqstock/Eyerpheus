using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    class ExpDecayingFilter : IFilter
    {
        private Point PointI = new Point(0, 0);
        private Point PointIplusOne = new Point(0, 0);
        private float alpha;

        /// <summary>
        /// Alpha indicates the speed of decreasing priority of the old values.
        /// </summary>
        /// <param name="alpha"></param>
        public ExpDecayingFilter(float alpha)
        {
            this.alpha = alpha;
        }

        public void push(Point point)
        {
            PointI.X = PointIplusOne.X;
            PointI.Y = PointIplusOne.Y;
            Console.WriteLine(alpha);
            PointIplusOne.X = (int)(alpha * (float)point.X) + (int)((1 - alpha) * (float)PointI.X);
            PointIplusOne.Y = (int)(alpha * (float)point.Y) + (int)((1 - alpha) * (float)PointI.Y);
            Console.WriteLine(PointIplusOne.X);
            Console.WriteLine(PointIplusOne.Y);
        }

        public Point getMean()
        {
            
            return new Point(PointIplusOne.X, PointIplusOne.Y);
        }
    }
}

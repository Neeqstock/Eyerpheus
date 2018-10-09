using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    class NoFilter : IFilter
    {
        private Point point;

        public NoFilter()
        {
            this.point = new Point(0,0);
        }

        public void push(Point point)
        {
            this.point = point;
        }

        public Point getMean()
        {
            return point;
        }
    }
}

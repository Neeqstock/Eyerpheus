using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiraMiVoz.Filters
{
    /// <summary>
    /// A generic point filter.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Insert a new point in the filter's array.
        /// </summary>
        void push(Point point);

        /// <summary>
        /// Calculates the mean point with the filter's specific algorithm.
        /// </summary>
        /// <returns>the calculated point</returns>
        Point getMean();
    }
}

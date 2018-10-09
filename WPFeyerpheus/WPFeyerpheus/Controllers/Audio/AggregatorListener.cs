using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus
{
    interface AggregatorListener
    {
        void aggregatorReached(float min, float max, float avg);
    }
}

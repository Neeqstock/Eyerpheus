using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus.Controllers.Eyetracker
{
    public interface IGazePointListener
    {
        void receiveGazePoint(double x, double y);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;

namespace Eyerpheus.Controllers.Eyetracker
{
    public interface IEyePositionListener
    {
        void receiveEyePosition(EyePosition leftEye, EyePosition rightEye);
    }
}

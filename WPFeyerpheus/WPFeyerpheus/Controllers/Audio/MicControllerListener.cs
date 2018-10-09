using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus.Controllers.Audio
{
    interface MicControllerListener
    {
        void processStartBlowing();
        void processStopBlowing();
    }
}

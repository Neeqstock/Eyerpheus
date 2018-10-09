using Eyerpheus.Controllers.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus
{
    public interface Instrument
    {
        void processStartPlaying();
        void processStopPlaying();
        void setNote(int note);
        void processStartHold();
        void processStopHold();
        int getNote();
        void stopCurrentNote();
    }
}

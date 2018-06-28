using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus.Controllers.Midi
{
    interface IMidiController
    {
        void playNote(int note, int velocity);
        void stopNote(int note);
    }
}

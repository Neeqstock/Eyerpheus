using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI_statistics.Midi
{
    class MidiNote
    {
        private int time;
        private int key;

        public int Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
        public int Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
    }
}

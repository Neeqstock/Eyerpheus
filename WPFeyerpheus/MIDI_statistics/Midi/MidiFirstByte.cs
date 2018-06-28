using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI_statistics.Midi
{
    enum MidiFirstByte : byte
    {
        NoteOff = 0x80,
        NoteOn = 0x90,
        Unknown
    }
}

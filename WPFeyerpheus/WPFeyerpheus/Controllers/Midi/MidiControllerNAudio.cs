using Eyerpheus.Controllers.Midi;
using NAudio.Midi;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFeyerpheus.Chests;

namespace Eyerpheus
{
    class MidiControllerNAudio : IMidiController
    {
        private int outDeviceID = 1;

        private MidiOut midiOut;

        public MidiControllerNAudio()
        {
            midiOut = new MidiOut(outDeviceID);
        }

        public void playNote(int note, int velocity)
        {
            midiOut.Send(MidiMessage.StartNote(note, velocity, AudioChest.getChest().MidiOutputChannel).RawData);
        }

        public void stopNote(int note)
        {
            midiOut.Send(MidiMessage.StopNote(note, 0, AudioChest.getChest().MidiOutputChannel).RawData);
        }

    }
}

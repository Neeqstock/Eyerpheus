using Eyerpheus.Chests;
using Eyerpheus.Controllers.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFeyerpheus.Chests;
using WPFeyerpheus.Configs;

namespace Eyerpheus.Controllers.Instruments
{
    class BlownInstrument : Instrument, MicControllerListener
    {
        private int note;
        private int velocity = 127;
        private bool isBlowing = false;
        private bool hold = false;

        public BlownInstrument()
        {
            AudioChest.getChest().MicController.Listener = this;
        }

        private int storeNote;

        public int Note { get { return note; } set { note = value; } }
        public int Velocity { get { return velocity; } set { velocity = value; } }

        public void processStartPlaying()
        {
            isBlowing = true;
            if (!hold)
            {
                AudioChest.getChest().MidiController.playNote(note, velocity);
            }
            else
            {
                AudioChest.getChest().MidiController.playNote(storeNote, velocity);
            }

            InstrumentChest.getChest().IsBlowing = true;

        }

        public void processStopPlaying()
        {
            isBlowing = false;
            if (!hold)
            {
                AudioChest.getChest().MidiController.stopNote(note);
            }
            else
            {
                AudioChest.getChest().MidiController.stopNote(storeNote);
            }

            InstrumentChest.getChest().IsBlowing = false;

        }

        public void setNote(int note)
        {
            if (!hold)
            {
                AudioChest.getChest().MidiController.stopNote(this.note);

                if (isBlowing)
                {
                    AudioChest.getChest().MidiController.playNote(note, velocity);
                }
            }

            this.note = note;
            InstrumentChest.getChest().Note = note;
        }

        public int getNote()
        {
            return note;
        }

        public void processStartHold()
        {
            storeNote = note;
            hold = true;
        }

        public void processStopHold()
        {
            hold = false;
        }

        public void processStartBlowing()
        {
            processStartPlaying();
        }

        public void processStopBlowing()
        {
            processStopPlaying();
        }

        public void stopCurrentNote()
        {
            AudioChest.getChest().MidiController.stopNote(note);
        }
    }
}

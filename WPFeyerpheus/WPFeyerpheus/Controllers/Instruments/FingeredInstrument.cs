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
    class FingeredInstrument : Instrument, MicControllerListener
    {
        private int note;
        private int velocity = 127;
        private bool isBlowing = false;
        private bool hold = false;

        private List<int> chord = new List<int>();

        public FingeredInstrument()
        {
           
        }

        public int Note { get { return note; } set { note = value; } }
        public int Velocity { get { return velocity; } set { velocity = value; } }

        public void processStartPlaying()
        {
            isBlowing = true;
            InstrumentChest.getChest().IsBlowing = true;

            if (hold)
            {
                foreach(int note in chord)
                {
                    AudioChest.getChest().MidiController.playNote(note, velocity);
                    ExternalControllersChest.getChest().GamepadController.flashFFB();
                }
            }

            else
            {
                AudioChest.getChest().MidiController.playNote(note, velocity);
                ExternalControllersChest.getChest().GamepadController.flashFFB();
            }
        }

        public void processStopPlaying()
        {
            isBlowing = false;
            InstrumentChest.getChest().IsBlowing = false;

            if (hold)
            {
                foreach (int note in chord)
                {
                    AudioChest.getChest().MidiController.stopNote(note);
                }
            }

            else
            {
                AudioChest.getChest().MidiController.stopNote(note);
            }
        }

        public void stopCurrentNote()
        {
            AudioChest.getChest().MidiController.stopNote(note);
        }

        public void setNote(int note)
        {
            if (!InstrumentChest.getChest().Locked)
            {
                if (hold)
                {
                    chord.Add(note);
                    if (isBlowing)
                    {
                        AudioChest.getChest().MidiController.playNote(note, velocity);
                        ExternalControllersChest.getChest().GamepadController.flashFFB();
                    }

                }
                else
                {
                    AudioChest.getChest().MidiController.stopNote(this.note);
                    if (isBlowing)
                    {
                        AudioChest.getChest().MidiController.playNote(note, velocity);
                        ExternalControllersChest.getChest().GamepadController.flashFFB();
                    }
                }

                this.note = note;
                InstrumentChest.getChest().Note = note;
            }
        }

        public int getNote()
        {
            return note;
        }

        public void processStartHold()
        {
            hold = true;
            chord.Add(note);
        }

        public void processStopHold()
        {
            hold = false;

            if (isBlowing)
            {
                for(int i = 0; i < chord.Count - 1; i++)
                {
                    AudioChest.getChest().MidiController.stopNote(chord[i]);
                }
                clearDots();
            }
            else
            {

            }

            chord.Clear();
        }

        private void clearDots()
        {
            // TODO
        }

        public void processStartBlowing()
        {
            processStartPlaying();
        }

        public void processStopBlowing()
        {
            processStopPlaying();
        }
    }
}

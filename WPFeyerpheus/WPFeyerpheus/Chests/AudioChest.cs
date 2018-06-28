using Eyerpheus;
using Eyerpheus.Controllers.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFeyerpheus.Chests
{
    class AudioChest
    {
        #region Singleton
        private static AudioChest chest;
        public static void spawnChest()
        {
            chest = new AudioChest();
        }
        public static AudioChest getChest()
        {
            return chest;
        }
        #endregion

        public AudioChest()
        {
            micController = new MicController();
            midiController = new MidiControllerNAudio();
        }

        private MicController micController;
        public MicController MicController
        {
            get
            {
                return micController;
            }

            set
            {
                micController = value;
            }
        }

        private IMidiController midiController;
        public IMidiController MidiController { get { return midiController; } set { midiController = value; } }

        public int MidiOutputChannel { get => midiOutputChannel; set => midiOutputChannel = value; }

        private int midiOutputChannel = 1;
        public int midiChannelMin = 1;
        public int midiChannelMax = 10;
    }
}

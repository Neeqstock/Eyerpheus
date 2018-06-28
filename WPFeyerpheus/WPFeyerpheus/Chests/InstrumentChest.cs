using Eyerpheus.Controllers.Eyetracker;
using Eyerpheus.Controllers.Midi;
using Eyerpheus.Controllers.PlayModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFeyerpheus.Configs;
using WPFeyerpheus.Controllers.Graphic;
using WPFeyerpheus.Controllers.PlayModes;

namespace Eyerpheus.Chests
{
    class InstrumentChest
    {
        #region Singleton
        private static InstrumentChest chest = new InstrumentChest();
        public static InstrumentChest getChest()
        {
            return chest;
        }
        #endregion

        private IPlayMode netytarPlayMode;
        public IPlayMode NetytarPlayMode
        {
            get
            {
                return netytarPlayMode;
            }

            set
            {
                netytarPlayMode = value;
            }
        }

        private IWickiEyedenPlayMode wickiEyedenPlayMode;
        public IWickiEyedenPlayMode WickiEyedenPlayMode
        {
            get
            {
                return wickiEyedenPlayMode;
            }

            set
            {
                wickiEyedenPlayMode = value;
            }
        }

        private Instrument instrument;
        public Instrument Instrument { get { return instrument; } set { instrument = value; } }

        private List<INoteAndPlayListener> noteAndPlayListeners = new List<INoteAndPlayListener>();
        public List<INoteAndPlayListener> NoteAndPlayListeners
        {
            get
            {
                return noteAndPlayListeners;
            }

            set
            {
                noteAndPlayListeners = value;
            }
        }

        private int note = 0;
        public int Note
        {
            get
            {
                return note + transpose;
            }

            set
            {
                note = value;
                foreach(INoteAndPlayListener listener in noteAndPlayListeners)
                {
                    if (listener != null) listener.receiveNote(note);
                }
                
            }
        }

        private int transpose = 0;
        public int Transpose
        {
            get
            {
                return transpose;
            }

            set
            {
                transpose = value;
            }
        }

        private bool locked = false;
        public bool Locked
        {
            get
            {
                return locked;
            }

            set
            {
                locked = value;
            }
        }

        private bool isBlowing = false;
        public bool IsBlowing
        {
            get
            {
                return isBlowing;
            }

            set
            {
                isBlowing = value;
                foreach(INoteAndPlayListener listener in noteAndPlayListeners)
                {
                    if (listener != null) listener.receiveIsBlowing(isBlowing);
                }
                
            }
        }
    }
}

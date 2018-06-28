using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFeyerpheus.Controllers.Music
{
    public static class TempoUtils
    {
        public static int bpmToMilliseconds(int bpm)
        {
            return 1000 * 60 / bpm; // Basic formula found on StackOverflow -> https://stackoverflow.com/questions/9675031/time-interval-in-ms-from-bpm-midi-tempo
        }

        public static int millisecondsToBpm(int milliseconds)
        {
            return 1000 * 60 / milliseconds; // Reverse of the previous formula
        }
    }
}

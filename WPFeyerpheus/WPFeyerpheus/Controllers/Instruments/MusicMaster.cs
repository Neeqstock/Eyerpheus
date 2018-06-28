using Eyerpheus.Controllers.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFeyerpheus.Controllers.Instruments
{
    class MusicMaster
    {
        public const int basePitch = 60;

        public static Notes getNote(int value)
        {
            foreach (Notes note in Enum.GetValues(typeof(Notes)))
            {
                if ((int)note == value)
                {
                    return note;
                }
            }
            return Notes.C5;
        }

        public static string[] getScale(int noteNum, string scaleCode)
        {
            string fetcher = "";
            foreach (Notes note in Enum.GetValues(typeof(Notes)))
            {
                if ((int)note == noteNum)
                {
                    fetcher = note.ToString().Remove(note.ToString().Length - 1);
                }
            }

            fetcher += scaleCode;
            foreach (Scales scale in Enum.GetValues(typeof(Scales)))
            {
                if (scale.Equals(fetcher))
                {
                    return getScale(scale);
                }
            }
            return getScale(Scales.None);
        }

        public static bool isInScale(int value, Scales scale)
        {
            foreach (Notes note in Enum.GetValues(typeof(Notes)))
            {
                if ((int)note == value)
                {
                    foreach (String inScale in getScale(scale))
                    {
                        if (note.ToString().StartsWith(inScale))
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        public static String[] getScale(Scales scale)
        {
            switch (scale)
            {
                case Scales.Cmaj:
                    return new string[] { "C", "D", "E", "F", "G", "A", "B" };
                case Scales.Cmin:
                    return new string[] { "C", "D", "sD", "F", "G", "sG", "sA" };

                case Scales.sCmaj:
                    return new string[] { "sC", "sD", "F", "sF", "sG", "sA", "C" };
                case Scales.sCmin:
                    return new string[] { "sC", "sD", "E", "sF", "sG", "A", "B" };

                case Scales.Dmaj:
                    return new string[] { "D", "E", "sF", "G", "A", "B", "sC" };
                case Scales.Dmin:
                    return new string[] { "D", "E", "F", "G", "A", "sA", "C" };

                case Scales.sDmaj:
                    return new string[] { "sD", "F", "G", "sG", "sA", "C", "D" };
                case Scales.sDmin:
                    return new string[] { "sD", "F", "sF", "sG", "sA", "B", "sC" };

                case Scales.Emaj:
                    return new string[] { "E", "sF", "sG", "A", "B", "sC", "sD" };
                case Scales.Emin:
                    return new string[] { "E", "sF", "G", "A", "B", "C", "D" };

                case Scales.Fmaj:
                    return new string[] { "F", "G", "A", "sA", "C", "D", "E" };
                case Scales.Fmin:
                    return new string[] { "F", "G", "sG", "sA", "C", "sC", "sD" };

                case Scales.sFmaj:
                    return new string[] { "sF", "sG", "sA", "B", "sC", "sD", "F" };
                case Scales.sFmin:
                    return new string[] { "sF", "sG", "A", "B", "C", "D", "E" };

                case Scales.Gmaj:
                    return new string[] { "G", "A", "B", "C", "D", "E", "sF" };
                case Scales.Gmin:
                    return new string[] { "G", "A", "sA", "C", "D", "sD", "F" };

                case Scales.sGmaj:
                    return new string[] { "sG", "sA", "C", "sC", "sD", "F", "G" };
                case Scales.sGmin:
                    return new string[] { "sG", "sA", "B", "sC", "sD", "E", "sF" };

                case Scales.Amaj:
                    return new string[] { "A", "B", "sC", "D", "E", "sF", "sG" };
                case Scales.Amin:
                    return new string[] { "A", "B", "C", "D", "E", "F", "G" };

                case Scales.sAmaj:
                    return new string[] { "sA", "C", "D", "sD", "F", "G", "A" };
                case Scales.sAmin:
                    return new string[] { "sA", "C", "sC", "sD", "F", "sF", "sG" };

                case Scales.Bmaj:
                    return new string[] { "B", "sC", "sD", "E", "sF", "sG", "sA" };
                case Scales.Bmin:
                    return new string[] { "B", "sC", "D", "E", "sF", "G", "A" };

                case Scales.Chromatic:
                    return new string[] { "C", "sC", "D", "sD", "E", "F", "sF", "G", "sG", "A", "sA", "B" };
                case Scales.None:
                    return new string[] { "N" };
                default:
                    return null;
            }
        }

        internal static Scales getScaleEnum(int noteNum, string scaleCode)
        {
            string fetcher = "";
            foreach (Notes note in Enum.GetValues(typeof(Notes)))
            {
                if ((int)note == noteNum)
                {
                    fetcher = note.ToString().Remove(note.ToString().Length - 1);
                }
            }

            fetcher += scaleCode;
            foreach (Scales scale in Enum.GetValues(typeof(Scales)))
            {
                if (scale.ToString().Equals(fetcher))
                {
                    return scale;
                }
            }
            return Scales.None;
        }
    }
}

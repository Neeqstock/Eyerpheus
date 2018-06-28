using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFeyerpheus.Controllers.Instruments;

namespace Eyerpheus.Controllers.Instruments
{
    public enum Notes : int
    {
        C2 = MusicMaster.basePitch - 36,
        sC2 = MusicMaster.basePitch - 35,
        D2 = MusicMaster.basePitch - 34,
        sD2 = MusicMaster.basePitch - 33,
        E2 = MusicMaster.basePitch - 32,
        F2 = MusicMaster.basePitch - 31,
        sF2 = MusicMaster.basePitch - 30,
        G2 = MusicMaster.basePitch - 29,
        sG2 = MusicMaster.basePitch - 28,
        A2 = MusicMaster.basePitch - 27,
        sA2 = MusicMaster.basePitch - 26,
        B2 = MusicMaster.basePitch - 25,
        C3 = MusicMaster.basePitch - 24,
        sC3 = MusicMaster.basePitch - 23,
        D3 = MusicMaster.basePitch - 22,
        sD3 = MusicMaster.basePitch - 21,
        E3 = MusicMaster.basePitch - 20,
        F3 = MusicMaster.basePitch - 19,
        sF3 = MusicMaster.basePitch - 18,
        G3 = MusicMaster.basePitch - 17,
        sG3 = MusicMaster.basePitch - 16,
        A3 = MusicMaster.basePitch - 15,
        sA3 = MusicMaster.basePitch - 14,
        B3 = MusicMaster.basePitch - 13,
        C4 = MusicMaster.basePitch - 12,
        sC4 = MusicMaster.basePitch - 11,
        D4 = MusicMaster.basePitch - 10,
        sD4 = MusicMaster.basePitch - 9,
        E4 = MusicMaster.basePitch - 8,
        F4 = MusicMaster.basePitch - 7,
        sF4 = MusicMaster.basePitch - 6,
        G4 = MusicMaster.basePitch - 5,
        sG4 = MusicMaster.basePitch - 4,
        A4 = MusicMaster.basePitch - 3,
        sA4 = MusicMaster.basePitch - 2,
        B4 = MusicMaster.basePitch - 1,
        C5 =        MusicMaster.basePitch,
        sC5 =       MusicMaster.basePitch + 1,
        D5 =        MusicMaster.basePitch + 2,
        sD5 =       MusicMaster.basePitch + 3,
        E5 =        MusicMaster.basePitch + 4,
        F5 =        MusicMaster.basePitch + 5,
        sF5 =       MusicMaster.basePitch + 6,
        G5 =        MusicMaster.basePitch + 7,
        sG5 =       MusicMaster.basePitch + 8,
        A5 =        MusicMaster.basePitch + 9,
        sA5 =       MusicMaster.basePitch + 10,
        B5 =        MusicMaster.basePitch + 11,
        C6 = MusicMaster.basePitch + 12,
        sC6 = MusicMaster.basePitch + 13,
        D6 = MusicMaster.basePitch + 14,
        sD6 = MusicMaster.basePitch + 15,
        E6 = MusicMaster.basePitch + 16,
        F6 = MusicMaster.basePitch + 17,
        sF6 = MusicMaster.basePitch + 18,
        G6 = MusicMaster.basePitch + 19,
        sG6 = MusicMaster.basePitch + 20,
        A6 = MusicMaster.basePitch + 21,
        sA6 = MusicMaster.basePitch + 22,
        B6 = MusicMaster.basePitch + 23,
        C7 = MusicMaster.basePitch + 24,
        sC7 = MusicMaster.basePitch + 25,
        D7 = MusicMaster.basePitch + 26,
        sD7 = MusicMaster.basePitch + 27,
        E7 = MusicMaster.basePitch + 28,
        F7 = MusicMaster.basePitch + 29,
        sF7 = MusicMaster.basePitch + 30,
        G7 = MusicMaster.basePitch + 31,
        sG7 = MusicMaster.basePitch + 32,
        A7 = MusicMaster.basePitch + 33,
        sA7 = MusicMaster.basePitch + 34,
        B7 = MusicMaster.basePitch + 35,
        C8 = MusicMaster.basePitch + 36
    }

    public enum Scales
    {
        Cmaj,
        Cmin,

        sCmaj,
        sCmin,

        Dmaj,
        Dmin,

        sDmaj,
        sDmin,

        Emaj,
        Emin,

        Fmaj,
        Fmin,

        sFmaj,
        sFmin,

        Gmaj,
        Gmin,

        sGmaj,
        sGmin,

        Amaj,
        Amin,

        sAmaj,
        sAmin,

        Bmaj,
        Bmin,

        Chromatic,
        None
    }

    public enum Scale_Cmaj  // Useless, for now...
    {
        C, D, E, F, G, A, B
    }
}

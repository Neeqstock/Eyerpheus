using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFeyerpheus.Configs
{
    interface INoteAndPlayListener
    {
        void receiveNote(int note);
        void receiveIsBlowing(bool isBlowing);
    }
}

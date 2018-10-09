using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyerpheus.Controllers.Eyetracker
{
    public interface IBlinkerListener
    {
        void receive_leftOpen();
        void receive_leftClose();
        void receive_doubleOpen();
        void receive_doubleClose();
        void receive_rightClose();
        void receive_rightOpen();
    }
}

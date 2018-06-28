using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput.Wrapper;
using XInputDotNetPure;

namespace WPFeyerpheus.Controllers.External
{
    class GamepadController
    {
        private const float flashFFBLeftLow = 1.0f;
        private const float flashFFBRightHi = 1.0f;
        private const int flashFFBDuration = 30;

        private Timer FFBtimer;

        public GamepadController()
        {
            FFBtimer = new Timer();
            FFBtimer.Interval = flashFFBDuration;
            FFBtimer.Tick += FFBtimerTick;
        }

        private void FFBtimerTick(object sender, EventArgs e)
        {
            FFBtimer.Stop();
            GamePad.SetVibration(PlayerIndex.One, 0, 0);
        }

        public void flashFFB()
        {
            FFBtimer.Start();
            GamePad.SetVibration(PlayerIndex.One, flashFFBLeftLow, flashFFBRightHi);
        }
    }
}

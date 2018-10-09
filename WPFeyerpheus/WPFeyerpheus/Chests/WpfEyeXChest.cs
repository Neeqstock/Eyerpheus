using Eyerpheus.Controllers.Eyetracker;
using EyeXFramework;
using EyeXFramework.Forms;
using EyeXFramework.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.EyeX.Framework;

namespace Eyerpheus.Chests
{
   public class WpfEyeXChest
    {
        #region Listeners
        private IEyePositionListener eyePositionListener;
        private IGazePointListener gazePointListener;

        public IEyePositionListener EyePositionListener { get { return eyePositionListener; } set { eyePositionListener = value; } }
        public IGazePointListener GazePointListener { get { return gazePointListener; } set { gazePointListener = value; } }
        #endregion

        #region Singleton
        private static WpfEyeXChest chest = new WpfEyeXChest();
        public static WpfEyeXChest getChest()
        {
            return chest;
        }
        #endregion

        private bool mouseEmulation = true;

        private WpfEyeXChest()
        {
            _eyeXHost = new WpfEyeXHost();

            eyePositionListener = blinkProcessor;

            var eyePositionStream = _eyeXHost.CreateEyePositionDataStream();
            eyePositionStream.Next += eyePositionNext;

            var gazePointStream = _eyeXHost.CreateGazePointDataStream(GazePointDataMode.Unfiltered);
            gazePointStream.Next += gazePointNext;
        }

        private WpfEyeXHost _eyeXHost;
        public WpfEyeXHost getEyeXHost()
        {
            return _eyeXHost;
        }

        private BlinkProcessor blinkProcessor = new BlinkProcessor();
        public BlinkProcessor getBlinkProcessor()
        {
            return blinkProcessor;
        }

        private int gazeDelay = 3;
        public int GazeDelay
        {
            get
            {
                return gazeDelay;
            }

            set
            {
                gazeDelay = value;
            }
        }

        public bool MouseEmulation { get { return mouseEmulation; } set { mouseEmulation = value; } }

        #region Internal functions
        private void gazePointNext(object sender, GazePointEventArgs e)
        {
            if (gazePointListener != null)
            {
                
                gazePointListener.receiveGazePoint(e.X, e.Y);
            }
        }

        private void eyePositionNext(object sender, EyePositionEventArgs e)
        {
            blinkProcessor.receiveEyePosition(e.LeftEye, e.RightEye);
        }
        #endregion
    }
}

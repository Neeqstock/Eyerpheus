using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeXFramework;
using System.Windows.Forms;

namespace Eyerpheus.Controllers.Eyetracker
{
    public class BlinkProcessor : IEyePositionListener
    {
        private int leftThreshold = 4;
        private int rightThreshold = 4;
        private int doubleThreshold = 5;

        private int leftCloseCounter = 0;
        private int rightCloseCounter = 0;
        private int doubleCloseCounter = 0;
        private int leftOpenCounter = 0;
        private int rightOpenCounter = 0;
        private int doubleOpenCounter = 0;

        private List<IBlinkerListener> listeners = new List<IBlinkerListener>();

        public int LeftThreshold
        {
            get
            {
                return leftThreshold;
            }

            set
            {
                leftThreshold = value;
            }
        }

        public int RightThreshold
        {
            get
            {
                return rightThreshold;
            }

            set
            {
                rightThreshold = value;
            }
        }

        public int DoubleThreshold
        {
            get
            {
                return doubleThreshold;
            }

            set
            {
                doubleThreshold = value;
            }
        }

        public List<IBlinkerListener> Listeners
        {
            get
            {
                return listeners;
            }

            set
            {
                listeners = value;
            }
        }

        public void receiveEyePosition(EyePosition leftEye, EyePosition rightEye)
        {
            if (!leftEye.IsValid && rightEye.IsValid) // LEFT BLINK
            {
                leftOpenCounter = 0;
                leftCloseCounter++;
                rightOpenCounter++;
                rightCloseCounter = 0;
                doubleOpenCounter = 0;
                doubleCloseCounter = 0;
            }
            else if(leftEye.IsValid && !rightEye.IsValid) // RIGHT BLINK
            {
                leftOpenCounter++;
                leftCloseCounter = 0;
                rightOpenCounter = 0;
                rightCloseCounter++;
                doubleOpenCounter = 0;
                doubleCloseCounter = 0;
            }
            else if(!leftEye.IsValid && !rightEye.IsValid) // DOUBLE BLINK
            {
                leftOpenCounter = 0;
                leftCloseCounter = 0;
                rightOpenCounter = 0;
                rightCloseCounter = 0;
                doubleOpenCounter = 0;
                doubleCloseCounter++;
            }
            else if (leftEye.IsValid && rightEye.IsValid)
            {
                leftOpenCounter++;
                leftCloseCounter = 0;
                rightOpenCounter++;
                rightCloseCounter = 0;
                doubleOpenCounter++;
                doubleCloseCounter = 0;
            }

            foreach(IBlinkerListener listener in Listeners)
            {
                if (listener != null)
                {
                    if (leftOpenCounter == leftThreshold)
                    {
                        listener.receive_leftOpen();
                    }
                    if (leftCloseCounter == leftThreshold)
                    {
                        listener.receive_leftClose();
                    }
                    if (rightOpenCounter == rightThreshold)
                    {
                        listener.receive_rightOpen();
                    }
                    if (rightCloseCounter == rightThreshold)
                    {
                        listener.receive_rightClose();
                    }
                    if (doubleOpenCounter == doubleThreshold)
                    {
                        listener.receive_doubleOpen();
                    }
                    if (doubleCloseCounter == doubleThreshold)
                    {
                        listener.receive_doubleClose();
                    }
                }
            }

            
        }
    }
}

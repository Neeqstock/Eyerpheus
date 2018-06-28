using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Eyerpheus.Controllers.Eyetracker;
using WPFeyerpheus.Controllers.Graphic;
using System.Windows;
using System.Windows.Controls;

namespace Eyerpheus
{
    class GraphicsChest
    {
        #region Singleton
        private static GraphicsChest chest = new GraphicsChest();
        public static GraphicsChest getChest()
        {
            return chest;
        }
        #endregion

        #region Netytar
        private NetytarDrawer netytarDrawer;
        public  NetytarDrawer NetytarDrawer { get { return netytarDrawer; } set { netytarDrawer = value; } }
        
        private Point netytarWatched = new Point(0, 0);
        public Point NetytarWatched
        {
            get
            {
                return netytarWatched;
            }

            set
            {
                netytarWatched = value;
            }
        }

        private Point netytarCenter;
        public Point NetytarCenter
        {
            get
            {
                return netytarCenter;
            }

            set
            {
                netytarCenter = value;
            }
        }

        public Brush InScaleBrush { get { return Brushes.Red; } }
        public Brush NotInScaleBrush { get { return Brushes.Black; } }

        public int netytarWidth = 10; // OLD 8
        public int netytarHeight = 10; // OLD 8
        public int netytarSpacing = 185; // OLD 160
        public int netytarGenNote = 50;
        public int netytarStart = 500;
        #endregion

        #region WickiEyeden
        private WickiEyedenDrawer wickiEyedenDrawer;
        public WickiEyedenDrawer WickiEyedenDrawer
        {
            get
            {
                return wickiEyedenDrawer;
            }

            set
            {
                wickiEyedenDrawer = value;
            }
        }

        private Point wickiEyedenWatched = new Point(0, 0);
        public Point WickiEyedenWatched
        {
            get
            {
                return wickiEyedenWatched;
            }

            set
            {
                wickiEyedenWatched = value;
            }
        }

        private Point wickiEyedenCenter;
        public Point WickiEyedenCenter
        {
            get
            {
                return wickiEyedenCenter;
            }

            set
            {
                wickiEyedenCenter = value;
            }
        }

        private int wickiEyedenTopNote = 120;
        public int WickiEyedenTopNote
        {
            get
            {
                return wickiEyedenTopNote;
            }

            set
            {
                wickiEyedenTopNote = value;
            }
        }
        #endregion

        #region Graphic effects
        private RhythmFlasher rhythmFlasher;
        public RhythmFlasher RhythmFlasher
        {
            get
            {
                return rhythmFlasher;
            }

            set
            {
                rhythmFlasher = value;
            }
        }
        #endregion

        #region Public settings
        public Eyes BlinkerEye { get { return Eyes.Left; }}
        #endregion

    }
}

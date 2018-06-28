using Eyerpheus.Chests;
using EyeXFramework.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFeyerpheus.Controllers.Graphic;

namespace Eyerpheus.Controllers.Graphic
{
    public class NetytarButton : RadioButton
    {
        private int note;
        public int Note { get { return note; } set { note = value; } }

        private Rectangle occluder;
        public Rectangle Occluder
        {
            get
            {
                return occluder;
            }

            set
            {
                occluder = value;
            }
        }

        public NetytarButton() : base()
        {
            occluder = new Rectangle();
            occluder.Stroke = Brushes.Transparent;
            occluder.Fill = Brushes.Transparent;
            occluder.Stroke = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0));
            occluder.Fill = new SolidColorBrush(Color.FromArgb(60, 0, 0, 0));
            occluder.StrokeThickness = 1;
            occluder.HorizontalAlignment = HorizontalAlignment.Left;
            occluder.VerticalAlignment = VerticalAlignment.Center;
        }

        public void setBehavior()
        {
            Behavior.SetGazeAware(Occluder, true);
            Behavior.SetGazeAwareDelay(Occluder, WpfEyeXChest.getChest().GazeDelay);
            Behavior.AddHasGazeChangedHandler(Occluder, OnGaze);
        }

        public Line L_p1
        {
            get
            {
                return l_p1;
            }

            set
            {
                l_p1 = value;
            }
        }
        public Line L_p2
        {
            get
            {
                return l_p2;
            }

            set
            {
                l_p2 = value;
            }
        }
        public Line L_p3
        {
            get
            {
                return l_p3;
            }

            set
            {
                l_p3 = value;
            }
        }

        public Line L_m1
        {
            get
            {
                return l_m1;
            }

            set
            {
                l_m1 = value;
            }
        }
        public Line L_m2
        {
            get
            {
                return l_m2;
            }

            set
            {
                l_m2 = value;
            }
        }
        public Line L_m3
        {
            get
            {
                return l_m3;
            }

            set
            {
                l_m3 = value;
            }
        }

        private Line l_p1;
        private Line l_p2;
        private Line l_p3;

        private Line l_m1;
        private Line l_m2;
        private Line l_m3;

        public Line getLine(int pitchDirection)
        {
            switch (pitchDirection)
            {
                case -1:
                    return l_m1;
                case -2:
                    return l_m2;
                case -3:
                    return l_m3;
                case 1:
                    return l_p1;
                case 2:
                    return l_p2;
                case 3:
                    return l_p3;
                default:
                    return null;
            }
        }

        public void OnGaze(object sender, RoutedEventArgs e)
        {
            if(Occluder.GetHasGaze() == true)
            {
                IsChecked = true;
                NetytarDrawer.getDrawer().netytarButton_OnGaze(this);
            }
                
        }
    }
}

using Eyerpheus;
using Eyerpheus.Chests;
using Eyerpheus.Controllers.Graphic;
using EyeXFramework.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFeyerpheus.Controllers.PlayModes.WickiEyeden
{
    class WickiEyedenPlayWithGaze : IWickiEyedenPlayMode
    {
        WickiEyedenButton tempButton;
        Brush tempBrush;
        SolidColorBrush selectedBrush = new SolidColorBrush(Colors.Aqua);

        public WickiEyedenPlayWithGaze()
        {
            activate();
        }

        public void activate()
        {
            WickiEyedenButton[,] buttons = GraphicsChest.getChest().WickiEyedenDrawer.Buttons;

            foreach (WickiEyedenButton button in buttons)
            {
                if(button != null)
                {
                    #region Behavior
                    Behavior.SetGazeAware(button, true);
                    Behavior.SetGazeAwareDelay(button, WpfEyeXChest.getChest().GazeDelay);
                    Behavior.AddHasGazeChangedHandler(button, button_OnGaze);
                    #endregion
                }
            }
        }

        private void button_OnGaze(object sender, RoutedEventArgs e)
        {
            if(tempButton != null)
            {
                tempButton.Background = tempBrush;
            }

            if (((WickiEyedenButton)sender).GetHasGaze())
            {
                tempButton = ((WickiEyedenButton)sender);
                tempBrush = tempButton.Background;
                tempButton.Background = selectedBrush;
                InstrumentChest.getChest().Instrument.setNote(tempButton.Pitch);
                GraphicsChest.getChest().WickiEyedenWatched = new Point(Canvas.GetLeft(tempButton), Canvas.GetTop(tempButton));
                
            }
        }
    }
}

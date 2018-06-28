using Eyerpheus.Controllers.Instruments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFeyerpheus.Controllers.Instruments;

namespace Eyerpheus.Controllers.Graphic
{
    public class WickiEyedenButton : Button
    {
        private int pitch;
        public int Pitch { get { return pitch; } set { pitch = value; } }

        private static Color borderColor = Colors.Black;
        private static Color whiteKeysColor = Colors.White;
        private static Color blackKeysColor = Colors.DarkSlateGray;
        private static Color whiteKeysText = Colors.DarkSlateGray;
        private static Color blackKeysText = Colors.White;

        private Notes note;
        public Notes Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public WickiEyedenButton(int pitch)
        {
            this.pitch = pitch;

            BorderBrush = new SolidColorBrush(borderColor);
            BorderThickness = new Thickness(2);
            FontWeight = FontWeights.Bold;
            FontSize = 18;

            Note = MusicMaster.getNote(pitch);

            if (Note.ToString().StartsWith("s"))
            {
                Content = Note.ToString().Remove(0, 1) + "#";
                Background = new SolidColorBrush(blackKeysColor);
                Foreground = new SolidColorBrush(blackKeysText);
            } else
            {
                Content = Note.ToString();
                Background = new SolidColorBrush(whiteKeysColor);
                Foreground = new SolidColorBrush(whiteKeysText);
            }
        }
    }
}

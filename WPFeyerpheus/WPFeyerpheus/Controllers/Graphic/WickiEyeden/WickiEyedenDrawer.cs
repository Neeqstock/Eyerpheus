using Eyerpheus;
using Eyerpheus.Controllers.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFeyerpheus.Controllers.Graphic
{
    public class WickiEyedenDrawer
    {
        private Point wickiEyedenStart = new Point(50, 50);

        public int wickiEyedenHeight = 9;
        public int side = 100;

        private const int oddButtons = 9;   
        private const int evenButtons = 10;

        private const int pitchMax = 94;

        // Wicki-Hayden columns: 9, 10
        private WickiEyedenButton[,] buttons;
        public WickiEyedenButton[,] Buttons
        {
            get
            {
                return buttons;
            }

            set
            {
                buttons = value;
            }
        }

        private ScrollViewer scrollViewer;
        private Canvas canvas;

        public WickiEyedenDrawer(ScrollViewer scrollViewer)
        {
            this.scrollViewer = scrollViewer;

            canvas = new Canvas();
            canvas.VerticalAlignment = VerticalAlignment.Stretch;
            canvas.HorizontalAlignment = HorizontalAlignment.Stretch;
            canvas.Margin = new Thickness(0, 0, 0, 0);
            canvas.Width = wickiEyedenStart.X * 2 + side * 10;
            canvas.Height = wickiEyedenStart.Y * 2 + side * wickiEyedenHeight;
            scrollViewer.Content = canvas;

            GraphicsChest.getChest().WickiEyedenCenter = new Point(canvas.Width / 2, canvas.Height / 2);
        }

        public void generateWickiEyeden()
        {
            Buttons = new WickiEyedenButton[wickiEyedenHeight, 10];
            canvas.Children.Clear();

            int baseNote = GraphicsChest.getChest().netytarGenNote;

            int side = this.side;
            int halfSide = this.side / 2;

            bool isPairRow;

            int startRowPitch = pitchMax - 11;

            for (int row = 0; row < wickiEyedenHeight; row++)
            {
                #region Is row pair?
                if ((row + 1) % 2 != 0)
                {
                    isPairRow = false;
                }
                else
                {
                    isPairRow = true;
                }
                #endregion

                int buttonsNumber;
                int spacer;

                if (!isPairRow)
                {
                    buttonsNumber = oddButtons;
                    spacer = halfSide;
                    startRowPitch -= 5;    // Deducted from maths!
                }else
                {
                    buttonsNumber = evenButtons;
                    spacer = 0;
                    startRowPitch -= 7;    // Deducted from maths!
                }
                    
                for (int col = 0; col < buttonsNumber; col++)
                {
                    Point generator = new Point(wickiEyedenStart.X + spacer + (col * side), wickiEyedenStart.Y + (side * row));
                    // Button spawning
                    Buttons[row, col] = new WickiEyedenButton(startRowPitch + (col * 2));
                    Buttons[row, col].Height = side;
                    Buttons[row, col].Width = side;
                    Canvas.SetLeft(Buttons[row, col], generator.X);
                    Canvas.SetTop(Buttons[row, col], generator.Y);
                    Panel.SetZIndex(Buttons[row, col], 0);
                    canvas.Children.Add(Buttons[row, col]);
                }
            }
            // Center assignment
            GraphicsChest.getChest().WickiEyedenCenter = new Point(canvas.Width / 2, canvas.Height / 2);
        }
    }
}

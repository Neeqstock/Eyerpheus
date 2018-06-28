using Eyerpheus.Controllers.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFeyerpheus.Controllers.Graphic
{
    public class ChordHolderDots
    {
        private Canvas canvas;
        private List<Ellipse> ellipses;
        private SolidColorBrush solidBrush;

        public ChordHolderDots(Canvas canvas, Color color)
        {
            this.canvas = canvas;
            solidBrush = new SolidColorBrush(color);
            ellipses = new List<Ellipse>();
        }

        public void addDot(NetytarButton button)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = 30;
            ellipse.Width = 30;
            ellipse.Fill = solidBrush;
            ellipse.Stroke = solidBrush;
            ellipse.StrokeThickness = 10;

            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, Canvas.GetLeft(button) - 8);
            Canvas.SetTop(ellipse, Canvas.GetTop(button) - 8);
            ellipses.Add(ellipse);
        }

        public void clearDots()
        {
            foreach(Ellipse ellipse in ellipses)
            {
                canvas.Children.Remove(ellipse);
            }

            ellipses.Clear();
        }

    }
}

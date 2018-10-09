using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiraMiVoz.Filters;
using System.Windows.Controls;
using Eyerpheus.Controllers.Eyetracker;
using System.Windows;
using WPFeyerpheus.Configs;
using Eyerpheus.Chests;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;

namespace WPFeyerpheus.Controllers.Graphic
{
    class AutoScrollerCentered : IGazePointListener
    { 

        // Gets the absolute mouse position, relative to screen
        private Point GetMousePos()
        {
            return scrollViewer.PointToScreen(Mouse.GetPosition(scrollViewer));
        }

        private int proportional;
        IFilter filter;
        ScrollViewer scrollViewer;
        Point basePosition;

        private bool isOn = false;

        private int radiusThreshold;

        private double Xdifference;
        private double Ydifference;

        Point lastGazePoint;
        Point lastMean;
        Point scrollCenter;

        public AutoScrollerCentered(int radiusThreshold, ScrollViewer scrollViewer, IFilter filter, int proportional)
        {
            this.radiusThreshold = radiusThreshold;
            this.filter = filter;
            this.scrollViewer = scrollViewer;
            this.proportional = proportional;

            lastGazePoint = new Point();

            WpfEyeXChest.getChest().GazePointListener = this;
            basePosition = scrollViewer.PointToScreen(new Point(0, 0));

            scrollCenter = new Point(scrollViewer.ActualWidth / 2, scrollViewer.ActualHeight / 2);

            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += ListenMouse;
            timer.Enabled = true;

        }

        private void ListenMouse(object sender, EventArgs e)
        {
            if (WpfEyeXChest.getChest().MouseEmulation && isOn)
            {
                lastGazePoint.X = GetMousePos().X - basePosition.X;
                lastGazePoint.Y = GetMousePos().Y - basePosition.Y;

                filter.push(lastGazePoint);

                lastMean = filter.getMean();

                Scroll();
            }
        }

        private void listenMouse()
        {
            
        }

        public void receiveGazePoint(double x, double y)
        {
            lastGazePoint.X = (int)x - basePosition.X;
            lastGazePoint.Y = (int)y - basePosition.Y;

            filter.push(lastGazePoint);

            lastMean = filter.getMean();

            Scroll();
        }

        private void Scroll()
        {
            if (isOn)
            {
                Xdifference = (scrollCenter.X - lastMean.X);
                Ydifference = (scrollCenter.Y - lastMean.Y);
                if (Math.Abs(scrollCenter.Y - lastMean.Y) > radiusThreshold && Math.Abs(scrollCenter.X - lastMean.X) > radiusThreshold)
                {
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - Math.Pow((Xdifference / proportional), 2) * Math.Sign(Xdifference));
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - Math.Pow((Ydifference / proportional), 2) * Math.Sign(Ydifference));
                }

            }
        }

        internal void switchOnOff()
        {
            isOn = !isOn;
        }
    }
}

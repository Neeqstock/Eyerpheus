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

namespace WPFeyerpheus.Controllers.Graphic
{
    class AutoScrollerCentered : IGazePointListener
    {
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
        }

        public void receiveGazePoint(double x, double y)
        {
            lastGazePoint.X = (int)x - basePosition.X;
            lastGazePoint.Y = (int)y - basePosition.Y;

            filter.push(lastGazePoint);
            lastMean = filter.getMean();

            if (isOn)
            {
                Xdifference = (scrollCenter.X - lastMean.X);
                Ydifference = (scrollCenter.Y - lastMean.Y);
                if (Math.Abs(scrollCenter.Y - lastMean.Y) > radiusThreshold && Math.Abs(scrollCenter.X - lastMean.X) > radiusThreshold )
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

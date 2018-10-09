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
    class AutoScroller : IGazePointListener
    {
        int proportional;
        IFilter filter;
        ScrollViewer scrollViewer;
        Point basePosition;

        double viewerDimX;
        double viewerDimY;
        double areaDimX;
        double areaDimY;

        double Xratio;
        double Yratio;

        bool isOn = false;

        Point lastGazePoint;
        Point lastMean;

        public AutoScroller(ScrollViewer scrollViewer, IFilter filter, int proportional)
        {
            this.proportional = proportional;
            this.filter = filter;
            this.scrollViewer = scrollViewer;

            lastGazePoint = new Point();

            WpfEyeXChest.getChest().GazePointListener = this;
            basePosition = scrollViewer.PointToScreen(new Point(0, 0));

            viewerDimX = scrollViewer.ActualWidth;
            viewerDimY = scrollViewer.ActualHeight;
            areaDimX = scrollViewer.ScrollableWidth;
            areaDimY = scrollViewer.ScrollableHeight;

            Xratio = viewerDimX / areaDimX;
            Yratio = viewerDimY / areaDimY;
        }

        public void receiveGazePoint(double x, double y)
        {
            lastGazePoint.X = (int)x - basePosition.X;
            lastGazePoint.Y = (int)y - basePosition.Y;

            filter.push(lastGazePoint);
            lastMean = filter.getMean();

            if (isOn)
            {
                scrollViewer.ScrollToHorizontalOffset(lastMean.X * 3);
                scrollViewer.ScrollToVerticalOffset(lastMean.Y * 3);
                
            }
            
        }

        internal void switchOnOff()
        {
            isOn = !isOn;
        }
    }
}

using Eyerpheus;
using Eyerpheus.Chests;
using Eyerpheus.Controllers.Graphic;
using Eyerpheus.Controllers.Instruments;
using EyeXFramework;
using EyeXFramework.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
using WPFeyerpheus.Configs;
using WPFeyerpheus.Controllers.Instruments;

namespace WPFeyerpheus.Controllers.Graphic
{
    class NetytarDrawer
    {
        #region Singleton
        private static NetytarDrawer drawer;
        public static NetytarDrawer getDrawer()
        {
            return drawer;
        }

        #endregion

        private NetytarButton lastCheckedButton;
        private ChordHolderDots chordHolderDots;

        #region Settings and colors
        private List<Color> colorsEllipse = new List<Color>()
        {
            Colors.Red,
            Colors.Orange,
            Colors.Yellow,
            Colors.LightGreen,
            Colors.Blue,
            Colors.Purple,
            Colors.Coral
        };

        private const int ellipseStrokeDim = 15;
        private const int ellipseStrokeSpacer = 15;

        private const int lineThickness = 3;
        #endregion

        private ScrollViewer scrollViewer;
        private Canvas canvas;

        private NetytarButton[,] netytarButtons = new NetytarButton[GraphicsChest.getChest().netytarHeight, GraphicsChest.getChest().netytarWidth];
        private int buttonHeight = 13;
        private int buttonWidth = 13;
        private NetytarButton checkedButton;
        private int occluderOffset = 10;

        private List<Line> drawnLines = new List<Line>();
        private List<Ellipse> drawnEllipses = new List<Ellipse>();
        private bool isHold = false;

        public NetytarDrawer(ScrollViewer scrollViewer)
        {
            this.scrollViewer = scrollViewer;
            drawer = this;

            canvas = new Canvas();
            canvas.VerticalAlignment = VerticalAlignment.Stretch;
            canvas.HorizontalAlignment = HorizontalAlignment.Stretch;
            canvas.Margin = new Thickness(0, 0, 0, 0);
            canvas.Width = GraphicsChest.getChest().netytarStart * 2 + (GraphicsChest.getChest().netytarSpacing + 13) * (GraphicsChest.getChest().netytarWidth - 1);
            canvas.Height = GraphicsChest.getChest().netytarStart * 2 + (GraphicsChest.getChest().netytarSpacing + 13) * (GraphicsChest.getChest().netytarHeight - 1);
            scrollViewer.Content = canvas;

            GraphicsChest.getChest().NetytarCenter = new Point(canvas.Width / 2, canvas.Height / 2);

            chordHolderDots = new ChordHolderDots(canvas, Colors.GhostWhite);
        }

        public void generateNetytar()
        {
            int baseNote = GraphicsChest.getChest().netytarGenNote;

            int halfSpacer = GraphicsChest.getChest().netytarSpacing / 2;
            int spacer = GraphicsChest.getChest().netytarSpacing;
            int firstSpacer = 0;

            bool isPairRow;

            for (int row = 0; row < GraphicsChest.getChest().netytarHeight; row++)
            {
                for (int col = 0; col < GraphicsChest.getChest().netytarWidth; col++)
                {
                    #region Is row pair?
                    if (row % 2 != 0)
                    {
                        isPairRow = false;
                    }
                    else
                    {
                        isPairRow = true;
                    }
                    #endregion

                    #region Draw the button on canvas
                    if (isPairRow)
                    {
                        firstSpacer = GraphicsChest.getChest().netytarSpacing / 2;
                    }
                    else
                    {
                        firstSpacer = 0;
                    }

                    netytarButtons[row, col] = new NetytarButton();
                    netytarButtons[row, col].ToolTip = row.ToString() + " " + col.ToString();
                    int X = GraphicsChest.getChest().netytarStart + firstSpacer + col * GraphicsChest.getChest().netytarSpacing;
                    int Y = GraphicsChest.getChest().netytarStart + halfSpacer * row;
                    Canvas.SetLeft(netytarButtons[row, col], X);
                    Canvas.SetTop(netytarButtons[row, col], Y);

                    // OCCLUDER
                    netytarButtons[row, col].Occluder.Points = new PointCollection() { new Point(X - occluderOffset, Y + buttonWidth / 2), new Point(X + buttonWidth / 2 + 1, Y - occluderOffset), new Point(X + buttonWidth + occluderOffset + 1, Y + buttonWidth / 2), new Point(X + buttonWidth / 2 + 1, Y + buttonHeight + occluderOffset)};

                    Panel.SetZIndex(netytarButtons[row, col], 1);
                    Panel.SetZIndex(netytarButtons[row, col].Occluder, 200);
                    canvas.Children.Add(netytarButtons[row, col]);
                    canvas.Children.Add(netytarButtons[row, col].Occluder);

                    netytarButtons[row, col].Width = buttonWidth;
                    netytarButtons[row, col].Height = buttonHeight;
                    #endregion

                    #region Define note
                    int calcNote = baseNote;
                    calcNote += col * 2 + row * 2;
                    if (isPairRow)
                    {
                        calcNote += 1;
                    }
                    netytarButtons[row, col].Note = calcNote;
                    #endregion

                    #region Behavior
                    #endregion
                }
            }
        }

        public void drawLines(Scales scale, Color color)
        {
            clearLines();

            bool isPairRow;

            Point realCenter1;
            Point realCenter2;

            Brush brush;

            for (int row = 0; row < GraphicsChest.getChest().netytarHeight; row++)
            {
                for (int col = 0; col < GraphicsChest.getChest().netytarWidth; col++)
                {

                    #region Is row pair?
                    if (row % 2 != 0)
                    {
                        isPairRow = false;
                    }
                    else
                    {
                        isPairRow = true;
                    }
                    #endregion

                    #region Draw horizontal lines
                    if (col != 0)
                    {
                        if (MusicMaster.isInScale(netytarButtons[row, col].Note, scale) && MusicMaster.isInScale(netytarButtons[row, col - 1].Note, scale))
                        {
                            brush = new SolidColorBrush(color);
                        }
                        else
                        {
                            brush = GraphicsChest.getChest().NotInScaleBrush;
                        }
                        realCenter1 = new Point(Canvas.GetLeft(netytarButtons[row, col]) + 0, Canvas.GetTop(netytarButtons[row, col]) + 6);
                        realCenter2 = new Point(Canvas.GetLeft(netytarButtons[row, col - 1]) + 13, Canvas.GetTop(netytarButtons[row, col - 1]) + 6);
                        Line myLine = new Line();


                        myLine.Stroke = brush;
                        myLine.X1 = realCenter1.X;
                        myLine.X2 = realCenter2.X;
                        myLine.Y1 = realCenter1.Y;
                        myLine.Y2 = realCenter2.Y;
                        myLine.HorizontalAlignment = HorizontalAlignment.Left;
                        myLine.VerticalAlignment = VerticalAlignment.Center;
                        myLine.StrokeThickness = lineThickness;
                        Panel.SetZIndex(myLine, 10);
                        drawnLines.Add(myLine);

                        netytarButtons[row, col - 1].L_p2   = myLine;
                        netytarButtons[row, col]    .L_m2   = myLine;

                    }
                    #endregion

                    #region Draw diagonal lines

                    // Diagonale A: se riga pari p+1, se dispari p+3
                    if (row != 0)
                    {
                        if (MusicMaster.isInScale(netytarButtons[row, col].Note, scale) && MusicMaster.isInScale(netytarButtons[row - 1, col].Note, scale))
                        {
                            brush = new SolidColorBrush(color);
                        }
                        else
                        {
                            brush = GraphicsChest.getChest().NotInScaleBrush;
                        }

                        if (isPairRow)
                        {
                            realCenter1 = new Point(Canvas.GetLeft(netytarButtons[row, col]) + 2, Canvas.GetTop(netytarButtons[row, col]) + 2);
                            realCenter2 = new Point(Canvas.GetLeft(netytarButtons[row - 1, col]) + 11, Canvas.GetTop(netytarButtons[row - 1, col]) + 11);
                        }
                        else
                        {
                            realCenter1 = new Point(Canvas.GetLeft(netytarButtons[row, col]) + 11, Canvas.GetTop(netytarButtons[row, col]) + 2);
                            realCenter2 = new Point(Canvas.GetLeft(netytarButtons[row - 1, col]) + 2, Canvas.GetTop(netytarButtons[row - 1, col]) + 11);
                        }


                        Line myLine = new Line();

                        myLine.Stroke = brush;
                        myLine.X1 = realCenter1.X;
                        myLine.X2 = realCenter2.X;
                        myLine.Y1 = realCenter1.Y;
                        myLine.Y2 = realCenter2.Y;
                        myLine.HorizontalAlignment = HorizontalAlignment.Left;
                        myLine.VerticalAlignment = VerticalAlignment.Center;
                        myLine.StrokeThickness = lineThickness;
                        Panel.SetZIndex(myLine, 10);
                        drawnLines.Add(myLine);

                        if (isPairRow)
                        {
                            netytarButtons[row - 1, col].L_p3 = myLine;
                            netytarButtons[row, col].L_m3 = myLine;
                        }else
                        {
                            netytarButtons[row - 1, col].L_p1 = myLine;
                            netytarButtons[row, col].L_m1 = myLine;
                        }

                        // Diagonale B: se riga pari p+3, se dispari p+1

                        if (isPairRow)
                        {

                            if (col < GraphicsChest.getChest().netytarWidth - 1)
                            {
                                if (MusicMaster.isInScale(netytarButtons[row, col].Note, scale) && MusicMaster.isInScale(netytarButtons[row - 1, col + 1].Note, scale))
                                {
                                    brush = new SolidColorBrush(color);
                                }
                                else
                                {
                                    brush = GraphicsChest.getChest().NotInScaleBrush;
                                }
                                realCenter1 = new Point(Canvas.GetLeft(netytarButtons[row, col]) + 11, Canvas.GetTop(netytarButtons[row, col]) + 2);
                                realCenter2 = new Point(Canvas.GetLeft(netytarButtons[row - 1, col + 1]) + 2, Canvas.GetTop(netytarButtons[row - 1, col + 1]) + 11);

                                Line diaLine = new Line();


                                diaLine.Stroke = brush;
                                diaLine.X1 = realCenter1.X;
                                diaLine.X2 = realCenter2.X;
                                diaLine.Y1 = realCenter1.Y;
                                diaLine.Y2 = realCenter2.Y;
                                diaLine.HorizontalAlignment = HorizontalAlignment.Left;
                                diaLine.VerticalAlignment = VerticalAlignment.Center;
                                diaLine.StrokeThickness = lineThickness;
                                Panel.SetZIndex(diaLine, 10);
                                drawnLines.Add(diaLine);

                                netytarButtons[row - 1, col + 1].L_p1 = diaLine;
                                netytarButtons[row, col].L_m1 = diaLine;
                            }
                        }
                        else
                        {
                            if (col > 0)
                            {
                                if (MusicMaster.isInScale(netytarButtons[row, col].Note, scale) && MusicMaster.isInScale(netytarButtons[row - 1, col - 1].Note, scale))
                                {
                                    brush = new SolidColorBrush(color);
                                }
                                else
                                {
                                    brush = GraphicsChest.getChest().NotInScaleBrush;
                                }
                                realCenter1 = new Point(Canvas.GetLeft(netytarButtons[row, col]) + 2, Canvas.GetTop(netytarButtons[row, col]) + 2);
                                realCenter2 = new Point(Canvas.GetLeft(netytarButtons[row - 1, col - 1]) + 11, Canvas.GetTop(netytarButtons[row - 1, col - 1]) + 11);

                                Line diaLine = new Line();

                                diaLine.Stroke = brush;
                                diaLine.X1 = realCenter1.X;
                                diaLine.X2 = realCenter2.X;
                                diaLine.Y1 = realCenter1.Y;
                                diaLine.Y2 = realCenter2.Y;
                                diaLine.HorizontalAlignment = HorizontalAlignment.Left;
                                diaLine.VerticalAlignment = VerticalAlignment.Center;
                                diaLine.StrokeThickness = lineThickness;
                                Panel.SetZIndex(diaLine, 10);
                                drawnLines.Add(diaLine);

                                netytarButtons[row - 1, col - 1].L_p3 = diaLine;
                                netytarButtons[row, col].L_m3 = diaLine;
                            }
                        }

                    }
                    #endregion

                }
            }

            foreach (Line line in drawnLines)
            {
                canvas.Children.Add(line);
            }
        }

        public void clearLines()
        {
            foreach (Line line in drawnLines)
            {
                canvas.Children.Remove(line);
            }

            drawnLines = new List<Line>();
        }
        
        public void clearEllipses()
        {
            foreach (Ellipse ellipse in drawnEllipses)
            {
                canvas.Children.Remove(ellipse);
            }

            drawnEllipses = new List<Ellipse>();
        }
    
        public void drawEllipses(Scales scale)
        {

            clearEllipses();

            String[] strScale = MusicMaster.getScale(scale);

            for(int j = 0; j < GraphicsChest.getChest().netytarWidth; j++)
            {
                for (int k = 0; k < GraphicsChest.getChest().netytarWidth; k++)
                {
                    for (int i = 0; i < strScale.Length; i++)
                    {
                        string notainstringa = MusicMaster.getNote(netytarButtons[j,k].Note).ToString();
                        notainstringa = notainstringa.Remove(notainstringa.Length - 1);
                        if (notainstringa.Equals(strScale[i]))
                        {
                            Ellipse ellipse = new Ellipse();
                            ellipse.StrokeThickness = ellipseStrokeDim;
                            ellipse.Stroke = new SolidColorBrush(colorsEllipse[i]);
                            ellipse.Width = netytarButtons[j, k].Width + ellipseStrokeSpacer * 2;
                            ellipse.Height = netytarButtons[j, k].Height + ellipseStrokeSpacer * 2;
                            Canvas.SetLeft(ellipse, Canvas.GetLeft(netytarButtons[j, k]) - ellipseStrokeSpacer + 0.4);
                            Canvas.SetTop(ellipse, Canvas.GetTop(netytarButtons[j, k]) - ellipseStrokeSpacer + 0.2);
                            drawnEllipses.Add(ellipse);
                        }
                    }
                }
            }

            foreach(Ellipse ellipse in drawnEllipses)
            {
                canvas.Children.Add(ellipse);
            }
        }

        public void netytarButton_OnGaze(NetytarButton sender, bool hasGaze)
        {
            if (hasGaze)
            {
                lastCheckedButton = checkedButton;
                checkedButton = sender;

                flashIndependentLine();

                InstrumentChest.getChest().Instrument.setNote(checkedButton.Note);
                GraphicsChest.getChest().NetytarWatched = new Point(Canvas.GetLeft(checkedButton), Canvas.GetTop(checkedButton));

                flashSpark();

                if (isHold)
                {
                    chordHolderDots.addDot(checkedButton);
                }
            }


        }

        private void flashIndependentLine()
        {
            if(lastCheckedButton != null)
            {
                Point point1 = new Point(Canvas.GetLeft(checkedButton) + 6, Canvas.GetTop(checkedButton) + 6);
                Point point2 = new Point(Canvas.GetLeft(lastCheckedButton) + 6, Canvas.GetTop(lastCheckedButton) + 6);
                IndependentLineFlashTimer timer = new IndependentLineFlashTimer(point1, point2, canvas, Colors.NavajoWhite);
            }
            
        }

        private void flashSpark()
        {
            Image image = new Image();
            image.Height = 40;
            image.Width = 40;
            Canvas.SetLeft(image, Canvas.GetLeft(checkedButton) - 10);
            Canvas.SetTop(image, Canvas.GetTop(checkedButton) - 15);
            canvas.Children.Add(image);

            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();
            bitImage.UriSource = new Uri("C:/spark3.gif");
            bitImage.EndInit();
            ImageBehavior.SetAnimatedSource(image, bitImage);
            ImageBehavior.SetRepeatBehavior(image, new RepeatBehavior(1));
            ImageBehavior.AddAnimationCompletedHandler(image, disposeImage);
        }

        private void disposeImage(object sender, RoutedEventArgs e)
        {
            canvas.Children.Remove(((Image)sender));
        }

        private void flashLine(Line line)
        {
            if (line != null)
            {
                LineFlashTimer timer = new LineFlashTimer(line, canvas, Colors.NavajoWhite);
            }
                
        }

        public void unHold()
        {
            chordHolderDots.clearDots();
            isHold = false;
        }

        public void hold()
        {
            isHold = true;
            chordHolderDots.addDot(checkedButton);
        }
    }
}

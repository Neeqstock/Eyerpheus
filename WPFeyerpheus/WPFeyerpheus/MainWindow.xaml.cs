using Eyerpheus;
using Eyerpheus.Controllers.Instruments;
using EyeXFramework.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiraMiVoz;
using MiraMiVoz.Filters;
using WPFeyerpheus.Configs;
using WPFeyerpheus.Controllers.Graphic;
using Eyerpheus.Controllers.Eyetracker;
using WPFeyerpheus.Controllers.Instruments;
using Eyerpheus.Chests;
using WPFeyerpheus.Chests;
using WPFeyerpheus.Controllers.PlayModes;
using WPFeyerpheus.Controllers.PlayModes.WickiEyeden;

namespace WPFeyerpheus
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INoteAndPlayListener
    {
        private AutoScrollerCentered netytarAutoScroller;
        private AutoScrollerCentered wickiEyedenAutoScroller;

        private ChordHolderDots chordHolderDots;

        public MainWindow()
        {
            InitializeComponent();

            AddScaleListItems();

            AudioChest.spawnChest();

            InstrumentChest.getChest().Instrument = new FingeredInstrument();
            InstrumentChest.getChest().NoteAndPlayListeners.Add(this);

            GraphicsChest.getChest().NetytarDrawer = new NetytarDrawer(this.scrlNetytar);
            GraphicsChest.getChest().NetytarDrawer.generateNetytar();
            GraphicsChest.getChest().NetytarDrawer.drawLines(Scales.Cmaj, Colors.Red);
            GraphicsChest.getChest().NetytarDrawer.drawEllipses(Scales.Cmaj);

            GraphicsChest.getChest().WickiEyedenDrawer = new WickiEyedenDrawer(this.scrlWickiEyeden);
            GraphicsChest.getChest().WickiEyedenDrawer.generateWickiEyeden();

            InstrumentChest.getChest().WickiEyedenPlayMode = new WickiEyedenPlayWithGaze();

            GraphicsChest.getChest().RhythmFlasher = new RhythmFlasher(this.scrlNetytar, Colors.Bisque);

            // WpfEyeXChest.getChest().getBlinkProcessor().Listeners.Add(new ScaleBlinker("min", "maj"));
            WpfEyeXChest.getChest().getBlinkProcessor().Listeners.Add(new RepeatNoteWithDouble());
            //WpfEyeXChest.getChest().getBlinkProcessor().Listeners.Add(new PauseWithOneEye(Eyes.Left));
            lblBpm.Text = GraphicsChest.getChest().RhythmFlasher.Bpm.ToString();
        }

        private void AddScaleListItems()
        {
            foreach (Scales scale in Enum.GetValues(typeof(Scales)))
            {
                ListBoxItem item = new ListBoxItem() { Content = scale.ToString() };
                lstScaleChanger.Items.Add(item);
            }
        }

        public void receiveNote(int note)
        {
            txtNote.Text = note.ToString();
            txtNoteName.Text = MusicMaster.getNote(note).ToString();
            txtWickiNoteName.Text = MusicMaster.getNote(note).ToString();
            txtWickiNote.Text = note.ToString();
        }

        public void receiveIsBlowing(bool isBlowing)
        {
            if (isBlowing)
            {
                txtIsBlowing.Text = "B";
                txtWickiIsBlowing.Text = "B";
            }
            else
            {
                txtIsBlowing.Text = "_";
                txtWickiIsBlowing.Text = "_";
            }
        }

        private void btnScroll_Click(object sender, RoutedEventArgs e)
        {
            if(netytarAutoScroller == null)
            {
                netytarAutoScroller = new AutoScrollerCentered(0, scrlNetytar, new ExpDecayingFilter(0.1f), 100);
            }
            netytarAutoScroller.switchOnOff();
        }

        private void tabSolo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.S && !e.IsRepeat)
            {
                InstrumentChest.getChest().Instrument.processStartPlaying();
            }

            if (e.Key == Key.D && !e.IsRepeat)
            {
                GraphicsChest.getChest().NetytarDrawer.hold();
                InstrumentChest.getChest().Instrument.processStartHold();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                
                InstrumentChest.getChest().Instrument.processStopPlaying();
            }
            if (e.Key == Key.D)
            {
                GraphicsChest.getChest().NetytarDrawer.unHold();
                InstrumentChest.getChest().Instrument.processStopHold();
            }
        }

        private void btnFlasher_Click(object sender, RoutedEventArgs e)
        {
            if (!GraphicsChest.getChest().RhythmFlasher.isStarted())
            {
                GraphicsChest.getChest().RhythmFlasher.start();
            }else
            {
                GraphicsChest.getChest().RhythmFlasher.stop();
            }
        }

        private void btnBpmDown_Click(object sender, RoutedEventArgs e)
        {
            GraphicsChest.getChest().RhythmFlasher.Bpm--;
            lblBpm.Text = GraphicsChest.getChest().RhythmFlasher.Bpm.ToString();
        }

        private void btnBpmUp_Click(object sender, RoutedEventArgs e)
        {
            GraphicsChest.getChest().RhythmFlasher.Bpm++;
            lblBpm.Text = GraphicsChest.getChest().RhythmFlasher.Bpm.ToString();
        }
        
        private void btnFFBTest_Click(object sender, RoutedEventArgs e)
        {
            ExternalControllersChest.getChest().GamepadController.flashFFB();
        }

        private void btnNetytarSelect_Click(object sender, RoutedEventArgs e)
        {
            tabSolo.SelectedItem = tabNetytar;
            netytarAutoScroller = null;
        }

        private void btnWickiEyedenSelect_Click(object sender, RoutedEventArgs e)
        {
            tabSolo.SelectedItem = tabWickiEyeden;
            wickiEyedenAutoScroller = null;
        }

        private void btnWickiScroll_Click(object sender, RoutedEventArgs e)
        {
            if (wickiEyedenAutoScroller == null)
            {
                wickiEyedenAutoScroller = new AutoScrollerCentered(0, scrlWickiEyeden, new ExpDecayingFilter(0.1f), 100);
            }
            wickiEyedenAutoScroller.switchOnOff();
        }

        private void lstScaleChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string scaleString = ((ListBoxItem)lstScaleChanger.SelectedItem).Content.ToString();
            Scales scale = (Scales)Enum.Parse(typeof(Scales), scaleString);
            Color color = Colors.Green;

            if (scaleString.EndsWith("maj"))
            {
                color = Colors.Red;
            }
            else if (scaleString.EndsWith("min"))
            {
                color = Colors.Blue;
            }

            GraphicsChest.getChest().NetytarDrawer.drawLines(scale, color);
            GraphicsChest.getChest().NetytarDrawer.drawEllipses(scale);
        }

        private void btnMIDIchMinus_Click(object sender, RoutedEventArgs e)
        {
            if(!(AudioChest.getChest().MidiOutputChannel <= AudioChest.getChest().midiChannelMin))
            {
                AudioChest.getChest().MidiOutputChannel--;
                lblMIDIch.Text = "ch" + AudioChest.getChest().MidiOutputChannel.ToString();
            }
        }

        private void btnMIDIchPlus_Click(object sender, RoutedEventArgs e)
        {
            if (!(AudioChest.getChest().MidiOutputChannel >= AudioChest.getChest().midiChannelMax))
            {
                AudioChest.getChest().MidiOutputChannel++;
                lblMIDIch.Text = "ch" + AudioChest.getChest().MidiOutputChannel.ToString();
            }
        }
    }
}
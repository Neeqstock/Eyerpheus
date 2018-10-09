using Eyerpheus.Controllers.Midi;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFeyerpheus.Chests;

namespace Eyerpheus
{
    class MidiControllerToolkit : IMidiController
    {

        private ChannelMessageBuilder channelBuilder = new ChannelMessageBuilder();

        private OutputDevice outDevice;
        private int outDeviceID = 0;

        public MidiControllerToolkit()
        {
            #region ToolkitThings
            if (OutputDevice.DeviceCount == 0)
            {
                MessageBox.Show("No MIDI output devices available.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    outDevice = new OutputDevice(outDeviceID);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }
            #endregion
        }

        public void playNote(int note, int velocity)
        {
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, AudioChest.getChest().MidiOutputChannel, note, velocity));
        }

        public void stopNote(int note)
        {
            outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, AudioChest.getChest().MidiOutputChannel, note, 0));
        }
    }
}

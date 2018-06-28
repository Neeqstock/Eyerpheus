using MIDI_statistics.Midi;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI_statistics
{
    public partial class MidiStatisticsForm : Form
    {
        private OpenFileDialog openMidiFileDialog = new OpenFileDialog();
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private string testFolder;
        private bool enableHuman;
        private bool enableMachine;
        private string machineFileName;
        private string humanFileName;
        private string[] multipleFiles;

        private string resultFileName;

        private Sequence machineSequence = new Sequence();
        private Track machineTrack;

        private Sequence humanSequence = new Sequence();
        private Track humanTrack;

        private int numberMachineNotes;
        private int numberHumanNotes;
        private int numberWrongNotes;
        private int totalJitter;
        private int avgJitter;

        public MidiStatisticsForm()
        {
            InitializeComponent();
        }

        private void btnOpenMachineFile_click(object sender, EventArgs e)
        {
            if (openMidiFileDialog.ShowDialog() == DialogResult.OK)
            {
                machineFileName = openMidiFileDialog.FileName;
                lblMachineFileName.Text = machineFileName;

                enableMachine = true;
                evalEnable();
            }
        }

        private void btnOpenHumanFile_Click(object sender, EventArgs e)
        {
            if (openMidiFileDialog.ShowDialog() == DialogResult.OK)
            {
                humanFileName = openMidiFileDialog.FileName;
                lblHumanFileName.Text = humanFileName;

                enableHuman = true;
                evalEnable();
            }
        }

        private void evalEnable()
        {
            if(enableHuman && enableMachine)
            {
                btnElaborate.Enabled = true;
                btnPrintToFile.Enabled = true;
            }
        }

        private void btnElaborate_Click(object sender, EventArgs e)
        {
            elaborate();
        }

        private void elaborate()
        {
            machineSequence.Load(machineFileName);
            machineTrack = machineSequence[1];

            humanSequence.Load(humanFileName);
            humanTrack = humanSequence[1];

            #region Test area

            MidiEvent m = machineTrack.GetMidiEvent(3);
            byte[] bytes = m.MidiMessage.GetBytes();
            byte firstByte = (byte)(bytes[0] & 0xF0);
            byte secondByte = bytes[1];

            //MessageBox.Show(Convert.ToString(firstByte, 2) + " note " + secondByte.ToString() + " at " + m.AbsoluteTicks.ToString());

            if (m.MidiMessage.GetBytes().Length == 0)
            {
                // Start or end track! Coded with length 0
            }
            else
            {
                if (firstByte == (byte)MidiFirstByte.NoteOff)
                {
                    txtTest.Text = "Note off! ";
                }
                else if (firstByte == (byte)MidiFirstByte.NoteOn)
                {
                    txtTest.Text = "Note on! ";
                }
                else
                {
                    txtTest.Text = "Unknown event. ";
                }
            }
            txtTest.Text += " At " + m.AbsoluteTicks.ToString();

            #endregion

            List<MidiNote> machineNotes = MidiInterpreter.getNotesSequence(machineTrack);
            List<MidiNote> humanNotes = MidiInterpreter.getNotesSequence(humanTrack);
            List<MidiNote> wrongNotes = MidiInterpreter.getWrongNotes(machineNotes, humanNotes);
            List<MidiNote> humanCorrectNotes = MidiInterpreter.getCorrectNotes(machineNotes, humanNotes);

            numberHumanNotes = humanNotes.Count();
            numberMachineNotes = machineNotes.Count();
            numberWrongNotes = wrongNotes.Count();

            totalJitter = MidiInterpreter.getTotalJitter(machineNotes, humanCorrectNotes);
            avgJitter = totalJitter / machineNotes.Count();

            txtNumberMachineNotes.Text = numberMachineNotes.ToString();
            txtNumberHumanNotes.Text = numberHumanNotes.ToString();
            txtNumberWrongNotes.Text = numberWrongNotes.ToString();
            txtTotalJitter.Text = totalJitter.ToString();
            txtAverageJitter.Text = avgJitter.ToString();

            lstMachineNotes.Items.Clear();
            lstMachineNotes.Items.Clear();
            lstWrongNotes.Items.Clear();

            foreach (MidiNote midiNote in machineNotes)
            {
                lstMachineNotes.Items.Add(new ListViewItem(midiNote.Key + " at " + midiNote.Time));
            }

            foreach (MidiNote midiNote in humanNotes)
            {
                lstHumanNotes.Items.Add(new ListViewItem(midiNote.Key + " at " + midiNote.Time));
            }

            foreach (MidiNote midiNote in wrongNotes)
            {
                lstWrongNotes.Items.Add(new ListViewItem(midiNote.Key + " at " + midiNote.Time));
            }
        }

        private void MidiStatisticsForm_Load(object sender, EventArgs e)
        {
            //machineFileName = "C:\\Users\\Neeqstock\\Desktop\\cosomidi.mid";
            //machineSequence.Load(machineFileName);
            //lblMachineFileName.Text = machineFileName;
            //machineTrack = machineSequence[1];
            testFolder = "C:\\Users\\Neeqstock\\root\\Lavori\\Eyerpheus\\Tests\\TestFolder";
            multipleFiles = Directory.GetFiles(testFolder);
            lblTestFolder.Text = testFolder;
            
        }

        private void btnPrintToFile_Click(object sender, EventArgs e)
        {
            printToFile(txtSubjectName.Text.ToString(), txtWrapTestName.Text.ToString(), txtTrialNumber.Text.ToString());
        }

        private void printToFile(string subjectName, string wrapTestName, string trialNumber)
        {
            resultFileName = subjectName + "_" + wrapTestName + "_" + trialNumber;

            string[] lines =
            {
                "Soggetto = " + subjectName,
                "Test = " + wrapTestName,
                "Trial = " + trialNumber,
                "-----",
                "HumanFile = " + humanFileName,
                "MachineFile = " + machineFileName,
                "=====",
                "HumanNotes = " + numberHumanNotes,
                "MachineNotes = " + numberMachineNotes,
                "WrongNotes = " + numberWrongNotes,
                "TotalJitter = " + totalJitter,
                "AverageJitter = " + avgJitter
            };

            File.WriteAllLines(testFolder + "\\results\\" + resultFileName + ".txt", lines);


        }

        private void btnSelectFolder_click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                testFolder = folderBrowserDialog.SelectedPath;
                multipleFiles = Directory.GetFiles(folderBrowserDialog.SelectedPath);

                lblTestFolder.Text = testFolder;
            }
        }

        private void btnSpitFiles_Click(object sender, EventArgs e)
        {
            spitFiles();
        }

        private void spitFiles()
        {
            foreach(string path in multipleFiles)
            {
                string[] temp = path.Split('\\');
                string fileName = temp[temp.Length - 1];
                string folder = "";
                for(int i = 0; i < temp.Length - 1; i++)
                {
                    folder = folder + temp[i] + "\\";
                }
                folder = folder.Remove(folder.Length - 1);

                if (!fileName.StartsWith("machine"))
                {
                    string[] fields = fileName.Split('_');
                    string subjectName = fields[0];
                    string testName = fields[1];
                    string trial = fields[2].Split('.')[0];

                    machineFileName = folder + "\\machines\\" + "machine_" + testName + ".mid";
                    humanFileName = path;

                    elaborate();
                    printToFile(subjectName, testName, trial);
                }
            }
        }
    }
}
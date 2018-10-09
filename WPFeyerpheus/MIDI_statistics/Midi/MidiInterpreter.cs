using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI_statistics.Midi
{
    class MidiInterpreter
    {
        public static List<MidiNote> getNotesSequence(Track track)
        {
            List<MidiEvent> midiEvents = new List<MidiEvent>();
            for(int i = 0; i < track.Count; i++)
            {
                midiEvents.Add(track.GetMidiEvent(i));
            }

            List<MidiNote> notesSequence = new List<MidiNote>();
            foreach(MidiEvent midiEvent in midiEvents)
            {
                MidiNote midiNote = new MidiNote();
                
                if(midiEvent.MidiMessage.GetBytes().Length == 4)
                {
                    byte[] bytes = midiEvent.MidiMessage.GetBytes();
                    byte firstByte = (byte)(bytes[0] & 0xF0);
                    byte secondByte = (byte)(bytes[1] & 0x7F);

                    if (firstByte == (byte)MidiFirstByte.NoteOn)
                    {
                        midiNote.Key = secondByte;
                        midiNote.Time = midiEvent.AbsoluteTicks;
                        notesSequence.Add(midiNote);
                    }
                }   
            }

            return notesSequence;
        }

        public static List<MidiNote> getWrongNotes(List<MidiNote> machineNotes, List<MidiNote> humanNotes)
        {
            List<MidiNote> wrongNotes = new List<MidiNote>();

            int m = 0;
            int h = 0;

            while (m < machineNotes.Count)
            {
                bool locked = true;
                while (locked)
                {
                    if (humanNotes[h].Key != machineNotes[m].Key)
                    {
                        wrongNotes.Add(humanNotes[h]);
                    }
                    else
                    {
                        locked = false;
                    }

                    h++;
                }
                m++;
            }

            // Tutte le note oltre l'indice esplorato vanno dichiarate sbagliate.
            for(int i = h; i < humanNotes.Count; i++)
            {
                wrongNotes.Add(humanNotes[i]);
            }

            return wrongNotes;
        }

        public static List<MidiNote> getCorrectNotes(List<MidiNote> machineNotes, List<MidiNote> humanNotes)
        {
            List<MidiNote> correctNotes = new List<MidiNote>();

            int m = 0;
            int h = 0;

            while (m < machineNotes.Count)
            {
                bool locked = true;
                while (locked)
                {
                    if (humanNotes[h].Key != machineNotes[m].Key)
                    {
                        
                    }
                    else
                    {
                        correctNotes.Add(humanNotes[h]);
                        locked = false;
                    }

                    h++;
                }
                m++;
            }

            return correctNotes;
        }

        public static int getTotalJitter(List<MidiNote> machineNotes, List<MidiNote> humanCorrectNotes)
        {
            int totalJitter = 0;
            
            if(machineNotes.Count() != humanCorrectNotes.Count)
            {
                throw new Exception("Exception: machine notes number is different from human notes number. Further errors will occur.");
            }

            for(int i = 0; i < machineNotes.Count(); i++)
            {
                totalJitter += Math.Abs(machineNotes[i].Time - humanCorrectNotes[i].Time);
            }

            return totalJitter;
        }
    }
}

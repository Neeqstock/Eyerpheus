## The Eyerpheus Project

This is the result of the work for my Master Thesis in Computer Engineering at "Università di Pavia", Italy.
This project includes **Netytar**, to which the paper "_Playing music with the eyes through an isomorphic interface_" (presented at ETRA COGAIN 2018) was dedicated.

### Requisites
-	Windows operating system (tested on Windows 10. Not available for Linux :( still not supported by Tobii eyetrackers)
-	Tobii EyeX eyetracker (could work also with Tobii 4C. Never tested)
-	(Optional but recommended) A VST host with some good VST effects (included in the instructions)
- 	(Optional) XboX 360 Gamepad Controller (for FFB effects)

### Instructions (read carefully!)
1.	Clone this repository on your HD. You'll need every single file;
2.	We'll need to have a MIDI loop port on our PC. Download [loopMIDI](https://www.google.com "loopMIDI, by Tobias Erichsen") and install it. Create a loop port with an arbitrary name. **Make sure to have loopMIDI running** when you use Eyerpheus;
3.	For the VSTs, I personally recommend [VSTHost](http://www.hermannseib.com/english/vsthost.htm "VSTHost on Hermmann Seib's website"). Download and install it. It's quite simple to use: you just have to drag and drop the VST's DLL files inside, then connect them to the output. **Make sure that the desired VST takes the loopMIDI port as input**: to do so, click on the left MIDI connector image on the VST, then select the correct port as input. **Again, make sure VSTHost is running while using Eyerpheus**;
4.	Unzip and install all the fonts contained in the "digital-7.zip" file;
5.	Launch Eyerpheus using this file: _WPFeyerpheus/WPFeyerpheus/bin/debug/WPFeyerpheus.exe_.

### Netytar guide
- 	**Gaze**: selects a note. A white flash will appear to highlight the selection;
- 	**S key**: plays the selected note (use this if no other controller is available);
- 	**Autoscroll button**: triggers the automatic scrolling system (see the _Interface guide_);
- 	If an Xbox 360 controller is connected, it will vibrate at every note change.

For a greater insight into Netytar, please refer to the paper [Playing Music With the Eyes Through an Isomorphic Interface](Playing music with the eyes through an isomorphic interface.pdf) "Playing music with the eyes through an isomorphic interface"), available in this repository.

### Interface guide
-	**Netytar / WickiEyeden selector**: you can choose which instrument you want to play here. Please note that _WickiEyeden_ is incomplete and under testing.
-	![Scale selector][images/scale_selector.png] **Scale selector**: this selector is used to highlight a particular scale in Netytar's "web", an useful playing aid. A major scale will be colored in red, a minor in blue. Also the notes of the respective scale will be highlighted;
-	![First row][images/first_row.png] **Note informations**: the first mini-screen indicates the current note pitch (in MIDI note), the second indicates the note's name, while the third indicates if the note is currently being played or the instrument is silent (_B_ stands for "Blowing". Netytar is thought to be used with an external sip-and-puff input device);
-	![Second row][images/second_row.png] **Visual metronome tempo regulation**: this is used to regulate the tempo of the _visual metronome_, an experimental tool that flashes light into the interface at the selected tempo.
-	![Third row][images/third_row.png] **Triggers**: the first one triggers the "autoscroll" functionality (necessary to play both instruments): the instrument's interface will follow the gaze automatically. The second one triggers the _visual metronome_. The third one tests the FFB effect: if an Xbox 360 controller is connected to the usb port, it will vibrate.
-	![Fourth row][images/fourth_row.png] **MIDI channel selector**: this is used to select the MIDI output channel. If you don't hear any sound, try a different channel.
namespace MIDI_statistics
{
    partial class MidiStatisticsForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenMachineFile = new System.Windows.Forms.Button();
            this.btnOpenHumanFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMachineFileName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHumanFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnElaborate = new System.Windows.Forms.Button();
            this.txtNumberMachineNotes = new System.Windows.Forms.TextBox();
            this.lstMachineNotes = new System.Windows.Forms.ListBox();
            this.lstHumanNotes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblTestFolder = new System.Windows.Forms.Label();
            this.txtTrialNumber = new System.Windows.Forms.TextBox();
            this.btnPrintToFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtWrapTestName = new System.Windows.Forms.TextBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lstWrongNotes = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAverageJitter = new System.Windows.Forms.TextBox();
            this.txtTotalJitter = new System.Windows.Forms.TextBox();
            this.txtNumberWrongNotes = new System.Windows.Forms.TextBox();
            this.txtNumberHumanNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSpitFiles = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenMachineFile
            // 
            this.btnOpenMachineFile.Location = new System.Drawing.Point(8, 24);
            this.btnOpenMachineFile.Name = "btnOpenMachineFile";
            this.btnOpenMachineFile.Size = new System.Drawing.Size(112, 24);
            this.btnOpenMachineFile.TabIndex = 0;
            this.btnOpenMachineFile.Text = "Open machine file";
            this.btnOpenMachineFile.UseVisualStyleBackColor = true;
            this.btnOpenMachineFile.Click += new System.EventHandler(this.btnOpenMachineFile_click);
            // 
            // btnOpenHumanFile
            // 
            this.btnOpenHumanFile.Location = new System.Drawing.Point(8, 72);
            this.btnOpenHumanFile.Name = "btnOpenHumanFile";
            this.btnOpenHumanFile.Size = new System.Drawing.Size(112, 24);
            this.btnOpenHumanFile.TabIndex = 1;
            this.btnOpenHumanFile.Text = "Open human file";
            this.btnOpenHumanFile.UseVisualStyleBackColor = true;
            this.btnOpenHumanFile.Click += new System.EventHandler(this.btnOpenHumanFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMachineFileName);
            this.groupBox1.Location = new System.Drawing.Point(128, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source file";
            // 
            // lblMachineFileName
            // 
            this.lblMachineFileName.AutoSize = true;
            this.lblMachineFileName.Location = new System.Drawing.Point(16, 16);
            this.lblMachineFileName.Name = "lblMachineFileName";
            this.lblMachineFileName.Size = new System.Drawing.Size(118, 13);
            this.lblMachineFileName.TabIndex = 0;
            this.lblMachineFileName.Text = "Waiting for source file...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHumanFileName);
            this.groupBox2.Location = new System.Drawing.Point(128, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 40);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comparison file";
            // 
            // lblHumanFileName
            // 
            this.lblHumanFileName.AutoSize = true;
            this.lblHumanFileName.Location = new System.Drawing.Point(16, 16);
            this.lblHumanFileName.Name = "lblHumanFileName";
            this.lblHumanFileName.Size = new System.Drawing.Size(140, 13);
            this.lblHumanFileName.TabIndex = 0;
            this.lblHumanFileName.Text = "Waiting for comparison file...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of machine notes:";
            // 
            // btnElaborate
            // 
            this.btnElaborate.Enabled = false;
            this.btnElaborate.Location = new System.Drawing.Point(8, 208);
            this.btnElaborate.Name = "btnElaborate";
            this.btnElaborate.Size = new System.Drawing.Size(112, 24);
            this.btnElaborate.TabIndex = 5;
            this.btnElaborate.Text = "Elaborate statistics";
            this.btnElaborate.UseVisualStyleBackColor = true;
            this.btnElaborate.Click += new System.EventHandler(this.btnElaborate_Click);
            // 
            // txtNumberMachineNotes
            // 
            this.txtNumberMachineNotes.Location = new System.Drawing.Point(200, 32);
            this.txtNumberMachineNotes.Name = "txtNumberMachineNotes";
            this.txtNumberMachineNotes.Size = new System.Drawing.Size(100, 20);
            this.txtNumberMachineNotes.TabIndex = 6;
            // 
            // lstMachineNotes
            // 
            this.lstMachineNotes.FormattingEnabled = true;
            this.lstMachineNotes.Location = new System.Drawing.Point(8, 24);
            this.lstMachineNotes.Name = "lstMachineNotes";
            this.lstMachineNotes.Size = new System.Drawing.Size(264, 69);
            this.lstMachineNotes.TabIndex = 9;
            // 
            // lstHumanNotes
            // 
            this.lstHumanNotes.FormattingEnabled = true;
            this.lstHumanNotes.Location = new System.Drawing.Point(8, 24);
            this.lstHumanNotes.Name = "lstHumanNotes";
            this.lstHumanNotes.Size = new System.Drawing.Size(264, 69);
            this.lstHumanNotes.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Subject name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Wrap test name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Trial number:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTrialNumber);
            this.groupBox3.Controls.Add(this.btnPrintToFile);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtWrapTestName);
            this.groupBox3.Controls.Add(this.txtSubjectName);
            this.groupBox3.Controls.Add(this.btnOpenMachineFile);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnOpenHumanFile);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnElaborate);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 296);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblTestFolder);
            this.groupBox9.Location = new System.Drawing.Point(16, 400);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(384, 40);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Test folder";
            // 
            // lblTestFolder
            // 
            this.lblTestFolder.AutoSize = true;
            this.lblTestFolder.Location = new System.Drawing.Point(16, 16);
            this.lblTestFolder.Name = "lblTestFolder";
            this.lblTestFolder.Size = new System.Drawing.Size(116, 13);
            this.lblTestFolder.TabIndex = 0;
            this.lblTestFolder.Text = "Waiting for test folder...";
            // 
            // txtTrialNumber
            // 
            this.txtTrialNumber.Location = new System.Drawing.Point(136, 168);
            this.txtTrialNumber.Name = "txtTrialNumber";
            this.txtTrialNumber.Size = new System.Drawing.Size(160, 20);
            this.txtTrialNumber.TabIndex = 19;
            // 
            // btnPrintToFile
            // 
            this.btnPrintToFile.Enabled = false;
            this.btnPrintToFile.Location = new System.Drawing.Point(136, 208);
            this.btnPrintToFile.Name = "btnPrintToFile";
            this.btnPrintToFile.Size = new System.Drawing.Size(112, 24);
            this.btnPrintToFile.TabIndex = 18;
            this.btnPrintToFile.Text = "Print to file";
            this.btnPrintToFile.UseVisualStyleBackColor = true;
            this.btnPrintToFile.Click += new System.EventHandler(this.btnPrintToFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSelectFolder_click);
            // 
            // txtWrapTestName
            // 
            this.txtWrapTestName.Location = new System.Drawing.Point(136, 144);
            this.txtWrapTestName.Name = "txtWrapTestName";
            this.txtWrapTestName.Size = new System.Drawing.Size(160, 20);
            this.txtWrapTestName.TabIndex = 17;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(136, 120);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(160, 20);
            this.txtSubjectName.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtAverageJitter);
            this.groupBox4.Controls.Add(this.txtTotalJitter);
            this.groupBox4.Controls.Add(this.txtNumberWrongNotes);
            this.groupBox4.Controls.Add(this.txtNumberHumanNotes);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtNumberMachineNotes);
            this.groupBox4.Location = new System.Drawing.Point(416, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 488);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Results";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lstWrongNotes);
            this.groupBox7.Location = new System.Drawing.Point(16, 368);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(280, 104);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Wrong notes";
            // 
            // lstWrongNotes
            // 
            this.lstWrongNotes.FormattingEnabled = true;
            this.lstWrongNotes.Location = new System.Drawing.Point(8, 24);
            this.lstWrongNotes.Name = "lstWrongNotes";
            this.lstWrongNotes.Size = new System.Drawing.Size(264, 69);
            this.lstWrongNotes.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Average jitter per note:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Total jitter:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Number of wrong notes:";
            // 
            // txtAverageJitter
            // 
            this.txtAverageJitter.Location = new System.Drawing.Point(200, 128);
            this.txtAverageJitter.Name = "txtAverageJitter";
            this.txtAverageJitter.Size = new System.Drawing.Size(100, 20);
            this.txtAverageJitter.TabIndex = 15;
            // 
            // txtTotalJitter
            // 
            this.txtTotalJitter.Location = new System.Drawing.Point(200, 104);
            this.txtTotalJitter.Name = "txtTotalJitter";
            this.txtTotalJitter.Size = new System.Drawing.Size(100, 20);
            this.txtTotalJitter.TabIndex = 14;
            // 
            // txtNumberWrongNotes
            // 
            this.txtNumberWrongNotes.Location = new System.Drawing.Point(200, 80);
            this.txtNumberWrongNotes.Name = "txtNumberWrongNotes";
            this.txtNumberWrongNotes.Size = new System.Drawing.Size(100, 20);
            this.txtNumberWrongNotes.TabIndex = 13;
            // 
            // txtNumberHumanNotes
            // 
            this.txtNumberHumanNotes.Location = new System.Drawing.Point(200, 56);
            this.txtNumberHumanNotes.Name = "txtNumberHumanNotes";
            this.txtNumberHumanNotes.Size = new System.Drawing.Size(100, 20);
            this.txtNumberHumanNotes.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Number of human notes:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lstHumanNotes);
            this.groupBox6.Location = new System.Drawing.Point(16, 264);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 104);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Human notes";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstMachineNotes);
            this.groupBox5.Location = new System.Drawing.Point(16, 160);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 104);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Machine notes";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnSpitFiles);
            this.groupBox8.Location = new System.Drawing.Point(8, 312);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(128, 56);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Multiple file elaboration";
            // 
            // btnSpitFiles
            // 
            this.btnSpitFiles.Location = new System.Drawing.Point(8, 24);
            this.btnSpitFiles.Name = "btnSpitFiles";
            this.btnSpitFiles.Size = new System.Drawing.Size(104, 23);
            this.btnSpitFiles.TabIndex = 1;
            this.btnSpitFiles.Text = "Spit files!";
            this.btnSpitFiles.UseVisualStyleBackColor = true;
            this.btnSpitFiles.Click += new System.EventHandler(this.btnSpitFiles_Click);
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(144, 376);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(160, 20);
            this.txtTest.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Test value:";
            // 
            // MidiStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 495);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "MidiStatisticsForm";
            this.Text = "Midi Statistics";
            this.Load += new System.EventHandler(this.MidiStatisticsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenMachineFile;
        private System.Windows.Forms.Button btnOpenHumanFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMachineFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHumanFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnElaborate;
        private System.Windows.Forms.TextBox txtNumberMachineNotes;
        private System.Windows.Forms.ListBox lstMachineNotes;
        private System.Windows.Forms.ListBox lstHumanNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWrapTestName;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtTrialNumber;
        private System.Windows.Forms.Button btnPrintToFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAverageJitter;
        private System.Windows.Forms.TextBox txtTotalJitter;
        private System.Windows.Forms.TextBox txtNumberWrongNotes;
        private System.Windows.Forms.TextBox txtNumberHumanNotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox lstWrongNotes;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnSpitFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblTestFolder;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Label label2;
    }
}


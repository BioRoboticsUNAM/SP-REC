namespace SpRec3
{
	partial class FrmSpRec
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpRec));
			this.txtRecognizedText = new System.Windows.Forms.TextBox();
			this.txtHypothesis = new System.Windows.Forms.TextBox();
			this.txtRejected = new System.Windows.Forms.TextBox();
			this.gbHypothesys = new System.Windows.Forms.GroupBox();
			this.gbRejected = new System.Windows.Forms.GroupBox();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.lblVolumeTreshold = new System.Windows.Forms.Label();
			this.nudVolumeTreshold = new System.Windows.Forms.NumericUpDown();
			this.cmbProfiles = new System.Windows.Forms.ComboBox();
			this.btnExploreGrammar = new System.Windows.Forms.Button();
			this.btnLoadGrammar = new System.Windows.Forms.Button();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.txtGrammarFile = new System.Windows.Forms.TextBox();
			this.lblProfile = new System.Windows.Forms.Label();
			this.lblGrammar = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.chkSendRejected = new System.Windows.Forms.CheckBox();
			this.gbSpeechRecognized = new System.Windows.Forms.GroupBox();
			this.lblAudioLevel = new System.Windows.Forms.Label();
			this.pbAudioLevel = new System.Windows.Forms.ProgressBar();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.lblServerStarted = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblClientConnected = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblCurrentAddres = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblCurrentInputPort = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblCurrentOutputPort = new System.Windows.Forms.ToolStripStatusLabel();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.chkFreeDictation = new System.Windows.Forms.CheckBox();
			this.gbHypothesys.SuspendLayout();
			this.gbRejected.SuspendLayout();
			this.gbSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudVolumeTreshold)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.gbSpeechRecognized.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtRecognizedText
			// 
			this.txtRecognizedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRecognizedText.Location = new System.Drawing.Point(6, 19);
			this.txtRecognizedText.Multiline = true;
			this.txtRecognizedText.Name = "txtRecognizedText";
			this.txtRecognizedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRecognizedText.Size = new System.Drawing.Size(460, 81);
			this.txtRecognizedText.TabIndex = 0;
			// 
			// txtHypothesis
			// 
			this.txtHypothesis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHypothesis.Location = new System.Drawing.Point(6, 19);
			this.txtHypothesis.Multiline = true;
			this.txtHypothesis.Name = "txtHypothesis";
			this.txtHypothesis.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtHypothesis.Size = new System.Drawing.Size(223, 97);
			this.txtHypothesis.TabIndex = 0;
			// 
			// txtRejected
			// 
			this.txtRejected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRejected.Location = new System.Drawing.Point(5, 19);
			this.txtRejected.Multiline = true;
			this.txtRejected.Name = "txtRejected";
			this.txtRejected.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRejected.Size = new System.Drawing.Size(213, 74);
			this.txtRejected.TabIndex = 0;
			// 
			// gbHypothesys
			// 
			this.gbHypothesys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbHypothesys.Controls.Add(this.txtHypothesis);
			this.gbHypothesys.Location = new System.Drawing.Point(3, 3);
			this.gbHypothesys.Name = "gbHypothesys";
			this.gbHypothesys.Size = new System.Drawing.Size(235, 123);
			this.gbHypothesys.TabIndex = 3;
			this.gbHypothesys.TabStop = false;
			this.gbHypothesys.Text = "Hypothesys:";
			// 
			// gbRejected
			// 
			this.gbRejected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbRejected.Controls.Add(this.txtRejected);
			this.gbRejected.Location = new System.Drawing.Point(3, 3);
			this.gbRejected.Name = "gbRejected";
			this.gbRejected.Size = new System.Drawing.Size(225, 100);
			this.gbRejected.TabIndex = 4;
			this.gbRejected.TabStop = false;
			this.gbRejected.Text = "Rejected:";
			// 
			// gbSettings
			// 
			this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSettings.Controls.Add(this.chkFreeDictation);
			this.gbSettings.Controls.Add(this.lblVolumeTreshold);
			this.gbSettings.Controls.Add(this.nudVolumeTreshold);
			this.gbSettings.Controls.Add(this.cmbProfiles);
			this.gbSettings.Controls.Add(this.btnExploreGrammar);
			this.gbSettings.Controls.Add(this.btnLoadGrammar);
			this.gbSettings.Controls.Add(this.chkEnable);
			this.gbSettings.Controls.Add(this.txtGrammarFile);
			this.gbSettings.Controls.Add(this.lblProfile);
			this.gbSettings.Controls.Add(this.lblGrammar);
			this.gbSettings.Location = new System.Drawing.Point(12, 12);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(476, 104);
			this.gbSettings.TabIndex = 5;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Settings:";
			// 
			// lblVolumeTreshold
			// 
			this.lblVolumeTreshold.AutoSize = true;
			this.lblVolumeTreshold.Location = new System.Drawing.Point(190, 78);
			this.lblVolumeTreshold.Name = "lblVolumeTreshold";
			this.lblVolumeTreshold.Size = new System.Drawing.Size(89, 13);
			this.lblVolumeTreshold.TabIndex = 7;
			this.lblVolumeTreshold.Text = "Volume Treshold:";
			// 
			// nudVolumeTreshold
			// 
			this.nudVolumeTreshold.Location = new System.Drawing.Point(285, 76);
			this.nudVolumeTreshold.Name = "nudVolumeTreshold";
			this.nudVolumeTreshold.Size = new System.Drawing.Size(50, 20);
			this.nudVolumeTreshold.TabIndex = 6;
			this.nudVolumeTreshold.ValueChanged += new System.EventHandler(this.nudVolumeTreshold_ValueChanged);
			// 
			// cmbProfiles
			// 
			this.cmbProfiles.FormattingEnabled = true;
			this.cmbProfiles.Location = new System.Drawing.Point(66, 46);
			this.cmbProfiles.Name = "cmbProfiles";
			this.cmbProfiles.Size = new System.Drawing.Size(371, 21);
			this.cmbProfiles.TabIndex = 5;
			this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbProfiles_SelectedIndexChanged);
			// 
			// btnExploreGrammar
			// 
			this.btnExploreGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExploreGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExploreGrammar.Image = global::SpRec3.Properties.Resources.ZoomHS;
			this.btnExploreGrammar.Location = new System.Drawing.Point(443, 18);
			this.btnExploreGrammar.Name = "btnExploreGrammar";
			this.btnExploreGrammar.Size = new System.Drawing.Size(23, 23);
			this.btnExploreGrammar.TabIndex = 4;
			this.btnExploreGrammar.UseVisualStyleBackColor = true;
			this.btnExploreGrammar.Click += new System.EventHandler(this.btnExploreGrammar_Click);
			// 
			// btnLoadGrammar
			// 
			this.btnLoadGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadGrammar.Location = new System.Drawing.Point(341, 73);
			this.btnLoadGrammar.Name = "btnLoadGrammar";
			this.btnLoadGrammar.Size = new System.Drawing.Size(125, 23);
			this.btnLoadGrammar.TabIndex = 3;
			this.btnLoadGrammar.Text = "Load Grammar";
			this.btnLoadGrammar.UseVisualStyleBackColor = true;
			this.btnLoadGrammar.Click += new System.EventHandler(this.btnLoadGrammar_Click);
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(11, 77);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(65, 17);
			this.chkEnable.TabIndex = 2;
			this.chkEnable.Text = "Enabled";
			this.chkEnable.UseVisualStyleBackColor = true;
			this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
			// 
			// txtGrammarFile
			// 
			this.txtGrammarFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGrammarFile.Location = new System.Drawing.Point(66, 20);
			this.txtGrammarFile.Name = "txtGrammarFile";
			this.txtGrammarFile.Size = new System.Drawing.Size(371, 20);
			this.txtGrammarFile.TabIndex = 1;
			// 
			// lblProfile
			// 
			this.lblProfile.AutoSize = true;
			this.lblProfile.Location = new System.Drawing.Point(8, 49);
			this.lblProfile.Name = "lblProfile";
			this.lblProfile.Size = new System.Drawing.Size(39, 13);
			this.lblProfile.TabIndex = 0;
			this.lblProfile.Text = "Profile:";
			// 
			// lblGrammar
			// 
			this.lblGrammar.AutoSize = true;
			this.lblGrammar.Location = new System.Drawing.Point(8, 23);
			this.lblGrammar.Name = "lblGrammar";
			this.lblGrammar.Size = new System.Drawing.Size(52, 13);
			this.lblGrammar.TabIndex = 0;
			this.lblGrammar.Text = "Grammar:";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 122);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gbHypothesys);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.gbRejected);
			this.splitContainer1.Panel2.Controls.Add(this.chkSendRejected);
			this.splitContainer1.Size = new System.Drawing.Size(476, 129);
			this.splitContainer1.SplitterDistance = 241;
			this.splitContainer1.TabIndex = 6;
			// 
			// chkSendRejected
			// 
			this.chkSendRejected.AutoSize = true;
			this.chkSendRejected.Enabled = false;
			this.chkSendRejected.Location = new System.Drawing.Point(3, 109);
			this.chkSendRejected.Name = "chkSendRejected";
			this.chkSendRejected.Size = new System.Drawing.Size(97, 17);
			this.chkSendRejected.TabIndex = 2;
			this.chkSendRejected.Text = "Send Rejected";
			this.chkSendRejected.UseVisualStyleBackColor = true;
			this.chkSendRejected.CheckedChanged += new System.EventHandler(this.chkSendRejected_CheckedChanged);
			// 
			// gbSpeechRecognized
			// 
			this.gbSpeechRecognized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSpeechRecognized.Controls.Add(this.lblAudioLevel);
			this.gbSpeechRecognized.Controls.Add(this.pbAudioLevel);
			this.gbSpeechRecognized.Controls.Add(this.txtRecognizedText);
			this.gbSpeechRecognized.Location = new System.Drawing.Point(12, 257);
			this.gbSpeechRecognized.Name = "gbSpeechRecognized";
			this.gbSpeechRecognized.Size = new System.Drawing.Size(476, 125);
			this.gbSpeechRecognized.TabIndex = 7;
			this.gbSpeechRecognized.TabStop = false;
			this.gbSpeechRecognized.Text = "Speech Recognized";
			// 
			// lblAudioLevel
			// 
			this.lblAudioLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblAudioLevel.AutoSize = true;
			this.lblAudioLevel.Location = new System.Drawing.Point(8, 106);
			this.lblAudioLevel.Name = "lblAudioLevel";
			this.lblAudioLevel.Size = new System.Drawing.Size(66, 13);
			this.lblAudioLevel.TabIndex = 2;
			this.lblAudioLevel.Text = "Audio Level:";
			// 
			// pbAudioLevel
			// 
			this.pbAudioLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbAudioLevel.Location = new System.Drawing.Point(80, 106);
			this.pbAudioLevel.Name = "pbAudioLevel";
			this.pbAudioLevel.Size = new System.Drawing.Size(386, 13);
			this.pbAudioLevel.TabIndex = 1;
			// 
			// txtConsole
			// 
			this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsole.Location = new System.Drawing.Point(12, 388);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConsole.Size = new System.Drawing.Size(476, 101);
			this.txtConsole.TabIndex = 0;
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblServerStarted,
            this.lblClientConnected,
            this.lblCurrentAddres,
            this.lblCurrentInputPort,
            this.lblCurrentOutputPort});
			this.statusBar.Location = new System.Drawing.Point(0, 492);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(500, 22);
			this.statusBar.TabIndex = 8;
			this.statusBar.Text = "statusStrip1";
			// 
			// lblServerStarted
			// 
			this.lblServerStarted.Name = "lblServerStarted";
			this.lblServerStarted.Size = new System.Drawing.Size(79, 17);
			this.lblServerStarted.Text = "Server Started";
			this.lblServerStarted.Visible = false;
			// 
			// lblClientConnected
			// 
			this.lblClientConnected.Name = "lblClientConnected";
			this.lblClientConnected.Size = new System.Drawing.Size(105, 17);
			this.lblClientConnected.Text = "Client Conncected";
			this.lblClientConnected.Visible = false;
			// 
			// lblCurrentAddres
			// 
			this.lblCurrentAddres.Name = "lblCurrentAddres";
			this.lblCurrentAddres.Size = new System.Drawing.Size(88, 17);
			this.lblCurrentAddres.Text = "255.255.255.255";
			this.lblCurrentAddres.Visible = false;
			// 
			// lblCurrentInputPort
			// 
			this.lblCurrentInputPort.Name = "lblCurrentInputPort";
			this.lblCurrentInputPort.Size = new System.Drawing.Size(96, 17);
			this.lblCurrentInputPort.Text = "Input Port: 65536";
			this.lblCurrentInputPort.Visible = false;
			// 
			// lblCurrentOutputPort
			// 
			this.lblCurrentOutputPort.Name = "lblCurrentOutputPort";
			this.lblCurrentOutputPort.Size = new System.Drawing.Size(106, 17);
			this.lblCurrentOutputPort.Text = "Output Port: 65536";
			this.lblCurrentOutputPort.Visible = false;
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = "Grammar Files|*.xml|All Files|*.*";
			// 
			// chkFreeDictation
			// 
			this.chkFreeDictation.AutoSize = true;
			this.chkFreeDictation.Location = new System.Drawing.Point(82, 78);
			this.chkFreeDictation.Name = "chkFreeDictation";
			this.chkFreeDictation.Size = new System.Drawing.Size(90, 17);
			this.chkFreeDictation.TabIndex = 8;
			this.chkFreeDictation.Text = "Free dictation";
			this.chkFreeDictation.UseVisualStyleBackColor = true;
			this.chkFreeDictation.CheckedChanged += new System.EventHandler(this.chkFreeDictation_CheckedChanged);
			// 
			// FrmSpRec
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 514);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.gbSpeechRecognized);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.gbSettings);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "FrmSpRec";
			this.Text = "SP-REC 3.0 - Speech Recognition";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSpRec_FormClosed);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSpRec_KeyUp);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSpRec_KeyDown);
			this.gbHypothesys.ResumeLayout(false);
			this.gbHypothesys.PerformLayout();
			this.gbRejected.ResumeLayout(false);
			this.gbRejected.PerformLayout();
			this.gbSettings.ResumeLayout(false);
			this.gbSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudVolumeTreshold)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.gbSpeechRecognized.ResumeLayout(false);
			this.gbSpeechRecognized.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtRecognizedText;
		private System.Windows.Forms.TextBox txtHypothesis;
		private System.Windows.Forms.TextBox txtRejected;
		private System.Windows.Forms.GroupBox gbHypothesys;
		private System.Windows.Forms.GroupBox gbRejected;
		private System.Windows.Forms.GroupBox gbSettings;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label lblGrammar;
		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.TextBox txtGrammarFile;
		private System.Windows.Forms.Button btnLoadGrammar;
		private System.Windows.Forms.GroupBox gbSpeechRecognized;
		private System.Windows.Forms.TextBox txtConsole;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel lblServerStarted;
		private System.Windows.Forms.ToolStripStatusLabel lblClientConnected;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentAddres;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentInputPort;
		private System.Windows.Forms.ToolStripStatusLabel lblCurrentOutputPort;
		private System.Windows.Forms.Button btnExploreGrammar;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.Label lblAudioLevel;
		private System.Windows.Forms.ProgressBar pbAudioLevel;
		private System.Windows.Forms.ComboBox cmbProfiles;
		private System.Windows.Forms.Label lblProfile;
		private System.Windows.Forms.CheckBox chkSendRejected;
		private System.Windows.Forms.Label lblVolumeTreshold;
		private System.Windows.Forms.NumericUpDown nudVolumeTreshold;
		private System.Windows.Forms.CheckBox chkFreeDictation;
	}
}

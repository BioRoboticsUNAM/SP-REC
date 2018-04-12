namespace SpRec
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpRec));
			this.txtRecognizedText = new System.Windows.Forms.TextBox();
			this.txtHypothesis = new System.Windows.Forms.TextBox();
			this.txtRejected = new System.Windows.Forms.TextBox();
			this.gbHypothesys = new System.Windows.Forms.GroupBox();
			this.gbRejected = new System.Windows.Forms.GroupBox();
			this.chkSendRejected = new System.Windows.Forms.CheckBox();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.chkFreeDictation = new System.Windows.Forms.CheckBox();
			this.lblMaxAlternates = new System.Windows.Forms.Label();
			this.lblVolumeTreshold = new System.Windows.Forms.Label();
			this.nudMaxAlternates = new System.Windows.Forms.NumericUpDown();
			this.nudVolumeTreshold = new System.Windows.Forms.NumericUpDown();
			this.cmbProfiles = new System.Windows.Forms.ComboBox();
			this.btnExploreGrammar = new System.Windows.Forms.Button();
			this.btnLoadGrammar = new System.Windows.Forms.Button();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.txtGrammarFile = new System.Windows.Forms.TextBox();
			this.lblProfile = new System.Windows.Forms.Label();
			this.lblGrammar = new System.Windows.Forms.Label();
			this.slpHypothesisRejected = new System.Windows.Forms.SplitContainer();
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
			this.gbAutoSave = new System.Windows.Forms.GroupBox();
			this.rbAutoSaveAll = new System.Windows.Forms.RadioButton();
			this.rbAutoSaveRejectedOnly = new System.Windows.Forms.RadioButton();
			this.rbAutoSaveRecognizedOnly = new System.Windows.Forms.RadioButton();
			this.rbAutoSaveNone = new System.Windows.Forms.RadioButton();
			this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
			this.miGrammar = new System.Windows.Forms.ToolStripMenuItem();
			this.miGrammar_Load = new System.Windows.Forms.ToolStripMenuItem();
			this.miGrammar_Reload = new System.Windows.Forms.ToolStripMenuItem();
			this.miView = new System.Windows.Forms.ToolStripMenuItem();
			this.miView_Autosave = new System.Windows.Forms.ToolStripMenuItem();
			this.miView_SilenceTimeouts = new System.Windows.Forms.ToolStripMenuItem();
			this.miView_HypothesisRejected = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.miView_AppendRecognitionHistoryMode = new System.Windows.Forms.ToolStripMenuItem();
			this.gbSilenceTimeouts = new System.Windows.Forms.GroupBox();
			this.nudEndSilenceTimeoutAmbiguous = new System.Windows.Forms.NumericUpDown();
			this.nudEndSilenceTimeout = new System.Windows.Forms.NumericUpDown();
			this.nudInitialSilenceTimeout = new System.Windows.Forms.NumericUpDown();
			this.lblEndSilenceTimeout = new System.Windows.Forms.Label();
			this.lblEndSilenceTimeoutAmbiguous = new System.Windows.Forms.Label();
			this.lblInitialSilenceTimeout = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.gbHypothesys.SuspendLayout();
			this.gbRejected.SuspendLayout();
			this.gbSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxAlternates)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudVolumeTreshold)).BeginInit();
			this.slpHypothesisRejected.Panel1.SuspendLayout();
			this.slpHypothesisRejected.Panel2.SuspendLayout();
			this.slpHypothesisRejected.SuspendLayout();
			this.gbSpeechRecognized.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.gbAutoSave.SuspendLayout();
			this.mnuMainMenu.SuspendLayout();
			this.gbSilenceTimeouts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSilenceTimeoutAmbiguous)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSilenceTimeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInitialSilenceTimeout)).BeginInit();
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
			this.txtRecognizedText.Size = new System.Drawing.Size(460, 88);
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
			this.txtHypothesis.Size = new System.Drawing.Size(223, 71);
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
			this.txtRejected.Size = new System.Drawing.Size(213, 49);
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
			this.gbHypothesys.Size = new System.Drawing.Size(235, 97);
			this.gbHypothesys.TabIndex = 3;
			this.gbHypothesys.TabStop = false;
			this.gbHypothesys.Text = "Hypothesis:";
			// 
			// gbRejected
			// 
			this.gbRejected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbRejected.Controls.Add(this.txtRejected);
			this.gbRejected.Controls.Add(this.chkSendRejected);
			this.gbRejected.Location = new System.Drawing.Point(3, 3);
			this.gbRejected.Name = "gbRejected";
			this.gbRejected.Size = new System.Drawing.Size(225, 97);
			this.gbRejected.TabIndex = 4;
			this.gbRejected.TabStop = false;
			this.gbRejected.Text = "Rejected:";
			// 
			// chkSendRejected
			// 
			this.chkSendRejected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkSendRejected.AutoSize = true;
			this.chkSendRejected.Enabled = false;
			this.chkSendRejected.Location = new System.Drawing.Point(6, 74);
			this.chkSendRejected.Name = "chkSendRejected";
			this.chkSendRejected.Size = new System.Drawing.Size(97, 17);
			this.chkSendRejected.TabIndex = 2;
			this.chkSendRejected.Text = "Send Rejected";
			this.chkSendRejected.UseVisualStyleBackColor = true;
			this.chkSendRejected.CheckedChanged += new System.EventHandler(this.chkSendRejected_CheckedChanged);
			// 
			// gbSettings
			// 
			this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSettings.Controls.Add(this.chkFreeDictation);
			this.gbSettings.Controls.Add(this.lblMaxAlternates);
			this.gbSettings.Controls.Add(this.lblVolumeTreshold);
			this.gbSettings.Controls.Add(this.nudMaxAlternates);
			this.gbSettings.Controls.Add(this.nudVolumeTreshold);
			this.gbSettings.Controls.Add(this.cmbProfiles);
			this.gbSettings.Controls.Add(this.btnExploreGrammar);
			this.gbSettings.Controls.Add(this.btnLoadGrammar);
			this.gbSettings.Controls.Add(this.chkEnable);
			this.gbSettings.Controls.Add(this.txtGrammarFile);
			this.gbSettings.Controls.Add(this.lblProfile);
			this.gbSettings.Controls.Add(this.lblGrammar);
			this.gbSettings.Location = new System.Drawing.Point(9, 27);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(476, 104);
			this.gbSettings.TabIndex = 5;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Settings:";
			// 
			// chkFreeDictation
			// 
			this.chkFreeDictation.AutoSize = true;
			this.chkFreeDictation.Location = new System.Drawing.Point(82, 76);
			this.chkFreeDictation.Name = "chkFreeDictation";
			this.chkFreeDictation.Size = new System.Drawing.Size(90, 17);
			this.chkFreeDictation.TabIndex = 8;
			this.chkFreeDictation.Text = "Free dictation";
			this.chkFreeDictation.UseVisualStyleBackColor = true;
			this.chkFreeDictation.CheckedChanged += new System.EventHandler(this.chkFreeDictation_CheckedChanged);
			// 
			// lblMaxAlternates
			// 
			this.lblMaxAlternates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaxAlternates.AutoSize = true;
			this.lblMaxAlternates.Location = new System.Drawing.Point(333, 77);
			this.lblMaxAlternates.Name = "lblMaxAlternates";
			this.lblMaxAlternates.Size = new System.Drawing.Size(79, 13);
			this.lblMaxAlternates.TabIndex = 7;
			this.lblMaxAlternates.Text = "Max alternates:";
			this.toolTip.SetToolTip(this.lblMaxAlternates, "Maximum number of alternate recognition results to generate for each recognition " +
					"operation.");
			// 
			// lblVolumeTreshold
			// 
			this.lblVolumeTreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVolumeTreshold.AutoSize = true;
			this.lblVolumeTreshold.Location = new System.Drawing.Point(323, 52);
			this.lblVolumeTreshold.Name = "lblVolumeTreshold";
			this.lblVolumeTreshold.Size = new System.Drawing.Size(89, 13);
			this.lblVolumeTreshold.TabIndex = 7;
			this.lblVolumeTreshold.Text = "Volume Treshold:";
			// 
			// nudMaxAlternates
			// 
			this.nudMaxAlternates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudMaxAlternates.Location = new System.Drawing.Point(418, 75);
			this.nudMaxAlternates.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudMaxAlternates.Name = "nudMaxAlternates";
			this.nudMaxAlternates.Size = new System.Drawing.Size(52, 20);
			this.nudMaxAlternates.TabIndex = 6;
			this.toolTip.SetToolTip(this.nudMaxAlternates, "Maximum number of alternate recognition results to generate for each recognition " +
					"operation.");
			this.nudMaxAlternates.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudMaxAlternates.ValueChanged += new System.EventHandler(this.nudMaxAlternates_ValueChanged);
			// 
			// nudVolumeTreshold
			// 
			this.nudVolumeTreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudVolumeTreshold.Location = new System.Drawing.Point(418, 50);
			this.nudVolumeTreshold.Name = "nudVolumeTreshold";
			this.nudVolumeTreshold.Size = new System.Drawing.Size(52, 20);
			this.nudVolumeTreshold.TabIndex = 6;
			this.nudVolumeTreshold.ValueChanged += new System.EventHandler(this.nudVolumeTreshold_ValueChanged);
			// 
			// cmbProfiles
			// 
			this.cmbProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbProfiles.FormattingEnabled = true;
			this.cmbProfiles.Location = new System.Drawing.Point(66, 49);
			this.cmbProfiles.Name = "cmbProfiles";
			this.cmbProfiles.Size = new System.Drawing.Size(251, 21);
			this.cmbProfiles.TabIndex = 5;
			this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbProfiles_SelectedIndexChanged);
			// 
			// btnExploreGrammar
			// 
			this.btnExploreGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExploreGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExploreGrammar.Image = global::SpRec.Properties.Resources.ZoomHS;
			this.btnExploreGrammar.Location = new System.Drawing.Point(418, 18);
			this.btnExploreGrammar.Name = "btnExploreGrammar";
			this.btnExploreGrammar.Size = new System.Drawing.Size(23, 23);
			this.btnExploreGrammar.TabIndex = 4;
			this.btnExploreGrammar.UseVisualStyleBackColor = true;
			this.btnExploreGrammar.Click += new System.EventHandler(this.btnExploreGrammar_Click);
			// 
			// btnLoadGrammar
			// 
			this.btnLoadGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadGrammar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLoadGrammar.Image = global::SpRec.Properties.Resources.openHS;
			this.btnLoadGrammar.Location = new System.Drawing.Point(447, 18);
			this.btnLoadGrammar.Name = "btnLoadGrammar";
			this.btnLoadGrammar.Size = new System.Drawing.Size(23, 23);
			this.btnLoadGrammar.TabIndex = 3;
			this.toolTip.SetToolTip(this.btnLoadGrammar, "Lorad / reload the current grammar file");
			this.btnLoadGrammar.UseVisualStyleBackColor = true;
			this.btnLoadGrammar.Click += new System.EventHandler(this.btnLoadGrammar_Click);
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(11, 76);
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
			this.txtGrammarFile.Size = new System.Drawing.Size(346, 20);
			this.txtGrammarFile.TabIndex = 1;
			// 
			// lblProfile
			// 
			this.lblProfile.AutoSize = true;
			this.lblProfile.Location = new System.Drawing.Point(8, 52);
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
			// slpHypothesisRejected
			// 
			this.slpHypothesisRejected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.slpHypothesisRejected.Location = new System.Drawing.Point(12, 239);
			this.slpHypothesisRejected.Name = "slpHypothesisRejected";
			// 
			// slpHypothesisRejected.Panel1
			// 
			this.slpHypothesisRejected.Panel1.Controls.Add(this.gbHypothesys);
			// 
			// slpHypothesisRejected.Panel2
			// 
			this.slpHypothesisRejected.Panel2.Controls.Add(this.gbRejected);
			this.slpHypothesisRejected.Size = new System.Drawing.Size(476, 103);
			this.slpHypothesisRejected.SplitterDistance = 241;
			this.slpHypothesisRejected.TabIndex = 6;
			// 
			// gbSpeechRecognized
			// 
			this.gbSpeechRecognized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSpeechRecognized.Controls.Add(this.lblAudioLevel);
			this.gbSpeechRecognized.Controls.Add(this.pbAudioLevel);
			this.gbSpeechRecognized.Controls.Add(this.txtRecognizedText);
			this.gbSpeechRecognized.Location = new System.Drawing.Point(12, 348);
			this.gbSpeechRecognized.Name = "gbSpeechRecognized";
			this.gbSpeechRecognized.Size = new System.Drawing.Size(476, 132);
			this.gbSpeechRecognized.TabIndex = 7;
			this.gbSpeechRecognized.TabStop = false;
			this.gbSpeechRecognized.Text = "Speech Recognized";
			// 
			// lblAudioLevel
			// 
			this.lblAudioLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblAudioLevel.AutoSize = true;
			this.lblAudioLevel.Location = new System.Drawing.Point(8, 113);
			this.lblAudioLevel.Name = "lblAudioLevel";
			this.lblAudioLevel.Size = new System.Drawing.Size(66, 13);
			this.lblAudioLevel.TabIndex = 2;
			this.lblAudioLevel.Text = "Audio Level:";
			// 
			// pbAudioLevel
			// 
			this.pbAudioLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pbAudioLevel.Location = new System.Drawing.Point(80, 113);
			this.pbAudioLevel.Name = "pbAudioLevel";
			this.pbAudioLevel.Size = new System.Drawing.Size(386, 13);
			this.pbAudioLevel.TabIndex = 1;
			// 
			// txtConsole
			// 
			this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsole.Location = new System.Drawing.Point(12, 486);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConsole.Size = new System.Drawing.Size(476, 65);
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
			this.statusBar.Location = new System.Drawing.Point(0, 554);
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
			// gbAutoSave
			// 
			this.gbAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbAutoSave.Controls.Add(this.rbAutoSaveAll);
			this.gbAutoSave.Controls.Add(this.rbAutoSaveRejectedOnly);
			this.gbAutoSave.Controls.Add(this.rbAutoSaveRecognizedOnly);
			this.gbAutoSave.Controls.Add(this.rbAutoSaveNone);
			this.gbAutoSave.Location = new System.Drawing.Point(12, 188);
			this.gbAutoSave.Name = "gbAutoSave";
			this.gbAutoSave.Size = new System.Drawing.Size(476, 45);
			this.gbAutoSave.TabIndex = 9;
			this.gbAutoSave.TabStop = false;
			this.gbAutoSave.Text = "Autosave";
			// 
			// rbAutoSaveAll
			// 
			this.rbAutoSaveAll.AutoSize = true;
			this.rbAutoSaveAll.Location = new System.Drawing.Point(272, 19);
			this.rbAutoSaveAll.Name = "rbAutoSaveAll";
			this.rbAutoSaveAll.Size = new System.Drawing.Size(159, 17);
			this.rbAutoSaveAll.TabIndex = 0;
			this.rbAutoSaveAll.TabStop = true;
			this.rbAutoSaveAll.Text = "All (rejected and recognized)";
			this.rbAutoSaveAll.UseVisualStyleBackColor = true;
			this.rbAutoSaveAll.CheckedChanged += new System.EventHandler(this.rbAutoSave_CheckedChanged);
			// 
			// rbAutoSaveRejectedOnly
			// 
			this.rbAutoSaveRejectedOnly.AutoSize = true;
			this.rbAutoSaveRejectedOnly.Location = new System.Drawing.Point(176, 19);
			this.rbAutoSaveRejectedOnly.Name = "rbAutoSaveRejectedOnly";
			this.rbAutoSaveRejectedOnly.Size = new System.Drawing.Size(90, 17);
			this.rbAutoSaveRejectedOnly.TabIndex = 0;
			this.rbAutoSaveRejectedOnly.TabStop = true;
			this.rbAutoSaveRejectedOnly.Text = "Rejected only";
			this.rbAutoSaveRejectedOnly.UseVisualStyleBackColor = true;
			this.rbAutoSaveRejectedOnly.CheckedChanged += new System.EventHandler(this.rbAutoSave_CheckedChanged);
			// 
			// rbAutoSaveRecognizedOnly
			// 
			this.rbAutoSaveRecognizedOnly.AutoSize = true;
			this.rbAutoSaveRecognizedOnly.Location = new System.Drawing.Point(66, 19);
			this.rbAutoSaveRecognizedOnly.Name = "rbAutoSaveRecognizedOnly";
			this.rbAutoSaveRecognizedOnly.Size = new System.Drawing.Size(104, 17);
			this.rbAutoSaveRecognizedOnly.TabIndex = 0;
			this.rbAutoSaveRecognizedOnly.TabStop = true;
			this.rbAutoSaveRecognizedOnly.Text = "Recognized only";
			this.rbAutoSaveRecognizedOnly.UseVisualStyleBackColor = true;
			this.rbAutoSaveRecognizedOnly.CheckedChanged += new System.EventHandler(this.rbAutoSave_CheckedChanged);
			// 
			// rbAutoSaveNone
			// 
			this.rbAutoSaveNone.AutoSize = true;
			this.rbAutoSaveNone.Location = new System.Drawing.Point(6, 19);
			this.rbAutoSaveNone.Name = "rbAutoSaveNone";
			this.rbAutoSaveNone.Size = new System.Drawing.Size(51, 17);
			this.rbAutoSaveNone.TabIndex = 0;
			this.rbAutoSaveNone.TabStop = true;
			this.rbAutoSaveNone.Text = "None";
			this.rbAutoSaveNone.UseVisualStyleBackColor = true;
			this.rbAutoSaveNone.CheckedChanged += new System.EventHandler(this.rbAutoSave_CheckedChanged);
			// 
			// mnuMainMenu
			// 
			this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGrammar,
            this.miView});
			this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
			this.mnuMainMenu.Name = "mnuMainMenu";
			this.mnuMainMenu.Size = new System.Drawing.Size(500, 24);
			this.mnuMainMenu.TabIndex = 10;
			this.mnuMainMenu.Text = "Main Menu";
			// 
			// miGrammar
			// 
			this.miGrammar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGrammar_Load,
            this.miGrammar_Reload});
			this.miGrammar.Name = "miGrammar";
			this.miGrammar.Size = new System.Drawing.Size(69, 20);
			this.miGrammar.Text = "&Grammar";
			// 
			// miGrammar_Load
			// 
			this.miGrammar_Load.Name = "miGrammar_Load";
			this.miGrammar_Load.Size = new System.Drawing.Size(162, 22);
			this.miGrammar_Load.Text = "&Load grammar";
			this.miGrammar_Load.Click += new System.EventHandler(this.miGrammar_Load_Click);
			// 
			// miGrammar_Reload
			// 
			this.miGrammar_Reload.Name = "miGrammar_Reload";
			this.miGrammar_Reload.Size = new System.Drawing.Size(162, 22);
			this.miGrammar_Reload.Text = "&Reload grammar";
			this.miGrammar_Reload.Click += new System.EventHandler(this.miGrammar_Reload_Click);
			// 
			// miView
			// 
			this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miView_Autosave,
            this.miView_SilenceTimeouts,
            this.miView_HypothesisRejected,
            this.toolStripMenuItem1,
            this.miView_AppendRecognitionHistoryMode});
			this.miView.Name = "miView";
			this.miView.Size = new System.Drawing.Size(44, 20);
			this.miView.Text = "&View";
			// 
			// miView_Autosave
			// 
			this.miView_Autosave.Checked = true;
			this.miView_Autosave.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miView_Autosave.Name = "miView_Autosave";
			this.miView_Autosave.Size = new System.Drawing.Size(239, 22);
			this.miView_Autosave.Text = "&Autosave pannel";
			this.miView_Autosave.Click += new System.EventHandler(this.miView_Autosave_Click);
			// 
			// miView_SilenceTimeouts
			// 
			this.miView_SilenceTimeouts.Checked = true;
			this.miView_SilenceTimeouts.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miView_SilenceTimeouts.Name = "miView_SilenceTimeouts";
			this.miView_SilenceTimeouts.Size = new System.Drawing.Size(239, 22);
			this.miView_SilenceTimeouts.Text = "&Silence timeouts pannel";
			this.miView_SilenceTimeouts.Click += new System.EventHandler(this.miView_SilenceTimeouts_Click);
			// 
			// miView_HypothesisRejected
			// 
			this.miView_HypothesisRejected.Checked = true;
			this.miView_HypothesisRejected.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miView_HypothesisRejected.Name = "miView_HypothesisRejected";
			this.miView_HypothesisRejected.Size = new System.Drawing.Size(239, 22);
			this.miView_HypothesisRejected.Text = "Hypothesis/rejected pannel";
			this.miView_HypothesisRejected.Click += new System.EventHandler(this.miView_HypothesisRejected_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(236, 6);
			// 
			// miView_AppendRecognitionHistoryMode
			// 
			this.miView_AppendRecognitionHistoryMode.Checked = true;
			this.miView_AppendRecognitionHistoryMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.miView_AppendRecognitionHistoryMode.Name = "miView_AppendRecognitionHistoryMode";
			this.miView_AppendRecognitionHistoryMode.Size = new System.Drawing.Size(239, 22);
			this.miView_AppendRecognitionHistoryMode.Text = "Append recognition history &log";
			this.miView_AppendRecognitionHistoryMode.Click += new System.EventHandler(this.miView_AppendRecognitionHistoryMode_Click);
			// 
			// gbSilenceTimeouts
			// 
			this.gbSilenceTimeouts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbSilenceTimeouts.Controls.Add(this.nudEndSilenceTimeoutAmbiguous);
			this.gbSilenceTimeouts.Controls.Add(this.nudEndSilenceTimeout);
			this.gbSilenceTimeouts.Controls.Add(this.nudInitialSilenceTimeout);
			this.gbSilenceTimeouts.Controls.Add(this.lblEndSilenceTimeout);
			this.gbSilenceTimeouts.Controls.Add(this.lblEndSilenceTimeoutAmbiguous);
			this.gbSilenceTimeouts.Controls.Add(this.lblInitialSilenceTimeout);
			this.gbSilenceTimeouts.Location = new System.Drawing.Point(12, 137);
			this.gbSilenceTimeouts.Name = "gbSilenceTimeouts";
			this.gbSilenceTimeouts.Size = new System.Drawing.Size(476, 45);
			this.gbSilenceTimeouts.TabIndex = 11;
			this.gbSilenceTimeouts.TabStop = false;
			this.gbSilenceTimeouts.Text = "Silence timeouts";
			// 
			// nudEndSilenceTimeoutAmbiguous
			// 
			this.nudEndSilenceTimeoutAmbiguous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudEndSilenceTimeoutAmbiguous.DecimalPlaces = 3;
			this.nudEndSilenceTimeoutAmbiguous.Increment = new decimal(new int[] {
            15,
            0,
            0,
            131072});
			this.nudEndSilenceTimeoutAmbiguous.Location = new System.Drawing.Point(306, 19);
			this.nudEndSilenceTimeoutAmbiguous.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudEndSilenceTimeoutAmbiguous.Name = "nudEndSilenceTimeoutAmbiguous";
			this.nudEndSilenceTimeoutAmbiguous.Size = new System.Drawing.Size(60, 20);
			this.nudEndSilenceTimeoutAmbiguous.TabIndex = 6;
			this.nudEndSilenceTimeoutAmbiguous.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.nudEndSilenceTimeoutAmbiguous, resources.GetString("nudEndSilenceTimeoutAmbiguous.ToolTip"));
			this.nudEndSilenceTimeoutAmbiguous.ValueChanged += new System.EventHandler(this.nudEndSilenceTimeoutAmbiguous_ValueChanged);
			// 
			// nudEndSilenceTimeout
			// 
			this.nudEndSilenceTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudEndSilenceTimeout.DecimalPlaces = 3;
			this.nudEndSilenceTimeout.Increment = new decimal(new int[] {
            15,
            0,
            0,
            131072});
			this.nudEndSilenceTimeout.Location = new System.Drawing.Point(410, 19);
			this.nudEndSilenceTimeout.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudEndSilenceTimeout.Name = "nudEndSilenceTimeout";
			this.nudEndSilenceTimeout.Size = new System.Drawing.Size(60, 20);
			this.nudEndSilenceTimeout.TabIndex = 6;
			this.nudEndSilenceTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.nudEndSilenceTimeout, resources.GetString("nudEndSilenceTimeout.ToolTip"));
			this.nudEndSilenceTimeout.ValueChanged += new System.EventHandler(this.nudEndSilenceTimeout_ValueChanged);
			// 
			// nudInitialSilenceTimeout
			// 
			this.nudInitialSilenceTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudInitialSilenceTimeout.DecimalPlaces = 3;
			this.nudInitialSilenceTimeout.Increment = new decimal(new int[] {
            15,
            0,
            0,
            131072});
			this.nudInitialSilenceTimeout.Location = new System.Drawing.Point(142, 19);
			this.nudInitialSilenceTimeout.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudInitialSilenceTimeout.Name = "nudInitialSilenceTimeout";
			this.nudInitialSilenceTimeout.Size = new System.Drawing.Size(60, 20);
			this.nudInitialSilenceTimeout.TabIndex = 6;
			this.nudInitialSilenceTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.nudInitialSilenceTimeout, resources.GetString("nudInitialSilenceTimeout.ToolTip"));
			this.nudInitialSilenceTimeout.ValueChanged += new System.EventHandler(this.nudInitialSilenceTimeout_ValueChanged);
			// 
			// lblEndSilenceTimeout
			// 
			this.lblEndSilenceTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndSilenceTimeout.AutoSize = true;
			this.lblEndSilenceTimeout.Location = new System.Drawing.Point(372, 21);
			this.lblEndSilenceTimeout.Name = "lblEndSilenceTimeout";
			this.lblEndSilenceTimeout.Size = new System.Drawing.Size(32, 13);
			this.lblEndSilenceTimeout.TabIndex = 7;
			this.lblEndSilenceTimeout.Text = "Final:";
			this.toolTip.SetToolTip(this.lblEndSilenceTimeout, resources.GetString("lblEndSilenceTimeout.ToolTip"));
			// 
			// lblEndSilenceTimeoutAmbiguous
			// 
			this.lblEndSilenceTimeoutAmbiguous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndSilenceTimeoutAmbiguous.AutoSize = true;
			this.lblEndSilenceTimeoutAmbiguous.Location = new System.Drawing.Point(208, 21);
			this.lblEndSilenceTimeoutAmbiguous.Name = "lblEndSilenceTimeoutAmbiguous";
			this.lblEndSilenceTimeoutAmbiguous.Size = new System.Drawing.Size(92, 13);
			this.lblEndSilenceTimeoutAmbiguous.TabIndex = 7;
			this.lblEndSilenceTimeoutAmbiguous.Text = "Final (ambiguous):";
			this.toolTip.SetToolTip(this.lblEndSilenceTimeoutAmbiguous, resources.GetString("lblEndSilenceTimeoutAmbiguous.ToolTip"));
			// 
			// lblInitialSilenceTimeout
			// 
			this.lblInitialSilenceTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInitialSilenceTimeout.AutoSize = true;
			this.lblInitialSilenceTimeout.Location = new System.Drawing.Point(102, 21);
			this.lblInitialSilenceTimeout.Name = "lblInitialSilenceTimeout";
			this.lblInitialSilenceTimeout.Size = new System.Drawing.Size(34, 13);
			this.lblInitialSilenceTimeout.TabIndex = 7;
			this.lblInitialSilenceTimeout.Text = "Initial:";
			this.toolTip.SetToolTip(this.lblInitialSilenceTimeout, resources.GetString("lblInitialSilenceTimeout.ToolTip"));
			// 
			// FrmSpRec
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 576);
			this.Controls.Add(this.gbSilenceTimeouts);
			this.Controls.Add(this.gbAutoSave);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.mnuMainMenu);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.gbSpeechRecognized);
			this.Controls.Add(this.slpHypothesisRejected);
			this.Controls.Add(this.gbSettings);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.mnuMainMenu;
			this.Name = "FrmSpRec";
			this.Text = "SP-REC 3.5 - Speech Recognition";
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
			((System.ComponentModel.ISupportInitialize)(this.nudMaxAlternates)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudVolumeTreshold)).EndInit();
			this.slpHypothesisRejected.Panel1.ResumeLayout(false);
			this.slpHypothesisRejected.Panel2.ResumeLayout(false);
			this.slpHypothesisRejected.ResumeLayout(false);
			this.gbSpeechRecognized.ResumeLayout(false);
			this.gbSpeechRecognized.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.gbAutoSave.ResumeLayout(false);
			this.gbAutoSave.PerformLayout();
			this.mnuMainMenu.ResumeLayout(false);
			this.mnuMainMenu.PerformLayout();
			this.gbSilenceTimeouts.ResumeLayout(false);
			this.gbSilenceTimeouts.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSilenceTimeoutAmbiguous)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSilenceTimeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudInitialSilenceTimeout)).EndInit();
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
		private System.Windows.Forms.SplitContainer slpHypothesisRejected;
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
		private System.Windows.Forms.GroupBox gbAutoSave;
		private System.Windows.Forms.RadioButton rbAutoSaveNone;
		private System.Windows.Forms.RadioButton rbAutoSaveRecognizedOnly;
		private System.Windows.Forms.RadioButton rbAutoSaveRejectedOnly;
		private System.Windows.Forms.RadioButton rbAutoSaveAll;
		private System.Windows.Forms.MenuStrip mnuMainMenu;
		private System.Windows.Forms.ToolStripMenuItem miGrammar;
		private System.Windows.Forms.ToolStripMenuItem miView;
		private System.Windows.Forms.ToolStripMenuItem miView_HypothesisRejected;
		private System.Windows.Forms.ToolStripMenuItem miView_AppendRecognitionHistoryMode;
		private System.Windows.Forms.ToolStripMenuItem miGrammar_Load;
		private System.Windows.Forms.ToolStripMenuItem miGrammar_Reload;
		private System.Windows.Forms.Label lblMaxAlternates;
		private System.Windows.Forms.NumericUpDown nudMaxAlternates;
		private System.Windows.Forms.GroupBox gbSilenceTimeouts;
		private System.Windows.Forms.NumericUpDown nudInitialSilenceTimeout;
		private System.Windows.Forms.Label lblInitialSilenceTimeout;
		private System.Windows.Forms.NumericUpDown nudEndSilenceTimeoutAmbiguous;
		private System.Windows.Forms.NumericUpDown nudEndSilenceTimeout;
		private System.Windows.Forms.Label lblEndSilenceTimeout;
		private System.Windows.Forms.Label lblEndSilenceTimeoutAmbiguous;
		private System.Windows.Forms.ToolStripMenuItem miView_Autosave;
		private System.Windows.Forms.ToolStripMenuItem miView_SilenceTimeouts;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolTip toolTip;
	}
}


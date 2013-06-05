using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
//using System.Speech.Recognition;
using System.Threading;
using System.Windows.Forms;
using Robotics.API;
using Robotics.API.MiscSharedVariables;
using Robotics.HAL.Sensors;
using SpRec3.CommandExecuters;
using Timer = System.Threading.Timer;

namespace SpRec3
{
	/// <summary>
	/// Represents the method that will handle an event that receives an string as param 
	/// </summary>
	/// <param name="str">String to pass</param>
	public delegate void StringEventHandler(string str);

	/// <summary>
	/// Represents the method that will handle an event that receives no parameters
	/// </summary>
	public delegate void VoidEventHandler();

	public delegate bool LoadGrammarCaller(string path);

	public partial class FrmSpRec : Form, IMessageSource
	{

		#region Variables

		private SpeechRecognizer reco;
		private string grammarFile;
		private bool sendRejected;
		private int volumeTreshold;
		private int currentRecognitionMaxVolumeLevel;
		private List<ExpectedPhrase> expectedPhraseList;
		private LoadGrammarCaller dlgLoadGrammar;
		private int timerIdCounter;
		private SpeechRecognizedEH dlgSpeechHypothesized;
		private SpeechRecognizedEH dlgSpeechRecognitionRejected;
		private SpeechRecognizedEH dlgSpeechRecognized;
		private AudioLevelChangedEH dlgAudioLevelChanged;
		private SpeechRecognizedStatusChangedEH dlgGrammarLoaded;


		/// <summary>
		/// Stores the module name
		/// </summary>
		protected readonly string MODULE_NAME = "SP-REC";

		/// <summary>
		/// Eventhandler for console update
		/// </summary>
		private StringEventHandler updateConsoleEH;

		/// <summary>
		/// Connection manager
		/// </summary>
		private ConnectionManager cnnMan;

		/// <summary>
		/// Command manager
		/// </summary>
		private CommandManager cmdMan;

		private RecognizedSpeechSharedVariable shRecognizedSpeech;

		#region Socket Variables

		/// <summary>
		/// Stores the IP Address of the sender of the last packet received trough socket server
		/// </summary>
		protected IPAddress senderAddress;
		/// <summary>
		/// IP Address of the remote computer to connect using the socket client
		/// </summary>
		protected IPAddress serverIP;
		/// <summary>
		/// Port for incoming data used by Tcp Server
		/// </summary>
		protected int portIn;
		/// <summary>
		/// Port for outgoing data used by Tcp Client
		/// </summary>
		protected int portOut;
		/// <summary>
		/// Received data trough socket
		/// </summary>
		protected string stringReceived;
		/// <summary>
		/// Async thread timer for socket autoconnections
		/// </summary>
		protected Timer tmrTcpAutoConnect;



		#endregion

		#endregion

		#region Constructors

		public FrmSpRec()
		{
			InitializeComponent();
			this.Icon = Properties.Resources.MicRed;

			dlgSpeechHypothesized = new SpeechRecognizedEH(reco_SpeechHypothesized);
			dlgSpeechRecognitionRejected = new SpeechRecognizedEH(reco_SpeechRecognitionRejected);
			dlgSpeechRecognized = new SpeechRecognizedEH(reco_SpeechRecognized);
			dlgAudioLevelChanged = new AudioLevelChangedEH(reco_AudioLevelChanged);
			dlgGrammarLoaded = new SpeechRecognizedStatusChangedEH(reco_GrammarLoaded);
			dlgLoadGrammar = new LoadGrammarCaller(LoadGrammar);

			if (System.Environment.OSVersion.Version.Major < 6)
			{
				reco = new SpeechRecognizer51();
				if (!System.IO.File.Exists(Application.StartupPath + "\\Interop.SpeechLib.dll"))
				{
					MessageBox.Show("Could not find Interop.SpeechLib.dll\r\npplication will exit", "SP-REC", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Application.Exit();
					return;
				}
			}
			else
				reco = new SpeechRecognizer53();
			reco.SpeechRecognized += dlgSpeechRecognized;
			reco.SpeechRecognitionRejected += dlgSpeechRecognitionRejected;
			reco.SpeechHypothesized += dlgSpeechHypothesized;
			reco.GrammarLoaded += dlgGrammarLoaded;
			reco.StatusChanged += new SpeechRecognizedStatusChangedEH(reco_StatusChanged);
			reco.AudioLevelChanged += dlgAudioLevelChanged;

			string[] profiles = reco.Profiles;
			foreach (string profileName in profiles)
				cmbProfiles.Items.Add(profileName);
			cmbProfiles.SelectedItem = reco.SelectedProfile;
			volumeTreshold = 0;
			currentRecognitionMaxVolumeLevel = 0;
			expectedPhraseList = new List<ExpectedPhrase>();
			updateConsoleEH = new StringEventHandler(Console);

			cmdMan = new CommandManager();
			cnnMan = new ConnectionManager(MODULE_NAME, 2020, cmdMan);

			cnnMan.ClientConnected += new TcpClientConnectedEventHandler(cnnMan_ClientConnected);
			cnnMan.ClientDisconnected += new TcpClientDisconnectedEventHandler(cnnMan_ClientDisconnected);
			cnnMan.Connected += new TcpClientConnectedEventHandler(cnnMan_Connected);
			cnnMan.Disconnected += new TcpClientDisconnectedEventHandler(cnnMan_Disconnected);
			cnnMan.DataReceived += new ConnectionManagerDataReceivedEH(cnnMan_DataReceived);

			cmdMan.SharedVariablesLoaded += new SharedVariablesLoadedEventHandler(cmdMan_SharedVariablesLoaded);
			cmdMan.CommandExecuters.Add(new GrammarCommandExecuter(reco));
			cmdMan.CommandExecuters.Add(new StatusCommandExecuter(reco));
			cmdMan.CommandExecuters.Add(new Rec_EnaCommandExecuter(reco));
			cmdMan.CommandExecuters.Add(new WordsCommandExecuter(reco));
			cmdMan.CommandExecuters.Add(new FreeDictationCommandExecuter(reco));

			ControlsEnabled = false;
			nudVolumeTreshold.Value = volumeTreshold;

		}

		#endregion

		#region Properties

		#region Socket related

		/// <summary>
		/// Gets a value indicating if the module is woking in bidirectional mode
		/// </summary>
		public bool Bidirectional
		{
			get { return cnnMan.Bidirectional; }
		}

		/// <summary>
		/// Gets or sets the Tcp port for incoming data used by Tcp Server
		/// </summary>
		public int TcpPortIn
		{
			get { return cnnMan.PortIn; }
			set
			{
				cnnMan.PortIn = value;
				lblCurrentInputPort.Text = "Input port: " + value.ToString();
				lblCurrentInputPort.Visible = true;
			}
		}

		/// <summary>
		/// Gets or sets the Tcp port for outgoing data used by Tcp Client
		/// </summary>
		public int TcpPortOut
		{
			get { return cnnMan.PortOut; }
			set
			{
				cnnMan.PortOut = value;
				lblCurrentOutputPort.Text = "Output port: " + value.ToString();
				lblCurrentOutputPort.Visible = true;
			}
		}

		/// <summary>
		/// Gets or sets the IP Address of the remote computer to connect using the socket client
		/// </summary>
		public IPAddress TcpServerAddress
		{
			get { return cnnMan.TcpServerAddress; }
			set
			{
				cnnMan.TcpServerAddress = value;
				lblCurrentAddres.Text = "Server Address: " + value.ToString();
				lblCurrentAddres.Visible = true;
			}
		}

		#endregion

		public bool SendRejected
		{
			get { return sendRejected; }
			set
			{
				if (sendRejected == value)
					return;
				sendRejected = value;
				try
				{
					if (this.InvokeRequired)
					{
						if (this.Disposing || this.IsDisposed || !this.IsHandleCreated) return;
						this.Invoke(new VoidEventHandler(delegate() { chkSendRejected.Checked = value; }));
					}
					chkSendRejected.Checked = value;
				}
				catch { }
			}
		}

		private bool ControlsEnabled
		{
			get
			{
				return gbHypothesys.Enabled &&
				gbRejected.Enabled &&
				gbSpeechRecognized.Enabled &&
				txtRejected.Enabled &&
				chkFreeDictation.Enabled &&
				chkEnable.Enabled;
			}
			set
			{
				gbHypothesys.Enabled = value;
				gbRejected.Enabled = value;
				gbSpeechRecognized.Enabled = value;
				txtRejected.Enabled = value;
				chkEnable.Enabled = value;
				chkFreeDictation.Enabled = value;
				chkSendRejected.Enabled = value;
			}
		}

		public string GrammarFile
		{
			get { return grammarFile; }
			set
			{
				if (grammarFile == value) return;
				grammarFile = value;
				if (this.InvokeRequired)
				{
					if (!this.IsHandleCreated || this.Disposing || this.IsDisposed) return;
					this.BeginInvoke(new VoidEventHandler(delegate() { txtGrammarFile.Text = value; }));
				}
				else txtGrammarFile.Text = value;
			}
		}

		public bool RecognitionEnabled
		{
			get
			{
				return reco.Enabled;
			}
			set
			{
				if (reco.Enabled == value) return;
				try
				{
					reco.Enabled = value;
				}
				catch (InvalidOperationException) { MessageBox.Show("No microphone attached to default audio device was detected", "SP-REC", MessageBoxButtons.OK, MessageBoxIcon.Error); }
				catch
				{
					MessageBox.Show("Unknown error", "SP-REC", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (reco.Enabled)
					Console("Recognition enabled");
				else
					Console("Recognition disabled");
				try
				{
					if (this.InvokeRequired)
					{
						if (!this.IsHandleCreated || this.IsDisposed || this.Disposing) return;
						Invoke(new VoidEventHandler(delegate() { chkEnable.Checked = value; }));
						return;
					}
					chkEnable.Checked = reco.Enabled;
				}
				catch { }
			}
		}

		public SpeechRecognizer Reco
		{
			get { return this.reco; }
		}

		#endregion

		#region Methods

		public void AddToExpectedPhraseList(string[] words, int timeOut)
		{
			Timer expectedPhraseTimer = new Timer(new TimerCallback(expectedPhraseTimer_Elapsed), timerIdCounter, timeOut, -1);
			Array.Sort(words, StringComparer.OrdinalIgnoreCase);
			lock (expectedPhraseList)
			{
				for (int i = 0; i < words.Length; ++i)
				{
					words[i] = words[i].Trim();
					if (words[i].Length < 1)
						continue;
					if ((i > 0) && words[i].Equals(words[i - 1], StringComparison.OrdinalIgnoreCase))
						continue;
					expectedPhraseList.Add(new ExpectedPhrase(words[i], expectedPhraseTimer, timerIdCounter));
				}
			}
			expectedPhraseTimer.Change(timeOut, -1);
			unchecked { ++timerIdCounter; }
		}

		/// <summary>
		/// Appends text to the console
		/// </summary>
		/// <param name="text">Text to append</param>
		protected void Console(string text)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.IsDisposed || this.Disposing)
					return;
				this.BeginInvoke(updateConsoleEH, new object[] { text });
				return;
			}
			txtConsole.AppendText(text + "\r\n");
		}

		public bool LoadGrammar(string path)
		{
			if (!System.IO.File.Exists(path))
				return false;
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return false;
				return (bool)this.Invoke(dlgLoadGrammar, path);
			}

			txtGrammarFile.Text = path;
			RecognitionEnabled = false;
			cmdMan.Ready = false;
			if (reco.LoadGrammar(txtGrammarFile.Text))
			{
				Console("Grammar Loaded");
				ControlsEnabled = true;
				RecognitionEnabled = true;
				cmdMan.Ready = true;
				return true;
			}
			else
			{
				Console("Can't load grammar");
				ControlsEnabled = false;
				return false;
			}
		}

		private void LoadGrammar()
		{
			cmdMan.Ready = false;
			RecognitionEnabled = false;
			reco.LoadGrammar(txtGrammarFile.Text);
			/*
			if (reco.LoadGrammar(txtGrammarFile.Text))
			{
				Console("Grammar Loaded");
				ControlsEnabled = true;
				cmdMan.Ready = true;
				//RecognitionEnabled = true;
			}
			else
			{
				Console("Can't load grammar");
				ControlsEnabled = false;
				//RecognitionEnabled = false;
			}
			*/
		}

		private bool MatchExpectedWords(string text)
		{
			int i = 0;
			int timerId = -1;
			Timer timer = null;
			bool flag = false;

			lock (expectedPhraseList)
			{
				for (i = 0; i < expectedPhraseList.Count; ++i)
				{
					if (text.ToLower().Contains(expectedPhraseList[i].Phrase))
					{
						flag = true;
						timerId = expectedPhraseList[i].TimerId;
						timer = expectedPhraseList[i].Timer;
						break;
					}
				}
			}
			if (flag)
			{
				expectedPhraseTimer_Elapsed(timerId);
				timer.Dispose();
			}
			return flag;
		}

		private void SendRecognizedText(RecognizedSpeech recognizedSpeech)
		{
			if (!RecognitionEnabled || (recognizedSpeech.Count < 1))
				return;

			string text = recognizedSpeech[0].Text;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			Command cmd = new Command(this, "recognized", text, cmdMan.AutoId);
			cnnMan.Send(cmd);
			for(int i = 0; i < recognizedSpeech.Count; ++i)
			{
				sb.Append("\\\"");
				sb.Append(recognizedSpeech[i].Text);
				sb.Append("\\\" ");
				sb.Append(recognizedSpeech[i].Confidence.ToString("0.00"));
				if(i != (recognizedSpeech.Count -1))
					sb.Append(' ');
			}			
			if((this.shRecognizedSpeech != null) && this.shRecognizedSpeech.TryWrite(recognizedSpeech))
				Console("Shared variable written");
			cmd = new Command(this, "recognizedSpeech", sb.ToString(), cmdMan.AutoId);
			cnnMan.Send(cmd);
			Console("Sent: " + cmd.StringToSend);

			/*
			if ((cnnMan.ConnectedClientsCount < 1) && !cnnMan.IsConnected)
				return;
			if (!cmdMan.SharedVariables.Contains("recognized_speech"))
				cmdMan.SharedVariables.Add(new StringSharedVariable("recognized_speech"));
			if (cmdMan.SharedVariables.Contains("recognized_speech"))
			{
				try
				{
					cmdMan.SharedVariables[""].Write(text);
					Console("Writed variable: recognized_speech");

				}
				catch { }
			}
			*/
		}

		private string GetRecognizedPhraseDisplayText(RecognizedSpeechAlternate alternate)
		{
			return
				alternate.Text +
				" [" +
				(100 * alternate.Confidence).ToString("0.00") +
				"%]\r\n";
		}

		#endregion

		#region IMessageSource Members

		public string ModuleName
		{
			get { return MODULE_NAME; }
		}

		public void ReceiveResponse(Response response)
		{
		}

		#endregion

		#region Connection Manager Event Handlers

		/// <summary>
		/// Manages the Disconnected event of the output socket
		/// </summary>
		/// <param name="ep">Disconnection endpoint</param>
		private void cnnMan_Disconnected(EndPoint ep)
		{
			Console("Client disconnected from " + ep.ToString());
			lblClientConnected.Visible = false;
		}

		/// <summary>
		/// Manages the Connected event of the output socket
		/// </summary>
		/// <param name="s">Socket used for connection</param>
		private void cnnMan_Connected(Socket s)
		{
			Console("Client connected to " + s.RemoteEndPoint.ToString());
			lblClientConnected.Visible = true;
		}

		/// <summary>
		/// Manages the ClientDisconnected event of the input socket
		/// </summary>
		/// <param name="ep">Disconnection endpoint</param>
		private void cnnMan_ClientDisconnected(EndPoint ep)
		{
			try
			{
				Console(ep.ToString() + " disconnected from local server");
			}
			catch { }
		}

		/// <summary>
		/// Manages the ClientConnected event of the input socket
		/// </summary>
		/// <param name="s">Socket used for connection</param>
		private void cnnMan_ClientConnected(Socket s)
		{
			Console(s.RemoteEndPoint.ToString() + " connected to local server");
		}

		/// <summary>
		/// Manages the DataReceived event of the connectionManager
		/// </summary>
		/// <param name="connectionManager">The connection manager that rises the event</param>
		/// <param name="packet">Received data</param>
		void cnnMan_DataReceived(ConnectionManager connectionManager, TcpPacket packet)
		{
#if DEBUG
			for (int i = 0; i < packet.DataStrings.Length; ++i)
			{
				Console("Rcv: " + "[" + packet.SenderIP.ToString() + "] " + packet.DataStrings[i]);
			}
#endif
		}

		#endregion

		#region Command Manager Event Handlers

		private void cmdMan_SharedVariablesLoaded(CommandManager cmdMan)
		{
			if (!cmdMan.SharedVariables.Contains("recognizedSpeech"))
			{
				shRecognizedSpeech = new RecognizedSpeechSharedVariable("recognizedSpeech");
				cmdMan.SharedVariables.Add(shRecognizedSpeech);
			}
			else
				shRecognizedSpeech = (RecognizedSpeechSharedVariable)cmdMan.SharedVariables["recognizedSpeech"];
			Console("Shared variables loaded");
		}

		#endregion

		#region Event Handler Functions

		private void expectedPhraseTimer_Elapsed(object oTimerId)
		{
			if (!(oTimerId is Int32))
				return;
			int timerId = (int)oTimerId;
			int i = 0;
			Timer timer = null;

			lock (expectedPhraseList)
			{
				while (i < expectedPhraseList.Count)
				{
					if (expectedPhraseList[i].TimerId != timerId)
					{
						++i;
						continue;
					}
					timer = expectedPhraseList[i].Timer;
					expectedPhraseList.RemoveAt(i);
				}
			}
			if (timer != null)
			{
				timer.Change(-1, -1);
				timer.Dispose();
			}
		}

		#region Speech Recognition

		private void reco_StatusChanged(SpeechRecognizer sender)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgGrammarLoaded, sender);
				return;
			}

			this.Icon = reco.Enabled ? Properties.Resources.Mic : Properties.Resources.MicRed;
			if (this.chkEnable.Checked != reco.Enabled)
				this.chkEnable.Checked = reco.Enabled;
			if (this.chkFreeDictation.Checked != reco.FreeDictationEnabled)
				this.chkFreeDictation.Checked = reco.FreeDictationEnabled;
		}

		private void reco_GrammarLoaded(SpeechRecognizer sender)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgGrammarLoaded, sender);
				return;
			}

			if (reco.HasGrammar)
			{
				Console("Grammar Loaded");
				ControlsEnabled = true;
				cmdMan.Ready = true;
				//RecognitionEnabled = true;
			}
			else
			{
				Console("Can't load grammar");
				ControlsEnabled = false;
				cmdMan.Ready = false;
				//RecognitionEnabled = false;
			}
		}

		private void reco_SpeechHypothesized(SpeechRecognizer sender, RecognizedSpeech recognizedSpeech)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgSpeechHypothesized, recognizedSpeech);
				return;
			}

			string textToAppend;

			try
			{
				textToAppend = String.Empty;
				//textToAppend = "{";
				for (int i = 0; i < recognizedSpeech.Count; ++i)
				{
					//textToAppend += "\t";
					textToAppend += GetRecognizedPhraseDisplayText(recognizedSpeech[i]);
				}
				//textToAppend += "}\r\n";

				txtHypothesis.AppendText(textToAppend);
			}
			catch { }
		}

		private void reco_SpeechRecognitionRejected(SpeechRecognizer sender, RecognizedSpeech recognizedSpeech)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgSpeechRecognitionRejected, recognizedSpeech);
				return;
			}

			string textToAppend;

			try
			{
				textToAppend = String.Empty;
				//textToAppend = "{";
				for (int i = 0; i < recognizedSpeech.Count; ++i)
				{
					//textToAppend += "\t";
					textToAppend += GetRecognizedPhraseDisplayText(recognizedSpeech[i]);
				}
				//textToAppend += "}\r\n";

				txtRejected.AppendText(textToAppend);
				//if (sendRejected)
				//{
				//    txtHypothesis.Text = "";
				//    if (currentRecognitionMaxVolumeLevel > volumeTreshold)
				//        txtRecognizedText.AppendText("*" + recoResult.Text + " (rejected, volume under trshold)\r\n");
				//    else
				//    {
				//        txtRecognizedText.AppendText("*" + recoResult.Text + " (rejected)\r\n");
				//        SendRecognizedText(recoResult.Text);
				//    }
				//}
				currentRecognitionMaxVolumeLevel = 0;
			}
			catch { }
		}

		private void reco_SpeechRecognized(SpeechRecognizer sender, RecognizedSpeech recognizedSpeech)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgSpeechRecognized, recognizedSpeech);
				return;
			}

			string textToAppend;

			try
			{
				if (currentRecognitionMaxVolumeLevel >= volumeTreshold)
					SendRecognizedText(recognizedSpeech);

				txtHypothesis.Text = "";
				txtRejected.Text = "";

				//textToAppend = String.Empty;
				textToAppend = recognizedSpeech.Count.ToString() + " alternate";
				if (recognizedSpeech.Count > 1)
					textToAppend += "s";
				textToAppend += "\r\n{\r\n";

				for (int i = 0; i < recognizedSpeech.Count; ++i)
				{
					textToAppend += "\t";
					textToAppend += GetRecognizedPhraseDisplayText(recognizedSpeech[i]);
				}
				textToAppend += "}\r\n";

				

				if (currentRecognitionMaxVolumeLevel < volumeTreshold)
					textToAppend += " (Not sent due to low volume)\r\n";
				currentRecognitionMaxVolumeLevel = 0;

				txtRecognizedText.AppendText(textToAppend);
			}
			catch { }

			/*
			if (expectedPhraseList.Count > 0)
			{
				if (MatchExpectedWords(recoResult.Text))
				{
					txtRecognizedText.AppendText(" (Expected!!!)");
					SendRecognizedText(recoResult.Text);
				}
				else
					txtRecognizedText.AppendText(" (Unexpected)");
				currentRecognitionMaxVolumeLevel = 0;
				txtRecognizedText.AppendText("\r\n");
				return;
			}
			*/
		}

		private void reco_AudioLevelChanged(int audioLevel)
		{
			if (this.InvokeRequired)
			{
				if (!this.IsHandleCreated || this.Disposing || this.IsDisposed)
					return;
				this.BeginInvoke(dlgAudioLevelChanged, audioLevel);
				return;
			}
			try
			{
				pbAudioLevel.Value = audioLevel;
				//if((currentRecognitionMaxVolumeLevel > volumeTreshold) && (audioLevel > currentRecognitionMaxVolumeLevel))
				if (audioLevel > currentRecognitionMaxVolumeLevel)
					currentRecognitionMaxVolumeLevel = audioLevel;
			}
			catch { }
		}

		#endregion

		#region Form

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (cmdMan.IsRunning) cmdMan.Stop();
			if (cnnMan.IsRunning) cnnMan.Stop();
			try
			{
				reco.Enabled = false;
			}
			catch { }
		}

		private void FrmSpRec_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Application.Exit();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cnnMan.Start();
			cmdMan.Start();
			if (System.IO.File.Exists(txtGrammarFile.Text)) LoadGrammar();
			if (reco.HasGrammar) RecognitionEnabled = true;
			dlgOpenFile.InitialDirectory = Application.StartupPath;
		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			RecognitionEnabled = chkEnable.Checked;
		}

		private void chkFreeDictation_CheckedChanged(object sender, EventArgs e)
		{
			reco.FreeDictationEnabled = chkFreeDictation.Checked;
		}

		private void btnLoadGrammar_Click(object sender, EventArgs e)
		{
			if (!System.IO.File.Exists(txtGrammarFile.Text))
			{
				if (dlgOpenFile.ShowDialog() != DialogResult.OK)
					return;
				txtGrammarFile.Text = dlgOpenFile.FileName;
			}
			LoadGrammar();
		}

		private void btnExploreGrammar_Click(object sender, EventArgs e)
		{
			if (dlgOpenFile.ShowDialog() != DialogResult.OK) return;
			txtGrammarFile.Text = dlgOpenFile.FileName;
		}

		private void cmbProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool lastEnabledStatus;

			lastEnabledStatus = reco.Enabled;
			reco.Enabled = false;
			reco.SelectedProfile = (string)cmbProfiles.SelectedItem;
			reco.Enabled = lastEnabledStatus;
		}

		private void FrmSpRec_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Space) && reco.HasGrammar)
				RecognitionEnabled = false;
		}

		private void FrmSpRec_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Space) && reco.HasGrammar)
				RecognitionEnabled = true;
		}

		private void chkSendRejected_CheckedChanged(object sender, EventArgs e)
		{
			SendRejected = chkSendRejected.Checked;
		}

		private void nudVolumeTreshold_ValueChanged(object sender, EventArgs e)
		{
			this.volumeTreshold = (int)nudVolumeTreshold.Value;
		}

		#endregion

		#endregion
	}
}